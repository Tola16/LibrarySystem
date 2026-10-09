using LibrarySystem.AppContext;
using LibrarySystem.Models;
using LibrarySystem.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Repos.Implementations
{
    public class BookRepo : GenericRepo<Book>, IBook
    {
        private AppDbContext _context;
        public BookRepo(AppDbContext _Context) : base(_Context)
        {
            _context = _Context;
        }

        public ICollection <Book> Search(string name)
        {
            var a = _context.books.Where(a => a.Title.Contains(name) || a.Author.Contains(name)).ToList();
            return a;
        }
        public Book? HighestPrice()
        {
            return _context.books
                .OrderByDescending(book => book.Price)
                .FirstOrDefault();
        }
    }
}
