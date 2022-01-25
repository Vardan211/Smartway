using Smartway.DataAccess.Entities;
using Smartway.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartway.Domain
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.CreateAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<List<Employee>> GetByCompanyIdAsync(int id)
        {
            return await _employeeRepository.GetByCompanyIdAsync(id);
        }

        public Task<List<Employee>> GetByDepartmentAsync(string name)
        {
            return _employeeRepository.GetByDepartmentAsync(name);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.UpdateAsync(employee);
        }
    }
}
