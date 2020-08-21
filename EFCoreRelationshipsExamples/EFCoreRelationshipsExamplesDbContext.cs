using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsExamples
{
    public class EFCoreRelationshipsExamplesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=EFCoreRelationshipsExamples;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
