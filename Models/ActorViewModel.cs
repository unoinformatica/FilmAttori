using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class ActorViewModel {
        public List<Actor> Actors;
        public SelectList ActorGender;
        public string SearchString { get; set; }
    }
}