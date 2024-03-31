using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Areas.Writer.Models;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterAppUser> _userManager;

        public RegisterController(UserManager<WriterAppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM p)
        {
            if (ModelState.IsValid)
            {
                WriterAppUser writerAppUser = new WriterAppUser
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    ImageUrl = p.ImageUrl,
                    Email = p.Mail,
                    UserName = p.UserName,
                    //password hariç vm deki tüm property'leri aldık.


                };
                //Hesap yaratma komutu.
                if (p.ConfirmPassword==p.Password)
                {
                    var result = await _userManager.CreateAsync(writerAppUser, p.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
               

               

            }


            return View();
        }
    }
}
