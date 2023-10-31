using AutoMapper;
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetAllEmployeesDetails()
        {
            var records = await _context.employees.ToListAsync();
            return _mapper.Map<List<Employee>>(records);
        }

        public async Task<Employee> GetEmployeesById(int id)
        {
            var employees = await _context.employees.ToListAsync();
            return _mapper.Map<Employee>(employees);
        }
    }
}
