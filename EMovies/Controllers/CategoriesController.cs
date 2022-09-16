using EMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMovies.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MovieDbContext _context;

        public CategoriesController(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.ToListAsync();
            return View(data);
        }
    }
}
