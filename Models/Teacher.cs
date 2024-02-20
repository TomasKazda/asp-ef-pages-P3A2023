using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        public ICollection<Teacher> Mentoring { get; set; }
        [ForeignKey("MentorId")]
        public Teacher? Mentor { get; set; }
        public Guid? MentorId { get; set; }
    }
}
