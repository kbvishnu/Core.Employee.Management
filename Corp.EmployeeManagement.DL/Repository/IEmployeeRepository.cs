using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Corp.EmployeeManagement.DL;
using Corp.EmployeeManagement.DL.Context;
namespace Corp.EmployeeManagement.DL.Repository
{
    public interface IEmployeeRepository
    {
        Task SaveEmployeeAsync(Employee employee);
        Task<List<Employee>> GetEmployeesAsync();
        Task<List<Employee>> SearchEmployeesAsync(Employee employee);
        
    }
}