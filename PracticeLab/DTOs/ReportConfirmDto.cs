namespace PracticeLab.DTOs
{
    public class ReportConfirmDto
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public int InspectorId { get; set; }
        public int? DefectCategoryId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? DefectDescription { get; set; }
        public string QualityStatus { get; set; } = string.Empty;
        public float ConfidenceScore { get; set; }
        public bool IsUserConfirmed { get; set; } = true;
    }
}
