using BlogProject.Domain.Entities;
using BlogProject.Features.Account.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Features.Account
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AccountService _userService;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AccountService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginDto());

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);

            var user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail)
                       ?? await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);

            if (user == null || user.IsDeleted)
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                return View(loginDto);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(user, "Member"))
                {
                    return RedirectToAction("Index", "Home"); 
                }

                
                return RedirectToAction("Index", "Comment");
            }

            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            return View(loginDto);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.RegisterAsync(model);

            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(model);
        }

        public IActionResult AccessDenied() => View();
    }
}
