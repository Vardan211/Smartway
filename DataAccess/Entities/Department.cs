using System.ComponentModel.DataAnnotations;

namespace Smartway.DataAccess.Entities
{
    public class Department:BaseEntity
    {
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Name { get; set; }

        [RegularExpression(@"(\+7)?[0-9]{10}")]
        public string Phone { get; set; }
    }
}
