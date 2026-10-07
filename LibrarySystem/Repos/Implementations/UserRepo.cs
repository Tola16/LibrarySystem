using LibrarySystem.AppContext;
using LibrarySystem.Models;
using LibrarySystem.Repos.Interfaces;

namespace LibrarySystem.Repos.Implementations
{
    public class UserRepo : GenericRepo<User> , IUserRepo
    {
        private AppDbContext _context;
        public UserRepo(AppDbContext d) : base(d) 
        {
            _context = d;
        }
        public User GetByName(string username)
        { 
           return _context.users.FirstOrDefault(a=>a.Name == username);   
        }
    }
}
