namespace MyTracker_App.Models.Domain
{
    public class Tag : Entry
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Issue> Issues { get; set; }
    }
}
