using System.ComponentModel.DataAnnotations;
namespace MicrodevProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "نام کاربری ")]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        [Display(Name = "کلمه عبور ")]
        public string Password { get; set; }
        [Display(Name = "مرابه خاطر بسپار ")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
