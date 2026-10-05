using LibrarySystem.Models;

namespace LibrarySystem.Repos.Interfaces
{
    public interface IMemberRepo : IGenericRepo<Member>
    {
        public ICollection<Member> TopReaders();

    }
}
