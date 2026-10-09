using System.Xml.Serialization;
using LibrarySystem.AppContext;
using LibrarySystem.Models;
using LibrarySystem.Repos.Interfaces;

using LibrarySystem.Repos.Interfaces;
namespace LibrarySystem.UnitOfWorks
{
    public class Unit_Of_Work : IUnitOfWork
    {
        public Unit_Of_Work(IGenericRepo<Category> gc , IMemberRepo mc , IBook bc , IBorrowingRepo brc,AppDbContext db, IUserRepo ur)
        {
            Categories = gc;
            Members = mc;
            Books = bc;
            Borrwings = brc;
            Context = db;
            Users = ur;
        }

        public IUserRepo Users { get; }



        public IGenericRepo<Category> Categories { get;}
        public IMemberRepo Members { get; }

        public IBook Books { get; }
        public IBorrowingRepo Borrwings { get; }
         AppDbContext Context { get; set; }
        
        void IUnitOfWork.Save()
        {
            Context.SaveChanges();
        }
    }
}
