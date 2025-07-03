using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyTracker_App.Models.Domain
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User : IdentityUser
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; } = null;
        public required string DisplayName { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.RegularUser;
        public bool IsBanned { get; set; } = false;
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(DisplayName))
            {
                if (string.IsNullOrWhiteSpace(UserName))
                {
                    return string.Empty;
                }
                else
                {
                    return UserName;
                }
            }
            else
            {
                return DisplayName;
            }
                
        }
    }
}
