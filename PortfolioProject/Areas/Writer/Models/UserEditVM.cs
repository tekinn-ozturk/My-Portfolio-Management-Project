namespace PortfolioProject.Areas.Writer.Models
{
    public class UserEditVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string PictureUrl { get; set; }

        //Yüklenen dosyanın wwwroot'a yüklenmesini sağlayan arayüz.
        public IFormFile Picture { get; set; }

    }
}
