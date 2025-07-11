using MyTracker_App.Models.Auth;

namespace MyTracker_App.ViewModels.Issue
{
    public class ViewIssueViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User CreatedBy { get; set; }
        public User? AssignedTo { get; set; }

    }
}
