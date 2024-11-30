using WAD_contactManager_00016328.Models;

namespace WAD_contactManager_00016328.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(int id);
        Task AddAsync(Group group);
        Task UpdateAsync(Group group);
        Task DeleteAsync(int id);
    }
}
