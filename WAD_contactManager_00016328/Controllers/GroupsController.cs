using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAD_contactManager_00016328.Repositories;
using WAD_contactManager_00016328.Models;

namespace WAD_contactManager_00016328.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // GET: api/groups
        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupRepository.GetAllAsync();
            return Ok(groups);
        }

        // GET: api/groups/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        // POST: api/groups
        [HttpPost]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            await _groupRepository.AddAsync(group);
            return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
        }

        // PUT: api/groups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Group group)
        {
            if (id != group.Id)
                return BadRequest();

            await _groupRepository.UpdateAsync(group);
            return NoContent();
        }

        // DELETE: api/groups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
