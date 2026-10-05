using LibrarySystem.Models;

namespace LibrarySystem.Repos.Interfaces
{
    public interface IBook : IGenericRepo<Book>
    {
        public ICollection<Book> Search(string Name);
        public ICollection<Book> HighestPrice();
    }
}
