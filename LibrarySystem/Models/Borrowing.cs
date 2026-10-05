using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace LibrarySystem.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime ? ReturnDate{ get; set; }

        public Member Member {  get; set; }
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }   

        public Book Book  { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
    }
}
