using Azure.Core.Pipeline;
using LibrarySystem.AppContext;
using LibrarySystem.Models;
using LibrarySystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibrarySystem.Repos.Implementations
{
    public class MemberRepo : GenericRepo<Member> ,  IMemberRepo
    {
        private readonly AppDbContext _context;
        public MemberRepo(AppDbContext Context)  : base(Context)
        {
            _context = Context;
        }

        public  ICollection<Member> TopReaders()
        {
            var a = _context.members.OrderByDescending(a=>a.Members.Count).Take(5).ToList();
            return a;
        }
    }
}
