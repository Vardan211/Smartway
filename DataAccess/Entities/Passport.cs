using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.DataAccess.Entities
{
    public class Passport:BaseEntity
    {
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
