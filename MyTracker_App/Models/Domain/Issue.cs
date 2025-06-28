namespace MyTracker_App.Models.Domain
{
    public class Issue : Entry
    {
        public string Title { get; set; }
		public IssueStatus Status { get; set; } = IssueStatus.Pending;
    }
}
