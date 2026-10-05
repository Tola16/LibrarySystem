using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Dto
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

    }
}
