using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//route for the controller level
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext  _fullStackDbContext;//constructor

        public EmployeesController(FullStackDbContext fullStackDbContext)//controller
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]//client
        public async Task<IActionResult> GetAllEmployees()//this makes a function asynchronous
        {
           var employees = await _fullStackDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]//add an Employee
        public async Task<IActionResult> AddEmployee([FromBody]Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();//create new id

            await _fullStackDbContext.Employees.AddAsync(employeeRequest);//here we use async func that the add await 
            await _fullStackDbContext.SaveChangesAsync();//For Save Changes

            return Ok(employeeRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute]Guid id)
        {
            var emplouee =
               await _fullStackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id); 
            if (emplouee == null)
            {
                return NotFound();
            }

            return Ok(emplouee);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }
            employee.Name= updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;

            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employee);

            


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Employees.Remove(employee);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
