using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/borrowings")]
    [Authorize]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public BorrowingController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }
        
        
        [HttpGet]
        public IActionResult GetBorrowings()
        {
            var borrowings = _context.Borrwings.GetAllWithMemberAndBook()
                .Select(a => new
                {
                    a.Id,
                    a.BorrowDate,
                    a.ReturnDate,
                    Member = new
                    {
                        a.Member.Id,
                        a.Member.Name,
                        a.Member.Email,
                        a.Member.Phone
                    },
                    Book = new
                    {
                        a.Book.Id,
                        a.Book.Title,
                        a.Book.Author,
                        a.Book.ISBN,
                        a.Book.IsAvilable
                    }
                });

            return Ok(borrowings);
        }

        [HttpPost]
        public IActionResult CreateBorrowing(CreateBorrowingDto borrowing)
        {
            var member = _context.Members.GetById(borrowing.MemberId);
            if (member == null)
            {
                return BadRequest();
            }

            var book = _context.Books.GetById(borrowing.BookId);
            if (book == null)
            {
                return BadRequest();

            }

            if (!book.IsAvilable)
            {
                return BadRequest("UnAvilableBook");
            }

            var newBorrowing = new Borrowing
            {
                MemberId = member.Id,
                BookId = book.Id,
                BorrowDate = DateTime.UtcNow,
                ReturnDate = null
            };

            book.IsAvilable = false;
            _context.Borrwings.Create(newBorrowing);
            _context.Books.Update(book);
            _context.Save();

            return Created();
        }
        [HttpPut("return")]
        public IActionResult ReturnBorrowing(int id)
        {
            var borrowing = _context.Borrwings.GetById(id);

            if (borrowing == null)
                return NotFound();

            ;

            var book = _context.Books.GetById(borrowing.BookId);

            if (book == null)
                return NotFound();

            borrowing.ReturnDate = DateTime.UtcNow;
            book.IsAvilable = true;

            _context.Borrwings.Update(borrowing);
            _context.Books.Update(book);
            _context.Save();

            return NoContent();
        }

    }
}
