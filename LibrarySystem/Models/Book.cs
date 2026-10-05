using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;
//using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibrarySystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required , Range(0.01 , int.MaxValue)]
        public decimal Price { get; set; }

        public bool IsAvilable { get; set; } = true;

        public Category Category { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategorydId { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }

    }
}
