namespace EFCoreRelationshipsExamples.Models.OneToOne
{
    public class AuthorBiography
    {
        public int Id { get; set; }
        public string PlaceOfBirth { get; set; }

        // The AuthorId property is the Foreign Key
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
