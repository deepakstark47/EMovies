using EMovies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMovies.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DirectorsController : Controller
    {
        private readonly MovieDbContext _context;

        public DirectorsController(MovieDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Directors.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Director d)
        {
            if (ModelState.IsValid)
            {


                _context.Directors.Add(d);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(d);

        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var directorDetails = _context.Directors.Find(id);
            if (directorDetails  == null)
            {
                return View("NotFound");
            }
            return View(directorDetails);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var directorDetails = await _context.Directors.FindAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Director d)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Directors.Update(d);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Director d = await _context.Directors.FindAsync(id);
            if (d == null)
            {
                return View("NotFound");
            }
            return View(d);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Director d = await _context.Directors.FindAsync(id);
            if (d == null)
            {
                return View("NotFound");
            }
            _context.Directors.Remove(d);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }









    }
}
