using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWorks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibrarySystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IUnitOfWork _Context;
        public MemberController(IUnitOfWork unitOfWork)
        {
            _Context = unitOfWork;
        }

        [HttpPost]
        public IActionResult CreateMember(CreateMemberDto member)
        {
            var newMember = new Member
            {
                Email = member.Email,
                Name = member.Name,
                Phone = member.Phone,
            };
            _Context.Members.Create(newMember);
            _Context.Save();
            return Created();
        }
        [HttpGet]
        public IActionResult TopReaders()
        {
            var a = _Context.Members.TopReaders();
            return Ok(a);
        }

    }
}
