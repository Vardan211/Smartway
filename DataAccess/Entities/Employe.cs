using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.DataAccess.Entities
{
    public class Employe:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int Companyid { get; set; }
        public Passport Passport { get; set; }
        public Department Department { get; set; }
    }
}
