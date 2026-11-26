using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    // يمثل البيانات التي يرسلها المستخدم عند إنشاء حساب جديد
    public class RegisterDto
    {
        // اسم المستخدم
        [Required]
        public string UserName { get; set; } = string.Empty;

        // البريد الإلكتروني
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // كلمة المرور
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
