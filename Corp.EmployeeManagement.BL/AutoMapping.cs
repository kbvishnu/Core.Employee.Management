using AutoMapper;
using Corp.EmployeeManagement.BL;
using Corp.EmployeeManagement.DL.Context;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<EmployeeModel, Employee>();
        CreateMap<Employee,EmployeeModel>().ForMember(mem => mem.Errors, t => t.Ignore());
    }
}