using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("MovieSubmission", new Movie());
        }

        [HttpPost]
        public IActionResult MovieSubmission(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to the database
                _context.SaveChanges();
                return RedirectToAction("Index", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();

                return View(response);
            }

        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var recordToEdit = _context.Movies
                .SingleOrDefault(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("MovieSubmission", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
