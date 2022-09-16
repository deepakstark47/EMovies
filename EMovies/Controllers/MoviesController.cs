using EMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _context.Movies.Include(m => m.Director).Include(m => m.Category).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _context.Movies.Include(m => m.Director).Include(m => m.Category).Include(m=>m.Actors_Movies).ThenInclude(a =>a.Actor).FirstOrDefaultAsync(n=>n.MovieId==id);
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();

        }


        }
    }
