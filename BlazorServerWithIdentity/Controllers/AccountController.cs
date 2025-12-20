using BlazorServerWithIdentity.DataPersistence.IdentityModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlazorServerWithIdentity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/login");
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] string account, [FromQuery] string password)
        {
            var user = await _userManager.FindByNameAsync(account);
            if (user is null)
                return Unauthorized("用户不存在");
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return Unauthorized("密码错误");
            await _signInManager.SignInAsync(user, isPersistent: true);
            // 登录成功后重定向回首页
            return Redirect("/");
        }
    }

}
