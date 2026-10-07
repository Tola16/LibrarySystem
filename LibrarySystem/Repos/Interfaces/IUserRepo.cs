using LibrarySystem.Models;

namespace LibrarySystem.Repos.Interfaces
{
    public interface IUserRepo : IGenericRepo<User>
    {
        public User GetByName (string username);
    }

}
