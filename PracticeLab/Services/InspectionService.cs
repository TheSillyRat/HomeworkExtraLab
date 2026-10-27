using PracticeLab.Data;
using PracticeLab.DTOs;
using PracticeLab.Entities;

namespace PracticeLab.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly ApplicationDbContext context;
        public InspectionService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> SaveInspectionAndReportAsync(ReportConfirmDto dto)
        {
            var newProduct = new Product
            {
                ProductName = dto.ProductName ?? "Unknown Product",
                Category = dto.Category ?? "Uncategorized",
                TotalStock = 1,
                PassedStock = dto.QualityStatus == "Pass" ? 1 : 0,
                FailedStock = dto.QualityStatus == "Fail" ? 1 : 0
            };

            context.Products.Add(newProduct);
            await context.SaveChangesAsync(); 

            var inspection = new InspectionReport
            {
                InspectorId = dto.InspectorId,
                QualityStatus = dto.QualityStatus,
                ConfidenceScore = dto.ConfidenceScore,
                DefectDescription = dto.DefectDescription ?? "No description",
                ImageUrl = dto.ImageUrl ?? ""
            };

            context.InspectionReports.Add(inspection);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
