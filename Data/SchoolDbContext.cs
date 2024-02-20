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

            modelBuilder.Entity<Class>(c => {
                c.HasData(new Class { Id = 1, Name = "P3A" },
                          new Class { Id = 2, Name = "P4" });
            });
            modelBuilder.Entity<Student>(s =>
            {
                s.HasData(new Student { StudentId = Guid.NewGuid(), StudentName = "Alice", ClassId = 1 },
                          new Student { StudentId = Guid.NewGuid(), StudentName = "Bob", ClassId = 1 },
                          new Student { StudentId = Guid.NewGuid(), StudentName = "Charlie", ClassId = 2 });
            });
            modelBuilder.Entity<Subject>(s =>
            {
                s.HasData(new Subject { Id = 1, ShortName = "MAT", Name = "Mathematics" },
                          new Subject { Id = 2, ShortName = "ANJ", Name = "English" },
                          new Subject { Id = 3, ShortName = "WEB", Name = "Web application" },
                          new Subject { Id = 4, ShortName = "MPA", Name = "Multiplatform app" });
            });
            var guid = Guid.NewGuid();
            modelBuilder.Entity<Teacher>(modelBuilder =>
            {
                modelBuilder.HasData(new Teacher { TeacherId = guid, Name = "Mr. Smith" },
                                     new Teacher { TeacherId = Guid.NewGuid(), Name = "Mrs. Johnson" },
                                     new Teacher { TeacherId = Guid.NewGuid(), Name = "Mrs. Newbie", MentorId = guid });
            });

            modelBuilder.Entity<SubjectOnClass>(soc =>
            {
                soc.HasData(new SubjectOnClass { ClassId = 1, SubjectId = 1, TeacherId = guid, LinkId = 1 },
                            new SubjectOnClass { ClassId = 1, SubjectId = 2, TeacherId = guid, LinkId = 2 },
                            new SubjectOnClass { ClassId = 1, SubjectId = 3, TeacherId = guid, LinkId = 3 },
                            new SubjectOnClass { ClassId = 2, SubjectId = 1, TeacherId = guid, LinkId = 4 });
            });
        }
    }
}
