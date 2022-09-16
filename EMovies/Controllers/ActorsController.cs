using EMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMovies.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MovieDbContext _context;

        public ActorsController(MovieDbContext context)
        {
            _context = context;
        } 
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actor a)
        {
            if (ModelState.IsValid)
            {


                _context.Actors.Add(a);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(a);

        }

        public IActionResult Details(int id)
        {
            Actor actorDetails = _context.Actors.Find(id);
            if(actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _context.Actors.FindAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Actor a = await _context.Actors.FindAsync(id);
            if (a == null)
            {
                return View("NotFound");
            }
            return View(a);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Actor a = await _context.Actors.FindAsync(id);
            if (a == null)
            {
                return View("NotFound");
            }
            _context.Actors.Remove(a);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }

}

