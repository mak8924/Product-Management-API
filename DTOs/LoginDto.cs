using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    // يمثل البيانات التي يرسلها المستخدم عند تسجيل الدخول
    public class LoginDto
    {
        // البريد الإلكتروني
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // كلمة المرور
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
