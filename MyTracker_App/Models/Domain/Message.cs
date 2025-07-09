namespace MyTracker_App.Models.Domain
{
    public class Message : Entry
    {
        public required string Text { get; set; }
        public IList<Attachment> Attachments { get; set; }
        public Issue Issue { get; set; }
    }
}
