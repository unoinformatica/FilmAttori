using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Data {
    public interface IMvcMovieRepository {

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        void AddActorToMovie(int movieId, int actorId);
        Task<IEnumerable<Actor>> GetActorsFromMovie(int movieId);

    }
}
