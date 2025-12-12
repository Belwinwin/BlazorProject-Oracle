using BlazorProject.Data;
using BlazorProject.Repository.iRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Repository
{
    public class EmployeeRepository : iEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> CreateAsync(Employee obj)
        {
            await _db.Employees.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj=await _db.Employees.FirstOrDefaultAsync(u =>u.Id==id);
            if (obj != null)
            {
                _db.Employees.Remove(obj);
                return (await _db.SaveChangesAsync()) >0;
            }
            return false;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var obj=await  _db.Employees.FirstOrDefaultAsync(u =>u.Id==id);
            if (obj == null)
            {
                return new Employee();
            }
            return obj;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _db.Employees.ToListAsync();

        public async Task<Employee> UpdateAsync(Employee obj)
        {
            var objFromDb= await _db.Employees.FirstOrDefaultAsync(u =>u.Id==obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                _db.Employees.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }

    }
}
