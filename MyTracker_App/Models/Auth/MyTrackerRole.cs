using Microsoft.AspNetCore.Identity;
using MyTracker_App.Models.Domain;

namespace MyTracker_App.Models.Auth
{
    public class MyTrackerRole : IdentityRole<int>
    {
        public MyTrackerRole() : base() { }
        public MyTrackerRole(string role_name) : base(role_name) { }
    }
}
