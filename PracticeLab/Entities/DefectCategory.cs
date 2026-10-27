using System.ComponentModel.DataAnnotations;

namespace PracticeLab.Entities
{
    public class DefectCategory
    {
        [Key]
        public int DefectCategoryId { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;
        [StringLength(50)]
        public string SeverityLevel { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; }
    }
}
