using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD_contactManager_00016328.DTOs;
using WAD_contactManager_00016328.Models;
using WAD_contactManager_00016328.Repositories;

namespace WAD_contactManager_00016328.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public ContactsController(
            IRepository<Contact> contactRepository,
            IRepository<Group> groupRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactRepository.GetAllAsync();
            var contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(contactDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            var contactDto = _mapper.Map<ContactDto>(contact);
            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.CreateAsync(contact);

            var createdContactDto = _mapper.Map<ContactDto>(contact);
            return CreatedAtAction(nameof(GetById), new { id = createdContactDto.Id }, createdContactDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactDto contactDto)
        {
            if (id != contactDto.Id)
            {
                return BadRequest();
            }

            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.UpdateAsync(contact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            await _contactRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
