
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any() && context.Actors.Any())
                {
                    return;   // DB has been seeded
                }

                #region seed movies
                if (!context.Movie.Any()) {
                    context.Movie.AddRange(
                        new Movie {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M,
                            Rating = "R"
                        },

                        new Movie {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M,
                            Rating = "G"
                        },

                        new Movie {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M,
                            Rating = "G"
                        },

                        new Movie {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M,
                            Rating = "NA"
                        }
                    );
                    #endregion

                }

                #region seed actors
                if (!context.Actors.Any()) {
                    context.Actors.AddRange(
                    new Actor {
                        FullName = "John Travolta",
                        BirthDate = DateTime.Parse("1959-2-12"),
                        ActorGender = Gender.Male
                    },
                    new Actor {
                        FullName = "Tom Hardy",
                        BirthDate = DateTime.Parse("1985-3-12"),
                        ActorGender = Gender.Male
                    },
                    new Actor {
                        FullName = "Cameron Diaz",
                        BirthDate = DateTime.Parse("1978-4-12"),
                        ActorGender = Gender.Female
                    }
                    );
                }
                #endregion

                context.SaveChanges();
            }
        }
    }
}
