using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class ActorViewModel {
        public List<Actor> Actors;
        public string SearchString { get; set; }
    }
}