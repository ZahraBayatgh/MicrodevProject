using System.ComponentModel.DataAnnotations;

namespace MicrodevProject.ViewModels
{
    public class RegisterUserViewModel
    {
        [EmailAddress]
        [Required, MaxLength(256), Display(Name = " نام کاربری ")]
        public string Username { get; set; }
        [StringLength(100, ErrorMessage = "باید {1}حداقل  و{2} حداکثر کاراکتر باشد{0} یک", MinimumLength = 6)]
        [Required, DataType(DataType.Password), Display(Name = "پسورد ")]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "پسورد و تایید پسورد با هم منطبق نیستند."), Display(Name = " تکرار پسورد ")]
        public string ConfirmPassword { get; set; }
    }
}