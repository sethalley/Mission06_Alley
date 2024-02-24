using Microsoft.AspNetCore.Mvc;
using Mission06_Alley.Models;
using System.Diagnostics;

namespace Mission06_Alley.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly formContext _context;

        public HomeController(ILogger<HomeController> logger, formContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("form", new Submission());
        }

        [HttpPost]
        public IActionResult Form(Submission response)
        {
            if (ModelState.IsValid)
            {
                // Save submission to the database or perform other operations
                _context.Submissions.Add(response);
                _context.SaveChanges();

                // Redirect to a confirmation page
                return RedirectToAction("List");
            }
            else
            {
                return View(response);
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult List()
        {
            var submissions = _context.Submissions
                .Where(x => x.Rating != null)
                .OrderBy(x => x.MovieId)
                .ToList();


            return View(submissions);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Submissions
                .Single(x => x.MovieId == id);
            return View("form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Submission updatedSub)
        {
            _context.Update(updatedSub);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Submissions
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Submission sub)
        {
            _context.Submissions.Remove(sub);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
