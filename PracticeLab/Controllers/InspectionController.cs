using Microsoft.AspNetCore.Mvc;
using PracticeLab.Data;
using PracticeLab.DTOs;
using PracticeLab.Services;
using Microsoft.EntityFrameworkCore;

namespace PracticeLab.Controllers
{
    public class InspectionController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IFileService fileService;
        private readonly IGeminiService geminiService;
        private readonly IInspectionService inspectionService;
        public InspectionController(IFileService fileService, IGeminiService geminiService, IInspectionService inspectionService, ApplicationDbContext context)
        {
            this.fileService = fileService;
            this.geminiService = geminiService;
            this.inspectionService = inspectionService;
            this.context = context;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> AnalyzeImage(IFormFile file)
        {
            var imageUrl = await fileService.SaveImageAsync(file);
            using var stream = file.OpenReadStream();
            var result = await geminiService.AnalyzeImageAsync(stream, file.ContentType);

            if (result.Dto != null) result.Dto.ImageUrl = imageUrl;
            return Ok(result.Dto);
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmReport([FromBody] ReportConfirmDto dto)
        {
            var success = await inspectionService.SaveInspectionAndReportAsync(dto);
            if (success) return Ok(new { message = "Save report and update inventory successfully!" });
            return BadRequest("Save data error");
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var historyList = await context.InspectionReports
            .Select(report => new ReportHistoryDto
            {
                ReportId = report.ReportId,
                ProductName = report.Product != null ? report.Product.ProductName : "N/A",
                Category = report.Product != null ? report.Product.Category : "N/A",
                InspectorName = report.InspectorId.ToString(),
                DefectDescription = report.DefectDescription,
                QualityStatus = report.QualityStatus,
                CreateAt = report.CreateAt
            })
            .OrderByDescending(r => r.CreateAt)
            .ToListAsync();

            return Ok(historyList);
        }
    }
}
