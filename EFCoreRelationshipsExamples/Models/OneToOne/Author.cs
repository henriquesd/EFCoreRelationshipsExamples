namespace EFCoreRelationshipsExamples.Models.OneToOne
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* EF Relation */
        public AuthorBiography Biography { get; set; }
    }
}
