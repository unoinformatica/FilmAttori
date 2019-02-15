using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 Query relazionale

select M.Title, A.FullName, YEAR(M.ReleaseDate) as Anno
from MoviesActors as MA 
left join Movie M on M.Id = MA.MovieId 
left join Actors A on A.Id = MA.ActorId
WHERE YEAR(M.ReleaseDate) = 1959;

*/

namespace MvcMovie.Models {
    // modella una relazione N:M tra film ed attori
    public class MovieActor {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        //-----------------------------
        //Relationships

        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
