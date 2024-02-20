using System.ComponentModel.DataAnnotations;

namespace asp_ef_pages.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<SubjectOnClass> Subjects { get; set; }

        public ICollection<Subject> Subjects2 { get; set; }
    }
}
