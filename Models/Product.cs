using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    // يمثل المنتج الذي سيتم تخزينه في قاعدة البيانات
    public class Product
    {
        // المعرف الأساسي للمنتج، ويتم إنشاؤه تلقائيًا
        public int Id { get; set; }

        // اسم المنتج، وهو حقل مطلوب
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // وصف المنتج
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // سعر المنتج، ويجب أن تكون قيمته أكبر من صفر
        [Range(0.01, 999999999)]
        public decimal Price { get; set; }

        // كمية المنتجات المتوفرة في المخزون
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}
