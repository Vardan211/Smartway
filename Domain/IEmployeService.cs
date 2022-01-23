using Smartway.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.Domain
{
    public interface IEmployeService
    {
        public Task<List<Employe>> GetAllEmployees();
        public Task<Employe> GetEmployeById(int id);
        public Task<List<Employe>> GetByDepartamentAsync(string name);
        public Task<List<Employe>> GetByCompanyIdAsync(int id);
        public Task<int> CreateEmployeeAsync(Employe employe);
        public Task<int> UpdateEmployeeAsync(Employe employe);
        public Task<int> DeleteEmployeeAsync(Employe employe);

    }
}
