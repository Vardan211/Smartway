using Microsoft.AspNetCore.Mvc;
using Smartway.DataAccess.Entities;
using Smartway.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController:Controller
    {
        private readonly IEmployeService _employeService;

        public EmployeesController(IEmployeService employeService)
        {
            _employeService = employeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _employeService.GetAllEmployees();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employe employe)
        {
            await _employeService.CreateEmployeeAsync(employe);
            var result = employe.Id;
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Employe employe)
        {
            await _employeService.DeleteEmployeeAsync(employe);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Change(Employe employe)
        {
            await _employeService.UpdateEmployeeAsync(employe);
            return Ok();
        }
        [HttpGet("get-by-company")]
        public async Task<IActionResult> GetByCompanyId(int id)
        {
            var result = await _employeService.GetByCompanyIdAsync(id);
            return Ok(result);
        }
        [HttpGet("get-by-department")]
        public async Task<IActionResult> GetByDepartment(string name)
        {
            var result = await _employeService.GetByDepartamentAsync(name);
            return Ok(result);
        }
    }
}
