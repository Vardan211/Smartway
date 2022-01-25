using System.ComponentModel.DataAnnotations;

namespace Smartway.DataAccess.Entities
{
    public class Employee : BaseEntity
    {
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Surname { get; set; }
        
        [RegularExpression(@"(\+7)?[0-9]{10}")]
        public string Phone { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? PassportId { get; set; }
        public Passport Passport { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
