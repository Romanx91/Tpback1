using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tpback1.Data.Repository.Interfaces;

using Tpback1.Models.Dtos;
using System.Text.Json;
using Tpback1.Entities;
using Tpback1.Data.Repository.Implementations;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Tpback1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;

        public ContactController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetAllByUser(userId));
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOne(int Id)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetAllByUser(userId).Where(x => x.Id == Id));
        }


        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContact createContactDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _contactRepository.Create(createContactDto, userId);
            return Created("Created", createContactDto);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContact updatetDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _contactRepository.Update(updatetDto, userId);


            
            return Ok(updatetDto);
        }

        [HttpDelete]
        public IActionResult DeleteContactById(int id)
        {
            try
            {
                _contactRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    }
}
