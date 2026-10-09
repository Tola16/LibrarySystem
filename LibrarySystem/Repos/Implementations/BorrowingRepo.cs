using LibrarySystem.AppContext;
using LibrarySystem.Models;
using LibrarySystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repos.Implementations
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly AppDbContext _context;

        public BorrowingRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Borrowing> GetAllWithMemberAndBook()
        {
            return _context.borrowings
                .Include(a => a.Member)
                .Include(a => a.Book)
                .OrderByDescending(a => a.BorrowDate)
                .ToList();
        }
    }
}
