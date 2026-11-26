using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    // تنفيذ خدمة إنشاء JWT Token
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        // استقبال إعدادات التطبيق
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // إنشاء JWT Token للمستخدم
        public string CreateToken(ApplicationUser user)
        {
            // قراءة مفتاح التشفير من الإعدادات
            var key = _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key is missing.");

            // قراءة Issuer
            var issuer = _configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT Issuer is missing.");

            // قراءة Audience
            var audience = _configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT Audience is missing.");

            // إنشاء مفتاح التوقيع
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));

            // تحديد خوارزمية التوقيع
            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            // إضافة معلومات المستخدم داخل التوكن
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
            };

            // إنشاء التوكن
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            // تحويل التوكن إلى نص وإرجاعه
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
