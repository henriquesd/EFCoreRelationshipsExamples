using EFCoreRelationshipsExamples.Models.OneToMany;
using EFCoreRelationshipsExamples.Models.OneToMany.FullyDefinedRelationships;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsExamples
{
    public class EFCoreRelationshipsExamplesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreRelationshipsExamples;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        // Write Fluent API configurations on this method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OneToManyRelationshipConfiguration(modelBuilder);
        }

        private void OneToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            // For One-To-Many you can configuring using both end of the relationship;

            // Starting with Course:
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .IsRequired(); // isRequired is used to prevent the relationship from being optional

            // Starting with Student:
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.Course)
            //    .WithMany(c => c.Students)
            //    .IsRequired(); // isRequired is used to prevent the relationship from being optional
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}