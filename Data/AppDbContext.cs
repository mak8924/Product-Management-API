using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    // يمثل سياق قاعدة البيانات الرئيسي للتطبيق
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        // استقبال إعدادات الاتصال بقاعدة البيانات
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // يمثل جدول المنتجات في قاعدة البيانات
        public DbSet<Product> Products { get; set; }

        // إعدادات إضافية لتحديد أنواع ودقة أعمدة قاعدة البيانات
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // تنفيذ إعدادات ASP.NET Core Identity الأساسية
            base.OnModelCreating(builder);

            // تحديد دقة سعر المنتج إلى 18 رقمًا، منها رقمان بعد الفاصلة
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
