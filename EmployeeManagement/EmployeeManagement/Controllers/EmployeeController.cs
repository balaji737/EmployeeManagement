using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesDetails();
            if (employees != null && employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employees = await _employeeRepository.GetEmployeesById(id);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost()]
        public async Task<IActionResult> AddNewEmployee([FromBody] Employee employee)
        {
            try
            {
                var newEmployeeId = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new {id = newEmployeeId });
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeUsingPut([FromBody] Employee employee, [FromRoute] int id)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployee(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployeeUsingPatch([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedEmployee = await _employeeRepository.UpdateEmployeePatch(id, employee);

            if(updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
