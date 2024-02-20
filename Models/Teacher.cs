using System.ComponentModel.DataAnnotations;

namespace asp_ef_pages.Models
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<SubjectOnClass> Subjects { get; set; }
    }
}
