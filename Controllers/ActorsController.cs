using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
//Ciao Cla
namespace MvcMovie.Controllers {
    public class ActorsController : Controller {
        private readonly MvcMovieContext _context;

        public ActorsController(MvcMovieContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString) {

            var actors = from a in _context.Actors
                         select a;

            if (!string.IsNullOrEmpty(searchString)) {
                actors = actors.Where(s => s.FullName.Contains(searchString));
            }

            var actorVM = new ActorViewModel {
                Actors = await actors.ToListAsync()
            };

            return View(actorVM);
        }
        // GET: Actors/Create
        public IActionResult Create() {
            return View(new Actor {
                FullName = "",
                BirthDate = DateTime.Now,
                ActorGender = Gender.Unknown
            }
            );

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,BirthDate,ActorGender")] Actor actor) {
            if (ModelState.IsValid) {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null) {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var actor = await _context.Actors.FindAsync(id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}