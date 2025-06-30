using Microsoft.EntityFrameworkCore;

namespace MyTracker_App.Models.Domain
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User : Entry
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; } = UserRole.RegularUser;
        public bool IsBanned { get; set; } = false;
    }
}
