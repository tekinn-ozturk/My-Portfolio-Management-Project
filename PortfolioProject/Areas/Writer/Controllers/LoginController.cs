using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Areas.Writer.Models;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterAppUser> _signInManager;

        public LoginController(SignInManager<WriterAppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginVM loginVM)
        {
            //ImparatorJR -> 41Tekn41.-
            //Emrecan -> 41Tekn41.-

            //loginVM'in içerisindeki dataAnnoutation rule'ları geçti mi?
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış!");
                }
              
            }
            return View();

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
