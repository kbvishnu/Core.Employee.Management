
using Xunit;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Corp.EmployeeManagement.DL.Context;
using Corp.EmployeeManagement.DL.Repository;
namespace Corp.EmployeeManagement.DL.Tests
{
    public class EmployeeRepositoryTest
    {
        private Mock<IEmployeeRepository> _employeeRepository;
        private List<Employee> _employeeDB;
        
        public EmployeeRepositoryTest()
        {
            _employeeRepository= new Mock<IEmployeeRepository>();
           _employeeDB= new List<Employee>()
           {
               new Employee(){
                 ID=1, Name="Krishna", Age=20, BloodGroup="B+", Contact="1234567890"
               },
               new Employee(){
                 ID=2, Name="Radha", Age=22, BloodGroup="AB+", Contact="4561237890"
               },
               new Employee(){
                  ID=3, Name="Rama", Age=23, BloodGroup="A+", Contact="6781234590"
               },
               new Employee(){
                   ID=4, Name="Seetha", Age=24, BloodGroup="B-", Contact="1237890456"
               },
               new Employee(){
                   ID=5, Name="Ravan", Age=25, BloodGroup="AB-+", Contact="6789012345"
               }

           };
           
           _employeeRepository.Setup(repo =>
            repo.GetEmployeesAsync()).ReturnsAsync(_employeeDB);
            
             _employeeRepository.Setup(repo =>
            repo.SearchEmployeesAsync(It.IsAny<Employee>()))
            .ReturnsAsync((Employee employee) => 
            _employeeDB.Where(emp => emp.Name.StartsWith(employee.Name)).ToList());

             _employeeRepository.Setup(repo =>
            repo.SaveEmployeeAsync(It.IsAny<Employee>())).Callback((Employee employee) =>
                {
                employee.ID = _employeeDB.Count + 1;
                _employeeDB.Add(employee);
                });

              
        }
      
         
        [Fact]
        public async Task GetEmployeesAsyncTest()
        {
        // Arrange
            const int expected = 5;
            
        // Act
            var employeeDetail = await _employeeRepository.Object.GetEmployeesAsync();
        // Assert
            Assert.Equal(expected, employeeDetail.Count);
        }

        [Fact]
        public async Task SearchEmployeesAsyncTest()
        {
        // Arrange
            const int expected = 3;
            
        // Act
            var employeeDetail = await _employeeRepository.Object.SearchEmployeesAsync(new Employee(){ Name="Ra"});
        // Assert
            Assert.Equal(expected, employeeDetail.Count);
        }

         [Fact]
        public async Task SaveEmployeeAsyncTest()
        {
        // Arrange
            const int expected = 6;
            
        // Act
             await _employeeRepository.Object.SaveEmployeeAsync
            (new Employee(){ Name="Raghav", ID=6, BloodGroup="O+",Contact="457896321"});
        // Assert
            Assert.Equal(expected, _employeeDB.Count);
        }
    }
}
