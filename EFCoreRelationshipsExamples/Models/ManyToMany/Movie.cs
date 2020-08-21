using System.Collections.Generic;

namespace EFCoreRelationshipsExamples.Models.ManyToMany
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ActorMovie> ActorMovies { get; set; }
    }
}