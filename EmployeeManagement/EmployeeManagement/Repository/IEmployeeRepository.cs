using EmployeeManagement.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesDetails();
        Task<Employee> GetEmployeesById(int id);
        Task<int> AddEmployee(Employee employee);
        Task<Employee> EntireResourceUpdateInEmployee(int id, Employee employee);
        Task<Employee> PartialResourceUpdateInEmployee(int id, JsonPatchDocument<Employee> employee);
        Task DeleteEmployee(int id);
    }
}
