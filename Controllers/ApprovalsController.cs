using Microsoft.AspNetCore.Mvc;
using PROG6212_VC_ST10257779.Data;
using PROG6212_VC_ST10257779.Models;
using System.Linq;

namespace PROG6212_VC_ST10257779.Controllers
{
    public class ApprovalsController : Controller
    {
        public IActionResult Index()
        {
            var view = from a in FakeDb.Approvals
                       join c in FakeDb.Claims on a.ClaimId equals c.Id
                       join l in FakeDb.Lecturers on c.LecturerId equals l.Id
                       orderby c.Id
                       select new { a.Id, a.ClaimId, Lecturer = l.FullName, a.Role, a.Status, c.Amount };
            return View(view.ToList());
        }
    }
}

/*
 * Code assistance: OpenAI ChatGPT
 * Code assistance: STACKOVERFLOW
 * Date: 2025-09-14
 */
