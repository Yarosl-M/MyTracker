using System.ComponentModel.DataAnnotations;

namespace MyTracker_App.ViewModels.Issue
{
    public class CreateIssueViewModel
    {
        [Required(ErrorMessage = "Поле \"Заголовок\" обязательно для ввода")]
        [StringLength(maximumLength: 300, MinimumLength = 10,
            ErrorMessage = "Длина заголовка от 10 до 300 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле \"Текст\" обязательно для ввода")]
        [StringLength(maximumLength: 1000, MinimumLength = 100,
            ErrorMessage = "Длина текста от 100 до 1000 символов")]
        public string Text { get; set; }
        // only this for now (I'm trying to get a vertical slice working!)
    }
}
