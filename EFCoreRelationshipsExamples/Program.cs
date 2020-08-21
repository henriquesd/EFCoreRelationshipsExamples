using System.Collections.Generic;
using EFCoreRelationshipsExamples.Models.OneToMany;
using EFCoreRelationshipsExamples.Models.OneToMany.FullyDefinedRelationships;

namespace EFCoreRelationshipsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreRelationshipsExamplesDbContext())
            {
                OneToManyRelationship(context);
                OneToManyRelationshipFullyDefinedRelationships(context);
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

        private static void OneToManyRelationshipFullyDefinedRelationships(EFCoreRelationshipsExamplesDbContext context)
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
    }
}