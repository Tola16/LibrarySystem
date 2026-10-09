using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Dto
{
    public class CreateBookDto
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required, Range(0.01, int.MaxValue)]
        public decimal Price { get; set; }

        public bool IsAvilable { get; set; } = true;
        public int CategoryId { get; set; }

    }
}
