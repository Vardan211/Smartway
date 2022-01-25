using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.DataAccess.Entities
{
    public class Passport:BaseEntity
    {
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Type { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        public string Number { get; set; }
    }
}
