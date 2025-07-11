using MyTracker_App.Models.Auth;

namespace MyTracker_App.Models.Domain
{
    public class Message : Entry
    {
        public User CreatedBy { get; set; }
        public required string Text { get; set; }
        public IList<Attachment> Attachments { get; set; }
        public Issue Issue { get; set; }
    }
}
