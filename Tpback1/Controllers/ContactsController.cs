using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tpback1.Data.Repository.Interfaces;

using Tpback1.Models.Dtos;
using System.Text.Json;
using Tpback1.Entities;
using Tpback1.Data.Repository.Implementations;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Security.Claims;
using AutoMapper;

namespace Tpback1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public ContactController(IContactRepository contactRepository, IMapper autoMapper, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _mapper = autoMapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var contacts = _contactRepository.FindAllNotBlockedByUser(currentUserId);
            var contactDtos = _mapper.Map<List<ContactDto>>(contacts);
            return Ok(contactDtos);
        }






        [HttpGet("blocked")]
        public IActionResult GetAllBlockedByCurrentUser()
        {
            // Obtiene el id del usuario autenticado
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var contacts = _contactRepository.FindAllBlockedByUserWithCalls(userId);
            var blockedContactDtos = _mapper.Map<List<BlockedContactWithCallInfoDto>>(contacts);
            return Ok(blockedContactDtos);
        }





        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {

                var contacto = _contactRepository.GetById(id);

                if (contacto == null)
                {
                    return NotFound();
                }

                var contactoDto = _mapper.Map<CreateAndUpdateContact>(contacto);

                return Ok(contactoDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContact createContactDto)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                _contactRepository.Create(createContactDto, userId);
                return Created("Created", createContactDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, CreateAndUpdateContact dto)
        {
            try
            {
                var contactoItem = _contactRepository.GetById(id);

                if (contactoItem == null)
                {
                    return NotFound();
                }



                _mapper.Map(dto, contactoItem);

                _contactRepository.UpdateContact(contactoItem);

                var contactoModificado = _contactRepository.GetById(id);

                var contactoModificadoDto = _mapper.Map<CreateAndUpdateContact>(contactoModificado);

                return Ok(contactoModificadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }








        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteContactById(int id)
        {
            try
            {
                var contactToDelete = _contactRepository.GetById(id);

                if (contactToDelete == null)
                { return NotFound($"Contact with Id = {id} not found"); }

                _contactRepository.Delete(id);
                return Ok("contact deleted");
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost("block/{id}")]
        public IActionResult BlockContact(int id)
        {
            try
            {
                _contactRepository.BlockContact(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unblock/{id}")]
        public IActionResult UnblockContact(int id)
        {
            try
            {
                _contactRepository.UnblockContact(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getcall/{contactId}")]
        public IActionResult GetCallByContactId(int contactId)
        {
            var call = _contactRepository.GetCallByContactId(contactId);

            if (call == null)
            {
                return NotFound("No se encontró ninguna llamada con el ID de contacto proporcionado.");
            }

            var callInfoDto = _mapper.Map<CallInfoDto>(call);

            return Ok(callInfoDto);
        }


        [HttpDelete("deletecalls/{contactId}")]
        public IActionResult DeleteCallsByContactId(int contactId)
        {
            try
            {
                _contactRepository.DeleteCallsByContactId(contactId);
                return Ok("Se eliminaron las llamadas asociadas al ID de contacto proporcionado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}