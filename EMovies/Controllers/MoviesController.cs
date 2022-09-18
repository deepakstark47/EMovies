using EMovies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EMovies.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Movies.Include(m => m.Director).Include(m => m.Category).ToListAsync();
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _context.Movies.Include(m => m.Director).Include(m => m.Category).Include(m => m.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.MovieId == id);
            return View(data);
        }

        [AllowAnonymous]

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _context.Movies.Include(m => m.Director).Include(m => m.Category).ToListAsync(); ;

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.MovieName, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.MovieDescription, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Category.CategoryName, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "ActorName");
            ViewBag.Directors = new SelectList(_context.Directors, "DirectorId", "DirectorName");

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM nm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
                ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "ActorName");
                ViewBag.Directors = new SelectList(_context.Directors, "DirectorId", "DirectorName");
                return View(nm);
            }
            var newMovie = new Movie()
            {
                MovieName = nm.MovieName,
                MovieDescription = nm.MovieDescription,
                MoviePrice = nm.MoviePrice,
                MovieImageURL = nm.MovieImageURL,
                ReleaseDate = nm.ReleaseDate,
                CategoryId = nm.CategoryId,
                DirectorId = nm.DirectorId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
            
            //Add Movie Actors
            foreach (var actorId in nm.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.MovieId,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Edit(int id)
        {
            var nm = await _context.Movies.Include(m => m.Director).Include(m => m.Category).Include(m => m.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.MovieId == id);
            if (nm == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                MovieId = nm.MovieId,
                MovieName = nm.MovieName,
                MovieDescription = nm.MovieDescription,
                MoviePrice = nm.MoviePrice,
                MovieImageURL = nm.MovieImageURL,
                ReleaseDate = nm.ReleaseDate,
                CategoryId = nm.CategoryId,
                DirectorId = nm.DirectorId,
                ActorIds = nm.Actors_Movies.Select(n => n.ActorId).ToList(),
            };
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "ActorName");
            ViewBag.Directors = new SelectList(_context.Directors, "DirectorId", "DirectorName");

            return View(response);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.MovieId) return View("NotFound");

            if (!ModelState.IsValid)
            {

                ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
                ViewBag.Actors = new SelectList(_context.Actors, "ActorId", "ActorName");
                ViewBag.Directors = new SelectList(_context.Directors, "DirectorId", "DirectorName");

                return View(movie);
            }

            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.MovieId == movie.MovieId);

            if (dbMovie != null)
            {
                dbMovie.MovieName = movie.MovieName;
                dbMovie.MovieDescription = movie.MovieDescription;
                dbMovie.MoviePrice = movie.MoviePrice;
                dbMovie.MovieImageURL = movie.MovieImageURL;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.CategoryId = movie.CategoryId;
                dbMovie.DirectorId = movie.DirectorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == movie.MovieId).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in movie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = movie.MovieId,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}


