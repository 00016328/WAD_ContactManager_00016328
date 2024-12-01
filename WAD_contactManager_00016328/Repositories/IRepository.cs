using System.Collections.Generic;
using System.Threading.Tasks;

namespace WAD_contactManager_00016328.Repositories
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}