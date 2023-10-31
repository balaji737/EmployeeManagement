using EmployeeManagement.Model;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesDetails();
    }
}
