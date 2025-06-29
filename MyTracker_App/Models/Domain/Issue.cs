namespace MyTracker_App.Models.Domain
{
    public class Issue : Entry
    {
        public required string Title { get; set; }
		public IssueStatus Status { get; set; } = IssueStatus.Pending;
        public DateTimeOffset? ClosedAt { get; set; } = null;
    }
}
