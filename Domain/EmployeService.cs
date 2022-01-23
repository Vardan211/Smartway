using Smartway.DataAccess.Entities;
using Smartway.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.Domain
{
    public class EmployeService : IEmployeService
    {
        private readonly IEmployeRepository _employeRepository;

        public EmployeService(IEmployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }
        public async Task<int> CreateEmployeeAsync(Employe employe)
        {
            return await _employeRepository.CreateAsync(employe);
        }

        public async Task<int> DeleteEmployeeAsync(Employe employe)
        {
            return await _employeRepository.DeleteAsync(employe);
        }

        public async Task<List<Employe>> GetAllEmployees()
        {
            return await _employeRepository.GetAllAsync();
        }

        public async Task<List<Employe>> GetByCompanyIdAsync(int id)
        {
            return await _employeRepository.GetByCompanyIdAsync(id);
        }

        public Task<List<Employe>> GetByDepartamentAsync(string name)
        {
            return _employeRepository.GetByDepartamentAsync(name);
        }

        public async Task<Employe> GetEmployeById(int id)
        {
            return await _employeRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateEmployeeAsync(Employe employe)
        {
            return await _employeRepository.UpdateAsync(employe);
        }
    }
}
