using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Models;
using ShopMarket.Models.ViewModels.Account;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopMarket.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ShopUser> _userManager;
        private readonly SignInManager<ShopUser> _signInManager;
        public AccountController(UserManager<ShopUser> userManager, SignInManager<ShopUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if(ModelState.IsValid)
            {
                ShopUser user = new ShopUser
                {
                    UserName = vm.Login,
                    Email = vm.Email,
                    DateOfBirth = vm.DateOfBirth
                };
               IdentityResult result=await _userManager.CreateAsync(user,vm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("Index","Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return View(vm);
                    }
                }
            }
            return View(vm);
        }
        public IActionResult Login(string? returnUrl)
        {
            LoginViewModel lvm=new LoginViewModel() { 
            ReturnUrl = returnUrl
            };
            return View(lvm);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                ShopUser? user=await _userManager.FindByEmailAsync(lvm.Email);
                if (user != null)
                {
                    var result=await _signInManager.PasswordSignInAsync(user,lvm.Password, lvm.RememberMe,false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(lvm.ReturnUrl) && Url.IsLocalUrl(lvm.ReturnUrl))
                        {
                            return Redirect(lvm.ReturnUrl);
                        }
                        else
                        return RedirectToAction("Index", "Account");
                    }
                    ModelState.AddModelError(string.Empty, "Incorrect login or password!");

                }
               
            }
            return View(lvm) ;
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl)
        {
            await _signInManager.SignOutAsync();
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
                return RedirectToAction("Login", "Account");

        }
    }
 
}
