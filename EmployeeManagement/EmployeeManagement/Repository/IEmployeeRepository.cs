using EmployeeManagement.Model;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesDetails();
        Task<Employee> GetEmployeesById(int id);
        Task<int> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<Employee> UpdateEmployeePatch(int id, Employee employee);
        Task DeleteEmployee(int id);
    }
}
