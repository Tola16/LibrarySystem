using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Dto
{
    public class CreateBorrowingDto
    {
        [Range(1, int.MaxValue)]
        public int MemberId { get; set; }

        [Range(1, int.MaxValue)]
        public int BookId { get; set; }
    }
}
