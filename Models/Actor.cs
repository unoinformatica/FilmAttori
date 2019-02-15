using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models {
    public enum Gender {
        Male,
        Female,
        Unknown
    }

    public class Actor {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender ActorGender { get; set; }

        public string Nationality { get; set; }

        // 1 attore può avere da 0:N film
        //public ICollection<Movie> Movies { get; set; }

    }
}
