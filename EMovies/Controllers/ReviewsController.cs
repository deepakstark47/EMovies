using EMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EMovies.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly MovieDbContext _context;

        public ReviewsController(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            var data = await _context.Reviews.Include(r=>r.Movie).Where(r => r.MovieId == id).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> AllReviews(int id)
        {
            var data = await _context.Reviews.Include(r => r.Movie).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            var result = _context.Movies.ToList();
            ViewBag.MovieName = new SelectList(result, "MovieId", "MovieName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review r)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(r);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllReviews));
            }
            return View(r);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = _context.Movies.ToList();
            ViewBag.MovieName = new SelectList(result, "MovieId", "MovieName");

            var reviewDetails = await _context.Reviews.FindAsync(id);
            if (reviewDetails == null) return View("NotFound");
            return View(reviewDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Review r)
        {
            if (!ModelState.IsValid)
            {
                return View(r);
            }
            _context.Reviews.Update(r);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllReviews));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var r = await _context.Reviews.Include(r => r.Movie).Where(r => r.ReviewId == id).SingleOrDefaultAsync();
            if (r == null)
            {
                return View("NotFound");
            }
            return View(r);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Review r = await _context.Reviews.FindAsync(id);
            if (r == null)
            {
                return View("NotFound");
            }
            _context.Reviews.Remove(r);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllReviews");
        }





    }
}
