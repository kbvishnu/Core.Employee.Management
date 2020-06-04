using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Corp.EmployeeManagement.DL.Repository;
using Corp.EmployeeManagement.DL.Context;

namespace Corp.EmployeeManagement.BL
{
    public interface IValidators
    {
        List<EmployeeModel> ValidateEmployeeDetailsAsync(List<EmployeeModel> EmployeeModel) ;
    }

    public class Validators: IValidators
    {
        public List<EmployeeModel> ValidateEmployeeDetailsAsync(List<EmployeeModel> employees) {
            var failedEmployees =new List<EmployeeModel>();
            
            foreach(var employee in employees)
            {
                StringBuilder errors= new StringBuilder();
                if(!employee.Age.HasValue )
                    errors.Append("age ");
                if(string.IsNullOrEmpty(employee.Contact))
                    errors.Append("contact ");
                if(string.IsNullOrEmpty(employee.BloodGroup))
                    errors.Append("blood group ");
                if(string.IsNullOrEmpty(employee.Name))
                    errors.Append("name ");
                if(errors.Length>0)
                employee.Errors = $"The details { errors.ToString() } were not found.";
                    failedEmployees.Add(employee);
                
            }
            return failedEmployees;
        }
    }


     public interface IEmployeeBL
    {
         Task SaveEmployeesAsync(List<EmployeeModel> employees);
         Task<List<EmployeeModel>> SearchEmployeesAsync(EmployeeModel employee);
         Task GetAllEmployeesAsync(List<EmployeeModel> employees);
    }

    public class EmployeeBL{

        private IEmployeeRepository _repo;
        private IMapper _mapper;
        public EmployeeBL(IEmployeeRepository repo,IMapper mapper)
        {
            _repo=repo; 
            _mapper=mapper;
        }
        public async Task SaveEmployeesAsync(List<EmployeeModel> employees)
        {
            foreach(var employee in employees)
                await _repo.SaveEmployeeAsync(_mapper.Map<Employee>(employee));
                
        }
        public async Task<List<EmployeeModel>> SearchEmployeesAsync(EmployeeModel employee)
        {
            var employees= await _repo.SearchEmployeesAsync(_mapper.Map<Employee>(employee));
            return _mapper.Map<List<EmployeeModel>>(employees);
        }
        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var employees= await _repo.GetEmployeesAsync();
            return _mapper.Map<List<EmployeeModel>>(employees);
        }
    }
}
