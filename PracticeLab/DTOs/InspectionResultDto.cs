namespace PracticeLab.DTOs
{
    public class InspectionResultDto
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string QualityStatus { get; set; } = string.Empty;
        public string? DefectDescription { get; set; }
        public float ConfidenceScore { get; set; }
        public int? DefectCategoryId { get; set; }
    }
}
