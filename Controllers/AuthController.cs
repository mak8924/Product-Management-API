using API.DTOs;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // مسؤول عن تسجيل المستخدمين وتسجيل الدخول
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        // استقبال الخدمات المطلوبة من Dependency Injection
        public AuthController(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        // إنشاء حساب مستخدم جديد
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            // التحقق من وجود البريد الإلكتروني مسبقًا
            var existingUser = await _userManager.FindByEmailAsync(
                registerDto.Email);

            if (existingUser != null)
            {
                return BadRequest(new { message = "Email is already registered." });
            }

            // إنشاء كائن المستخدم الجديد
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            // إنشاء المستخدم وحفظ كلمة المرور بشكل آمن عبر Identity
            var result = await _userManager.CreateAsync(
                user,
                registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    errors = result.Errors.Select(error => error.Description)
                });
            }

            return Ok(new
            {
                message = "User registered successfully."
            });
        }

        // تسجيل دخول المستخدم وإرجاع JWT Token
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // البحث عن المستخدم باستخدام البريد الإلكتروني
            var user = await _userManager.FindByEmailAsync(
                loginDto.Email);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            // التحقق من صحة كلمة المرور
            var isPasswordValid = await _userManager.CheckPasswordAsync(
                user,
                loginDto.Password);

            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            // إنشاء JWT Token للمستخدم بعد نجاح تسجيل الدخول
            var token = _tokenService.CreateToken(user);

            return Ok(new
            {
                message = "Login successful.",
                token = token
            });
        }
    }
}
