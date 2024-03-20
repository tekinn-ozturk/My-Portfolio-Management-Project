using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Areas.Writer.Models
{
    public class UserRegisterVM
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz!")]
        public string Surname { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parolalarınız Eşleşmiyor!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Email Adresinizi Giriniz!")]
        public string Mail { get; set; }
    }
}
