using MyTracker_App.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTracker_App.Models.Domain
{
    public class Issue : Entry
    {
        public required string Title { get; set; }
		public IssueStatus Status { get; set; } = IssueStatus.Pending;
        public DateTimeOffset? ClosedAt { get; set; } = null;
        public DateTimeOffset? ArchivedAt { get; set; } = null;
        public required User CreatedBy { get; set; }
        public User? AssignedTo { get; set; } = null;

        public IList<Message> Messages { get; set; }
    }
}
