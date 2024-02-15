using Microsoft.AspNetCore.Mvc;
using Mission06_Belgique.Models;
using System.Diagnostics;

namespace Mission06_Belgique.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext _context;

        public HomeController(MovieSubmissionContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSubmission()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSubmission(MovieSubmit response)
        {
            _context.MovieSubmits.Add(response); //Add record to the database
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
