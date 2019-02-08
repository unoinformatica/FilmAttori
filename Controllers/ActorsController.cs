using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ActorsController : Controller
    {
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
    }
} 