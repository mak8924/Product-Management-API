using API.Models;

namespace API.Services
{
    // يحدد العقد الخاص بخدمة إنشاء JWT Token
    public interface ITokenService
    {
        // إنشاء وإرجاع JWT Token للمستخدم
        string CreateToken(ApplicationUser user);
    }
}
