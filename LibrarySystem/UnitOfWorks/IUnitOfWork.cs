using LibrarySystem.Models;
using LibrarySystem.Repos.Interfaces;

namespace LibrarySystem.UnitOfWorks
{
    public interface IUnitOfWork 
    {
        public IGenericRepo<Category> Categories { get; }
        public IMemberRepo Members{ get; }
        public IBook Books { get; }
        public IGenericRepo<Borrowing> Borrwings { get; }

        void Save();


    }
}
