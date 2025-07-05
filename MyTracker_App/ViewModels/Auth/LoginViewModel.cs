using System.ComponentModel.DataAnnotations;

namespace MyTracker_App.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле \"E-mail\" обязательно для ввода")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле \"Пароль\" обязательно для ввода")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
