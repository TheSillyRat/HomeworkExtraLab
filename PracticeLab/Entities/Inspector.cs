using System.ComponentModel.DataAnnotations;

namespace PracticeLab.Entities
{
    public class Inspector
    {
        [Key]
        public int InspectorId { get; set; }
        [StringLength(100)]
        public string InspectorName { get; set; } = string.Empty;
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
    }
}
