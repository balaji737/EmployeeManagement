using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPost]
        public async Task<IActionResult> AddNewEmployee([FromBody] Employee employee)
        {
            try
            {
                var newEmployeeId = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployeeId, Controller = "Employee" }, newEmployeeId);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid request data");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllElementsInEmployee([FromBody] Employee employee, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedEmployee = await _employeeRepository.EntireResourceUpdateInEmployee(id, employee);

                if (updatedEmployee == null)
                {
                    return NotFound();
                }

                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing the request.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateParticularElementInEmployee([FromRoute] int id, [FromBody] JsonPatchDocument<Employee> employee)
        {
            if (employee == null)
            {
                return BadRequest(employee);
            }

            var updatedEmployee = await _employeeRepository.PartialResourceUpdateInEmployee(id, employee);

            if (updatedEmployee == null)
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
