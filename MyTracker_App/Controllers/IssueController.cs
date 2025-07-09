using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyTracker_App.Controllers
{
    public class IssueController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Pending()
        {
            return View();
        }
    }
}
