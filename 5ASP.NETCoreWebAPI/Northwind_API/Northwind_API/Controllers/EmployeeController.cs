using Microsoft.AspNetCore.Mvc;
using Northwind_API.Entities;
using Northwind_API.Models;
using Northwind_API.Repositories;
using Repository;



[ApiController]
[Route("/api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;


    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();
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
        await _employeeRepository.InsertAsync(employee);
        //return Ok(employee);
        return CreatedAtAction(nameof(_employeeRepository.GetByIdAsync), new { id = employee.EmployeeId }, employee);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return BadRequest();
        }

        var result = await _employeeRepository.SaveAsync(employee, e => e.EmployeeId == id);
        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE 
    [HttpDelete]
    public async Task<ActionResult<IEnumerable<Employee>>> DeleteEmployee(int id)
    {
        var restult = await _employeeRepository.DeleteAsync(id);
        return Ok(restult);
    }

}

