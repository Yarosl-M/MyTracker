using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTracker_App.Models.Auth;
using MyTracker_App.Models.Domain;

namespace MyTracker_App.Data
{
    public class MyTrackerDbContext : IdentityDbContext<User,
        MyTrackerRole, int>
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public MyTrackerDbContext(DbContextOptions<MyTrackerDbContext>
            options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Issue>()
        //        .HasMany(i => i.Tags)
        //        .WithMany(t => t.Issues);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Issue>()
        //        .HasMany(i => i.Messages)
        //        .WithOne(m => m.Issue)
        //        .HasForeignKey(m => m.IssueId)
        //        .IsRequired();
        //}
    }
}
