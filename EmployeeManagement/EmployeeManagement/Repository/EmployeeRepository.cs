﻿using AutoMapper;
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
            return records;
        }

        public async Task<Employee> GetEmployeesById(int id)
        {
            var employeesInfo = await _context.employees.FindAsync(id);
            return _mapper.Map<Employee>(employeesInfo);
           
        }

        public async Task<bool> GetUniqueEmployee(string name)
        {
            return await _context.employees.AnyAsync(employees => employees.Name == name);
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            if(await GetUniqueEmployee(employee.Name))
            {
                throw new Exception("Employee with similar name already exists.");
            }
            employee.CreatedDate = DateTime.Now;

            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var currentEmployee = await _context.employees.FindAsync(id);

            if(currentEmployee == null)
            {
                return null;
            }
            employee.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return _mapper.Map<Employee>(currentEmployee);
        }

        public async Task<Employee> UpdateEmployeePatch(int id, Employee employee)
        {
            var updatedEmployee = await _context.employees.FindAsync(id);

            if (updatedEmployee == null)
            {
                return null;
            }
            if(employee.Department != null)
            {
                updatedEmployee.Department = employee.Department;
                updatedEmployee.UpdatedDate = DateTime.Now;
            }
            return updatedEmployee;
        }

        public async Task DeleteEmployee(int id)
        {
            var curentEmployee = await _context.employees.FindAsync(id);

            if (curentEmployee != null)
            {
                _context.employees.Remove(curentEmployee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Employee with ID {id} not found");
            }
        }
    }
}
