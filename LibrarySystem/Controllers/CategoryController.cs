using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _context;
        public CategoryController(IUnitOfWork a) { _context = a; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var a = _context.Categories.GetAll().Select(a => new
            {
                a.Name,
                a.Books.Count
            });
            return Ok(a);
        }

        [HttpPost]
        public IActionResult CreateCategory (CreateCategoryDto category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description,

            };
            _context.Categories.Create(newCategory);
            _context.Save();
            return Created();
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var a = _context.Categories.GetById(id);

            var IsHasBooks = _context.Books.GetAll().Any(book => book.CategorydId== id);
            if (IsHasBooks)
            {
                return BadRequest("This Category Has Book");
            }
            _context.Categories.Delete(a);
            return NoContent();

        }

    }
}
