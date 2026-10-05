using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<Book> Books{ get; set; }

    }
}
