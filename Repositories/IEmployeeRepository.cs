using Smartway.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartway.Repositories
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        public Task<List<Employee>> GetByDepartmentAsync(string name);
        public Task<List<Employee>> GetByCompanyIdAsync(int id);
    }
}
