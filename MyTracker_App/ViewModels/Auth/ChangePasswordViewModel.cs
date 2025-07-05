using System.ComponentModel.DataAnnotations;

namespace MyTracker_App.ViewModels.Auth
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Поле \"E-mail\" обязательно для ввода")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле \"Старый пароль\" обязательно для ввода")]
        [DataType(DataType.Password)]
        [Display(Name = "Старый пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Поле \"Новый пароль\" обязательно для ввода")]
        [DataType(DataType.Password)]
        //[Compare(nameof(OldPassword))] something something
        [StringLength(50, MinimumLength = 6,
            ErrorMessage = "Длина пароля должна быть от 6 до 50 символов")]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Необходимо повторить введённый пароль")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword),
            ErrorMessage = "Новый пароль не совпадает.")]
        [Display(Name = "Подтвердить новый пароль")]
        public string NewPasswordConfirmation {  get; set; }
    }
}
