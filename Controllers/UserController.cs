using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Models;
using ShopMarket.Models.DTOs.Users;

namespace ShopMarket.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ShopUser> _userManager;
       
        public UserController(UserManager<ShopUser> userManager)
        {
            _userManager = userManager;            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO dTO)
        {
            if (ModelState.IsValid)
            {
                ShopUser user = new ShopUser
                {
                    UserName = dTO.Login,
                    Email = dTO.Email,
                    DateOfBirth = dTO.DateOfBirth
                };
                IdentityResult result = await _userManager.CreateAsync(user, dTO.Password);
                if (result.Succeeded)
                {                  
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                       
                    }
                }
            }
            return View(dTO);            
        }
        public async Task<IActionResult> Edit(string id)
        {
            ShopUser? user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            EditUserDTO dTO = new EditUserDTO
            {
                Id = user.Id,
                Login = user.UserName ?? "",
                Email = user.Email ?? "",
                DateOfBirth = user.DateOfBirth
            };
            return View(dTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserDTO dTO)
        {
            if (ModelState.IsValid)
            {
                ShopUser? user = await _userManager.FindByIdAsync(dTO.Id);
                if (user == null) return NotFound();
                user.UserName = dTO.Login;
                user.Email=dTO.Email;
                user.DateOfBirth= dTO.DateOfBirth;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                    }
                }
            }
            return View(dTO);
        }
        public async Task<IActionResult> Details(string? id)
        {
           
            if (id =="") return NotFound();
           

            var user = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public async Task<IActionResult> Delete(string? id)
        {
            ShopUser? user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangePassword(string? id)
        {
            ShopUser? user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            ChangePasswordDTO dTO = new ChangePasswordDTO() { 
            Id=id,
            Email=user.Email,
            };
            return View(dTO);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dTO)
        {
            ShopUser? user = await _userManager.FindByIdAsync(dTO.Id);
            if (user == null) return NotFound();
            var result=await _userManager.ChangePasswordAsync(user,dTO.OldPassword,dTO.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }
            }
            return View(dTO);
        }
        }
    }
   

