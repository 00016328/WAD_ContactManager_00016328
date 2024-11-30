using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAD_contactManager_00016328.Models;
using WAD_contactManager_00016328.Repositories;

namespace WAD_contactManager_00016328.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id)
                return BadRequest();

            await _contactRepository.UpdateAsync(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
