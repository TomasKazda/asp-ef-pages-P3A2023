using System.ComponentModel.DataAnnotations;

namespace asp_ef_pages.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(4)]
        public string ShortName { get; set; }
        public string Name { get; set; }
        public ICollection<SubjectOnClass> Classes { get; set; }

        public ICollection<Class> Classes2 { get; set; }
    }
}
