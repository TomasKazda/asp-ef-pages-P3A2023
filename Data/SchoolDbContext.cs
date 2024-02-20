using Microsoft.EntityFrameworkCore;
using asp_ef_pages.Models;

namespace asp_ef_pages.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectOnClass> SubjectsOnClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectOnClass>()
                .HasIndex(x => x.LinkId).IsUnique();
            modelBuilder.Entity<SubjectOnClass>()
                .HasKey(soc => new { soc.ClassId, soc.SubjectId });
        }
    }
}
