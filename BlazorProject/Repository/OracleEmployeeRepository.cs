using BlazorProject.Data;
using BlazorProject.Repository.iRepository;
using BlazorProject.Services;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorProject.Repository
{
    public class OracleEmployeeRepository : iEmployeeRepository, IOracleEmployeeRepository
    {
        private readonly DatabaseConnectionService _dbConnectionService;

        public OracleEmployeeRepository(DatabaseConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }

        private OracleConnection CreateConnection() => new OracleConnection(_dbConnectionService.GetConnectionString());

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            const string sql = "SELECT ID, NAME, EMAIL, ROLE, PHONENUMBER FROM EMPLOYEEDETAILS";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            var rows = await conn.QueryAsync<Employee>(sql);
            return rows;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            const string sql = "SELECT ID, NAME, EMAIL, ROLE, PHONENUMBER FROM EMPLOYEEDETAILS WHERE ID = :Id";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(Employee employee)
        {
            const string sql = "INSERT INTO EMPLOYEEDETAILS (NAME, EMAIL, ROLE, PHONENUMBER) VALUES (:Name, :Email, :Role, :PhoneNumber)";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.ExecuteAsync(sql, employee);
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            const string sql = "UPDATE EMPLOYEEDETAILS SET NAME = :Name, EMAIL = :Email, ROLE = :Role, PHONENUMBER = :PhoneNumber WHERE ID = :Id";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.ExecuteAsync(sql, employee);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM EMPLOYEEDETAILS WHERE ID = :Id";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.ExecuteAsync(sql, new { Id = id });
        }

        // Interface methods
        public async Task<Employee> CreateAsync(Employee obj)
        {
            await AddAsync(obj);
            return obj;
        }

        async Task<Employee> iEmployeeRepository.UpdateAsync(Employee obj)
        {
            await UpdateAsync(obj);
            return obj;
        }

        async Task<bool> iEmployeeRepository.DeleteAsync(int id)
        {
            var result = await DeleteAsync(id);
            return result > 0;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var result = await GetByIdAsync(id);
            return result ?? new Employee();
        }
    }
}
