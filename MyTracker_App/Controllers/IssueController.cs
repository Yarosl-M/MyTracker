using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTracker_App.Data;
using MyTracker_App.Models.Auth;
using MyTracker_App.Models.Domain;
using MyTracker_App.ViewModels.Issue;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace MyTracker_App.Controllers
{
    public class IssueController(UserManager<User> _user_manager,
        MyTrackerDbContext _context) : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Pending()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIssueViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _user_manager.GetUserAsync(User);

            var timestamp = DateTimeOffset.UtcNow;
            var issue = new Issue()
            {
                CreatedAt = timestamp,
                UpdatedAt = timestamp,
                Status = IssueStatus.Pending,
                Title = model.Title.Trim(),
                CreatedBy = user
            };

            var first_message = new Message()
            {
                CreatedAt = issue.CreatedAt,
                UpdatedAt = issue.UpdatedAt,
                CreatedBy = user,
                Text = model.Text.Trim(),
                Issue = issue,
            };
            issue.Messages = [first_message];

            _context.Issues.Add(issue); //_context.Messages.Add(first_message);
            await _context.SaveChangesAsync();

            return RedirectToAction("view", new { id = issue.Id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> View(int id)
        {
            var issue = await _context.Issues
                .Include(i => i.Messages)
                    .ThenInclude(m => m.CreatedBy)
                .Include(i => i.Tags)
                .Include(i => i.CreatedBy)
                .Include(i => i.AssignedTo)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (issue != null)
                return View(issue);
            else return NotFound();
        }
    }
}
