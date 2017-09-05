
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PeopleAndMarksTestTask.Models
{
    public class Mark
    {
        [Key]
        [ForeignKey("Person")]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Value { get; set; }

        public virtual Person Person { get; set; }
    }
}