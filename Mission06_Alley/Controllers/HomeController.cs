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
            return View();
        }

        [HttpPost]
        public IActionResult Form(Submission response)
        {
            // Save submission to the database or perform other operations
            _context.Submissions.Add(response);
            _context.SaveChanges();

            // Redirect to a confirmation page
            return RedirectToAction("Confirmation", response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
