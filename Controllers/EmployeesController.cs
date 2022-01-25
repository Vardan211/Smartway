using Microsoft.AspNetCore.Mvc;
using Smartway.DataAccess.Entities;
using Smartway.Domain;
using System.Threading.Tasks;

namespace Smartway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController:Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var result = await _employeeService.CreateEmployeeAsync(employee);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetAllEmployees();
            return Ok(result);
        }

        [HttpGet("by-company")]
        public async Task<IActionResult> GetByCompanyId(int id)
        {
            var result = await _employeeService.GetByCompanyIdAsync(id);
            return Ok(result);
        }
        
        [HttpGet("by-department")]
        public async Task<IActionResult> GetByDepartment(string name)
        {
            var result = await _employeeService.GetByDepartmentAsync(name);
            return Ok(result);
        }
        [HttpGet("by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> Change(Employee employee)
        {
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(Employee employee)
        {
            await _employeeService.DeleteEmployeeAsync(employee);
            return Ok();
        }
    }
}
