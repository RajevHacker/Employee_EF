using Employee_EF.Data;
using Employee_EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_EF.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _dbContext = employeeDbContext;
        }
        [Route("Employee/Get")]
        [HttpGet()]
        public List<Employee> GetEmployeeDetails()
        {
            var res = _dbContext.Employees.ToList();
            Console.WriteLine("test Message");
            return res;
        }
        [Route("Employee/InsertNewEmployee")]
        [HttpPost()]
        public string InsertEmployeeDetails([FromHeader] string EmployeeName, [FromHeader] string Email, 
                                                [FromHeader] string phone)
        {
            var emp = new Employee()
            {
                EmployeeName=EmployeeName,
                Email = Email,
                phone = phone
            };
            Console.WriteLine("test message");
            var Employee = _dbContext.Employees.Add(emp);
            _dbContext.SaveChanges();
            return "Employee Details Inserted successfully";
        }
        [Route("Employee/UpdateEmployeeDetail")]
        [HttpPatch()]
        public Employee UpdateEmployeeDetails([FromHeader] string EmployeeName, [FromHeader] string Email, 
            [FromHeader] string phone, [FromHeader] int E_No)
        {
            var employe = _dbContext.Employees.Find(E_No);
            employe.EmployeeName = EmployeeName;
            employe.phone = phone;
            employe.Email = Email;
            _dbContext.SaveChanges();
            return employe;
        }
        [Route("Employee/DeleteEmployeeDetail")]
        [HttpDelete()]
        public Employee DeleteEmployeeDetails([FromHeader] int E_No, [FromHeader] string EmployeeName)
        {
            /* Query with condition and update
            public List<Employee> DeleteEmployeeDetails([FromHeader] int E_No, [FromHeader] string EmployeeName)
            {
            var emp = _dbContext.Employees.Where(e => e.EmployeeName == "HelloWorld").ToList();
            foreach (var temp in emp)
            {
                temp.EmployeeName = "Rajev";
            }
            _dbContext.SaveChanges();

            return emp;
            }*/
            
            var employe = _dbContext.Employees.Find(E_No);
            _dbContext.Employees.Remove(employe);
            _dbContext.SaveChanges();
            return employe;
        }
    }
}