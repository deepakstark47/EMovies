using EMovies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMovies.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoriesController : Controller
    {
        private readonly MovieDbContext _context;

        public CategoriesController(MovieDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.ToListAsync();
            return View(data);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category cDetails = await _context.Categories.FindAsync(id);
            if (cDetails == null)
            {
                return View("NotFound");
            }
            return View(cDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           Category cDetails = await _context.Categories.FindAsync(id);
            if (cDetails == null)
            {
                return View("NotFound");
            }
            _context.Categories.Remove(cDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




    }
}
