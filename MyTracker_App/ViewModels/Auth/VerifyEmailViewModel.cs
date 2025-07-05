using System.ComponentModel.DataAnnotations;

namespace MyTracker_App.ViewModels.Auth
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Поле \"E-mail\" обязательно для ввода")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
