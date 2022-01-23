using Smartway.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.Repositories
{
    public interface IEmployeRepository:IRepository<Employe>
    {
        public Task<List<Employe>> GetByDepartamentAsync(string name);
        public Task<List<Employe>> GetByCompanyIdAsync(int id);
    }
}
