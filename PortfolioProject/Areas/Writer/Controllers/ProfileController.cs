using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Areas.Writer.Models;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterAppUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProfileController(UserManager<WriterAppUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //databaseden authorize olmuş kullanıcının bilgisini çekiyorum.
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            //Update'i UserEditVM üzerinden yapacağım için WriterAppUser'ın özelliklerini, UserEditVM'in property'lerine atadım.
            //Artık Index'te duran kişi UserEditVM'den.
            UserEditVM userEditVM = new();
            userEditVM.Name = values.Name;  
            userEditVM.Surname = values.Surname;
            userEditVM.PictureUrl=values.ImageUrl;



            return View(userEditVM);
        }

        
        [HttpPost]
        public async Task<IActionResult> Index(UserEditVM p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Picture != null && p.Picture.Length > 0 && !string.IsNullOrEmpty(user.ImageUrl))
            {
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "user-img", user.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }


            if (p.Picture != null )
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/user-img/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            //var result2 = await _userManager.UpdateAsync(user);
            //if (result2.Succeeded)
            //{
            //    return RedirectToAction("Index", "Login");
            //}


            if (p.Password==null || p.ConfirmPassword ==null)
            {

                user.Name = p.Name;
                user.Surname = p.Surname;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Dashboard");


                }

            }
            else
            {
                user.Name = p.Name;
                user.Surname = p.Surname;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");


                }
            }

           


           

           

            
            return View();

            
        }
      
    }
}
