using System.ComponentModel.DataAnnotations;

namespace PeopleListAPI.Models
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage ="First Name is Required.")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
