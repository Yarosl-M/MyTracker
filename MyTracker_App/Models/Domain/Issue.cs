namespace MyTracker_App.Models.Domain
{
    public class Issue : Entry
    {
        public int IssueNumber { get; set; }
        public required string Title { get; set; }
		public IssueStatus Status { get; set; } = IssueStatus.Pending;
        public DateTimeOffset? ClosedAt { get; set; } = null;
        public required User CreatedBy { get; set; }
        public User? AssignedTo { get; set; } = null;
        
        public Message FirstMessage { get; set; }
        public IList<Message> Messages { get; set; }
    }
}
