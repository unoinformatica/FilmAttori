using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Data {

    public class DummyRepository : IMvcMovieRepository {
        public void Add<T>(T entity) where T : class {
            throw new NotImplementedException();
        }

        public void AddActorToMovie(int movieId, int actorId) {
            // do nothing
        }

        public void Delete<T>(T entity) where T : class {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> GetActorsFromMovie(int movieId) {
            return null;
        }

        public Task<bool> SaveAll() {
            throw new NotImplementedException();
        }
    }

    // implementazione del repository
    public class MvcMovieRepository : IMvcMovieRepository {

        private readonly MvcMovieContext _context;
        public MvcMovieRepository(MvcMovieContext context) {
            _context = context;
        }

        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }

        // aggiunge un attore ad un film
        public void AddActorToMovie(int movieId, int actorId) {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == movieId);
            if (movie != null) {
                var actor = _context.Actors.FirstOrDefault(a => a.Id == actorId);
                if (actor != null) {
                    // controlliamo che l'associazione non esista già
                    var existMA = _context.MoviesActors.Where(ma => ma.ActorId == actorId && ma.MovieId == movieId).FirstOrDefault();
                    if (existMA == null) {
                        var movieActor = new MovieActor();
                        movieActor.Movie = movie;
                        movieActor.Actor = actor;
                        _context.MoviesActors.Add(movieActor);
                        _context.SaveChangesAsync();
                    }
                }
            }
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        // restituisce la lista degli attori che hanno recitato in un film
        public async Task<IEnumerable<Actor>> GetActorsFromMovie(int movieId) {
            var actorsIds = await _context.MoviesActors.Where(ma => ma.MovieId == movieId).Select(ai => ai.ActorId).ToArrayAsync();
            var actorList = await _context.Actors.Where(a => actorsIds.Contains(a.Id)).ToListAsync();
            return actorList;
        }


        // ritorna true se è stato salvato qualcosa nel DB
        public async Task<bool> SaveAll() {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}

