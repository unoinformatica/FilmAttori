using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        public Gender ActorGender { get; set; } // richiamo per dropdownlist
    }
}
