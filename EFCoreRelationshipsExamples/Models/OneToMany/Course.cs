using System.Collections.Generic;

namespace EFCoreRelationshipsExamples.Models.OneToMany
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* EF Relations */
        public IEnumerable<Student> Students { get; set; }
    }
}