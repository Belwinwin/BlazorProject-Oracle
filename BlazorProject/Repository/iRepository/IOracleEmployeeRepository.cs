using BlazorProject.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Repository.iRepository
{
    public interface IOracleEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<int> AddAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
        Task<int> DeleteAsync(int id);
    }
}
