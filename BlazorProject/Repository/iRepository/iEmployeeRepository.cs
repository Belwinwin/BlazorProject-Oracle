using BlazorProject.Data;

namespace BlazorProject.Repository.iRepository
{
    public interface iEmployeeRepository
    {
        public Task<Employee> CreateAsync(Employee obj);
        public Task<Employee> UpdateAsync(Employee obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Employee> GetAsync(int id);
        public Task<IEnumerable<Employee>> GetAllAsync();

    }
}
