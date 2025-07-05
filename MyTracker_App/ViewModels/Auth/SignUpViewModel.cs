using System.ComponentModel.DataAnnotations;

namespace MyTracker_App.ViewModels.Auth
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Поле \"E-mail\" обязательно для ввода")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле \"Пароль\" обязательно для ввода")]
        [StringLength(50, MinimumLength = 6,
            ErrorMessage = "Длина пароля должна быть от 6 до 50 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Необходимо повторить введённый пароль")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),
            ErrorMessage = "Пароль не совпадает.")]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirmation { get; set; }
    }
}
