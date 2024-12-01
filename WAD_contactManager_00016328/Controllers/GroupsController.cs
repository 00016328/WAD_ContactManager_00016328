using Microsoft.AspNetCore.Mvc;
using WAD_contactManager_00016328.Models;
using WAD_contactManager_00016328.Repositories;

namespace WAD_contactManager_00016328.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IRepository<Group> _repository;

        public GroupsController(IRepository<Group> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Group>> GetAllItems()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var group = await _repository.GetByIdAsync(id);
            return group == null ? NotFound() : Ok(group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Group group)
        {
            if (group.Id == id)
            {
                await _repository.UpdateAsync(group);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Group group)
        {
            await _repository.CreateAsync(group);
            return CreatedAtAction(nameof(GetByID), new { id = group.Id }, group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
