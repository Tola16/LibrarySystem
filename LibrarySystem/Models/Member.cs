using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public ICollection<Borrowing> Members { get; set; }
    }
}
