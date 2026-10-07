using System.Security.Permissions;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Identity.Client;

namespace LibrarySystem.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options ) : base (options)
        {
            
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Borrowing> borrowings { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Member> members { get; set; }

        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(a => a.Name).IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, 
                    Name = "Dola",
                     PassWordHash = "SecretPass"
                }
                ,new User
                {
                    Id = 2, 
                    Name = "Adel",
                     PassWordHash = "SecretPass2"
                }
                );
            
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Programming and software\r\ndevelopment books"
                }, new Category
                {
                    Id = 2,
                    Name = "DataBase",
                    Description = "Database and data management\r\n\r\nbooks"
                }

                );

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    Name = "Ahmed Hassan ",
                    Email = "ahmed@example.com",
                    Phone = "01198765432"
                },
                new Member
                {
                    Id = 2,
                    Name = "Sara Mohamed ",
                    Phone = "01012345678",
                    Email = "Sara@example.com"
                }
                );
            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    Id = 1,
                    Title = "C++ Basics ",
                    Author = "John Smith",
                    ISBN = "ISBN001",
                    IsAvilable = true,
                    Price = 450,
                    CategorydId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Sql Fundementals",
                    Author = "Sarah Ali ",
                    ISBN = "ISBN002",
                    IsAvilable = false,
                    Price = 500,
                    CategorydId = 2
                }


                );
            modelBuilder.Entity<Borrowing>().HasData(

                new Borrowing
                {
                     Id = 1, 
                      BookId =1 , 
                       BorrowDate = new DateTime(2026,9,20  ),
                        ReturnDate= new DateTime(2026, 9, 25),
                         MemberId = 1,
                },
                new Borrowing
                {
                     Id = 2, 
                     BookId =2 ,
                    BorrowDate = new DateTime(2026, 9, 22),
                    MemberId = 2,
                }


                );

            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(a=>a.ISBN).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(a=>a.Price).IsUnique();

            modelBuilder.Entity<Category>().HasMany(a => a.Books).WithOne(a => a.Category).HasForeignKey(a => a.CategorydId);
            modelBuilder.Entity<Book>().HasMany(a => a.Borrowings).WithOne(a => a.Book).HasForeignKey(a => a.BookId);
            modelBuilder.Entity<Borrowing>().HasOne(a => a.Book).WithMany(a => a.Borrowings).HasForeignKey(a => a.BookId);
        }
    }
}
