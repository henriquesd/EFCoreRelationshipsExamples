using System.Collections.Generic;
using EFCoreRelationshipsExamples.Models.ManyToMany;
using EFCoreRelationshipsExamples.Models.OneToMany;
using EFCoreRelationshipsExamples.Models.OneToMany.FullyDefinedRelationships;
using EFCoreRelationshipsExamples.Models.OneToOne;

namespace EFCoreRelationshipsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreRelationshipsExamplesDbContext())
            {
                OneToManyRelationship(context);
                OneToManyFullyDefinedRelationships(context);
                ManyToManyRelationship(context);
                OneToOneRelationship(context);
            }
        }

        private static void OneToManyRelationship(EFCoreRelationshipsExamplesDbContext context)
        {
            var course = new Course
            {
                Name = "Computer Science",
                Students = new List<Student>()
                {
                    new Student {Name = "James"},
                    new Student {Name = "Mathew"},
                    new Student {Name = "John"},
                    new Student {Name = "Luke"}
                }
            };
            context.Add(course);
            context.SaveChanges();
        }

        private static void OneToManyFullyDefinedRelationships(EFCoreRelationshipsExamplesDbContext context)
        {
            var customer = new Customer
            {
                Name = "Robert",
                Orders = new List<Order>()
                {
                    new Order { Description = "Order 1" },
                    new Order { Description = "Order 2" },
                    new Order { Description = "Order 3" },
                    new Order { Description = "Order 4" }
                }
            };
            context.Add(customer);
            context.SaveChanges();
        }

        private static void ManyToManyRelationship(EFCoreRelationshipsExamplesDbContext context)
        {
            var actor1 = new Actor { Name = "Marlon Brando" };
            var actor2 = new Actor { Name = "Al Pacino" };
            context.Add(actor1);
            context.Add(actor2);

            var movie1 = new Movie { Name = "The Godfather" };
            var movie2 = new Movie { Name = "Scarface" };
            context.Add(movie1);
            context.Add(movie2);
            context.SaveChanges();

            var actorMovies1 = new ActorMovie() { ActorId = actor1.Id, MovieId = movie1.Id };
            var actorMovies2 = new ActorMovie() { ActorId = actor2.Id, MovieId = movie1.Id };
            var actorMovies3 = new ActorMovie() { ActorId = actor2.Id, MovieId = movie2.Id };

            context.Add(actorMovies1);
            context.Add(actorMovies2);
            context.Add(actorMovies3);
            context.SaveChanges();
        }

        private static void OneToOneRelationship(EFCoreRelationshipsExamplesDbContext context)
        {
            var author = new Author { Name = "Robert Cecil Martin" };
            context.Add(author);
            context.SaveChanges();

            var authorBiography = new AuthorBiography { AuthorId = author.Id, PlaceOfBirth = "Palo Alto - California" };
            context.Add(authorBiography);
            context.SaveChanges();
        }
    }
}