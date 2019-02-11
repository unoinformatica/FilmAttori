using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
//Ciao Claudio
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
        #region Edit Actor Nfos

        // GET: Actor/Nfos/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,BirthDate,ActorGender")] Actor actor) {
            if (id != actor.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ActorExists(actor.Id)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }


        private bool ActorExists(int id) {
            return _context.Movie.Any(e => e.Id == id);
        }
        #endregion

        #region Actor Details
        // GET: Actors/Nfos/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null) {
                return NotFound();
            }

            return View(actor);
        }
        #endregion

    }
}