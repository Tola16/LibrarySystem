using LibrarySystem.Models;

namespace LibrarySystem.Repos.Interfaces
{
    public interface IBorrowingRepo : IGenericRepo<Borrowing>
    {
        List<Borrowing> GetAllWithMemberAndBook();
    }
}
