using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Corp.EmployeeManagement.DL;
using Corp.EmployeeManagement.DL.Context;
namespace Corp.EmployeeManagement.DL.Repository
{
public class EmployeeRepository: IEmployeeRepository
    {
        private EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext= employeeDbContext;
        }
        public async Task SaveEmployeeAsync(Employee employee){
            try
            {
               await _employeeDbContext.AddAsync(employee);
               await _employeeDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }
        public Task<List<Employee>> GetEmployeesAsync(){
            try
            {
                 return _employeeDbContext.Employees.AsQueryable().ToListAsync();                               
            }
            catch
            {
                throw;

            }
        }
        public Task<List<Employee>> SearchEmployeesAsync(Employee employee){
            try
            {
               
                IQueryable<Employee> _employee=  _employeeDbContext.Employees
                 .Where(emp => emp.Name.StartsWith(employee.Name)); 
                 return  _employee.AsQueryable().ToListAsync();             
            }
            catch
            {
                throw;
            }
        }
        
    }
}