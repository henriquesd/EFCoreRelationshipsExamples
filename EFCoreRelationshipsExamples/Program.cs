using System.Collections.Generic;
using EFCoreRelationshipsExamples.Models.OneToMany;

namespace EFCoreRelationshipsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreRelationshipsExamplesDbContext())
            {
                OneToManyRelationship(context);
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
    }
}
