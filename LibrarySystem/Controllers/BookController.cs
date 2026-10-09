//using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;
using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
     [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _Context;
        public BookController(IUnitOfWork context)
        {
            _Context = context;
        }
        [HttpGet]
        public IActionResult Search(string Keaword)
        {
           var a =    _Context.Books.Search(Keaword).Select(a=> new
            {
                a.Id ,  
                a.Title ,
                a.Author ,
                a.Price 
            });
            
            return Ok(a);

        }

        [HttpPost]
        public IActionResult Create(CreateBookDto book)
        {
            var newbook = new Book
            {
                //Id = book.Id ,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                 ISBN = book.ISBN,
                  CategorydId = book.CategoryId ,


            };
            _Context.Books.Create(newbook);
            _Context.Save();
            return  Created ();
        }
        [HttpGet("Highest")]
        public IActionResult HighestPrice()
        {
            var a = _Context.Books.HighestPrice();
            return Ok(a); 
        }

    }
}
