using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PeopleAndMarksTestTask.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Index("IX_LastAndFirstName", 1, IsUnique = true)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Index("IX_LastAndFirstName", 2, IsUnique = true)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        public virtual Mark Mark { get; set; }

    }
}