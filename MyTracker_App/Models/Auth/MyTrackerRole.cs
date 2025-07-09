using Microsoft.AspNetCore.Identity;

namespace MyTracker_App.Models.Auth
{
    public class MyTrackerRole : IdentityRole<int>
    {
        public MyTrackerRole() : base() { }
        public MyTrackerRole(string role_name) : base(role_name) { }
    }
}
