using System.Reflection.Metadata;
using LibrarySystem.AppContext;
using LibrarySystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repos.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> db { get; set; }
        public GenericRepo(AppDbContext _Context)
        {
            _context = _Context;

            db = _context.Set<T>();

        }

        public void Create(T entity)
        {
            db.Add(entity);


        }

        public void Delete(T entity)
        {
            db.Remove(entity);
        }

        public List<T> GetAll()
        {
            return db.ToList();
        }

        public T GetById(int id)
        {
            return db.Find(id);
        }

        public void Update(T entity)
        {
            db.Update(entity);
        }
    }
}
