using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
        public DbSet<MvcMovie.Models.Actor> Actors { get; set; }
        public DbSet<MvcMovie.Models.MovieActor> MoviesActors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            /*
            builder.Entity<Movie>()
                .HasMany(m => m.Actors);
            builder.Entity<Actor>()
                .HasMany(a => a.Movies);
            */
            builder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
        }

    }
}
