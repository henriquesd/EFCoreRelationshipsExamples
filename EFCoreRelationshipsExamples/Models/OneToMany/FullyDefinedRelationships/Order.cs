namespace EFCoreRelationshipsExamples.Models.OneToMany.FullyDefinedRelationships
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }

        /* EF Relation */
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}