using Smartway.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartway.Domain
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<List<Employee>> GetByDepartmentAsync(string name);
        public Task<List<Employee>> GetByCompanyIdAsync(int id);
        public Task<int> CreateEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(Employee employee);
    }
}
