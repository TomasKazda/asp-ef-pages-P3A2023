using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_ef_pages.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }

        [Required]
        [MinLength(2)]
        public string StudentName { get; set; } = "";

        public string? StudentEmail { get; set; }

        
        [ForeignKey(nameof(ClassId))]
        public Class? Class { get; set; }

        [Required]
        public int ClassId { get; set; }
    }
}
