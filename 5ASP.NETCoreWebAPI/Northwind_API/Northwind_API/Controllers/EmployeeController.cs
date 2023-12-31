using Microsoft.AspNetCore.Mvc;
using Northwind_API.Entities;
using Northwind_API.Models;
using Northwind_API.Repositories;
using Northwind_API.UnitOfWork;
using Repository;



[ApiController]
[Route("/api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    NorthwindContext context = new NorthwindContext();

    private readonly IUnitOfWork _unitOfWork;


    public EmployeeController(IUnitOfWork unitOfWork, EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    // GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
    {
        var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
        var employeeDTOs = employees.Select(e => new EmployeeDTO
        {
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,
        }).ToList();

        return Ok(employeeDTOs);
    }

    // CREATE 
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Employee>>> CreateEmployee(Employee employee)
    {
        await _unitOfWork.EmployeeRepository.InsertAsync(employee);
        //return Ok(employee);
        return CreatedAtAction(nameof(_unitOfWork.EmployeeRepository.GetByIdAsync), new { id = employee.EmployeeId }, employee);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return BadRequest();
        }

        var result = await _unitOfWork.EmployeeRepository.SaveAsync(employee, e => e.EmployeeId == id);
        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE 
    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _unitOfWork.EmployeeRepository.DeleteAsync(id);
        return Ok(new { message = "Employee deleted successfully." });
    }

}

