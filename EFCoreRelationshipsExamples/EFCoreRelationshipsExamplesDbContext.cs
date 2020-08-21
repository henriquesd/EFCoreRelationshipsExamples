using EFCoreRelationshipsExamples.Models.ManyToMany;
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
            ManyToManyRelationshipConfiguration(modelBuilder);
        }

        private void OneToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            // For One-To-Many you can configure using both ends of the relationship;

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

        private void ManyToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(t => new { t.ActorId, t.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieId);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
    }
}