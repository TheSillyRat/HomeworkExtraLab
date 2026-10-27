using System.ComponentModel.DataAnnotations;

namespace PracticeLab.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(200)]
        public string ProductName { get; set; } = string.Empty;
        [StringLength(100)]
        public string Category { get; set; } = string.Empty;
        public int TotalStock { get; set; }
        public int PassedStock { get; set; }
        public int FailedStock { get; set; }
        public DateTime CreateAt = DateTime.Now;
    }
}
