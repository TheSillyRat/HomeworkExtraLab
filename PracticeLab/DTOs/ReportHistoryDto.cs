namespace PracticeLab.DTOs
{
    public class ReportHistoryDto
    {
        public int ReportId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string InspectorName { get; set; } = string.Empty;
        public string? DefectDescription { get; set; } 
        public string QualityStatus { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } 
    }
}
