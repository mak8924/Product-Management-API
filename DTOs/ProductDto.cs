using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    // يمثل البيانات التي نحتاجها عند إضافة منتج أو تعديله
    public class ProductDto
    {
        // اسم المنتج
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // وصف المنتج
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // سعر المنتج
        [Range(0.01, 999999999)]
        public decimal Price { get; set; }

        // الكمية المتوفرة في المخزون
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}
