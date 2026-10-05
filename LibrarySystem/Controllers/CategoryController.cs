using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _context;
        public CategoryController(IUnitOfWork a) { _context = a; }

        [HttpGet]
        public ActionResult GetAll()
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
            _context.Categories.Delete(a);
            return NoContent();

        }

    }
}
