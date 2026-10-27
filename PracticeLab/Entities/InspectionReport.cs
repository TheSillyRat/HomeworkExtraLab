using System.ComponentModel.DataAnnotations;

namespace PracticeLab.Entities
{
    public class InspectionReport
    {
        [Key]
        public int ReportId { get; set; }
        public int ProductId { get; set; }
        public int InspectorId { get; set; }
        public int? DefectCategoryId { get; set; }
        [StringLength(500)]
        public string ImageUrl { get; set; } = string.Empty;
        public string DefectDescription { get; set; } = string.Empty;
        [StringLength(50)]
        public string QualityStatus { get; set; } = string.Empty;
        public float ConfidenceScore { get; set; }
        public bool IsUserConfirmed { get; set; } = true;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public Product? Product { get; set; }

    }
}
