namespace EFCoreRelationshipsExamples.Models.OneToMany
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* EF Relation */
        public Course Course { get; set; }
    }
}