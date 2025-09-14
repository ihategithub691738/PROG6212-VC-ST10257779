using Microsoft.AspNetCore.Mvc;
using PROG6212_VC_ST10257779.Data;
using PROG6212_VC_ST10257779.Models;
using PROG6212_VC_ST10257779.ViewModels;
using System.Linq;

namespace PROG6212_VC_ST10257779.Controllers
{
    public class ClaimsController : Controller
    {
        public IActionResult Index()
        {
            var data = from c in FakeDb.Claims
                       join l in FakeDb.Lecturers on c.LecturerId equals l.Id
                       orderby c.SubmittedAt descending
                       select new
                       {
                           c.Id, Lecturer = l.FullName, c.Year, c.Month, c.HoursWorked, c.HourlyRate, c.Amount, c.Status
                       };

            return View(data.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Lecturers = FakeDb.Lecturers;
            return View(new ClaimCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClaimCreateViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Lecturers = FakeDb.Lecturers;
                return View(vm);
            }

            var claim = new Claim
            {
                LecturerId = vm.LecturerId,
                Year = vm.Year,
                Month = vm.Month,
                HoursWorked = vm.HoursWorked,
                HourlyRate = vm.HourlyRate,
                Status = ClaimStatus.Submitted
            };

            FakeDb.AddClaim(claim);

            TempData["Success"] = "Claim submitted (prototype). Data is not persisted to a database at this stage.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var claim = FakeDb.Claims.FirstOrDefault(c => c.Id == id);
            if (claim == null) return NotFound();

            var lecturer = FakeDb.GetLecturer(claim.LecturerId);
            ViewBag.Lecturer = lecturer;

            var docs = FakeDb.Documents.Where(d => d.ClaimId == id).ToList();
            var approvals = FakeDb.Approvals.Where(a => a.ClaimId == id).ToList();

            ViewBag.Documents = docs;
            ViewBag.Approvals = approvals;
            return View(claim);
        }
    }
}
/*
 * Code assistance: OpenAI ChatGPT
 * Code assistance: STACKOVERFLOW
 * Date: 2025-09-14
 */

