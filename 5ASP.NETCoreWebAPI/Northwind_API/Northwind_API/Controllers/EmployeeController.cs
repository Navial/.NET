using Microsoft.AspNetCore.Mvc;
using Northwind_API.Entities;
using Northwind_API.Models;
using Repository;



[ApiController]
[Route("/api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly NorthwindContext _dbContext;
    private IRepository<Employee> employeeRepo;

    public EmployeeController(NorthwindContext dbContext)
    {
        _dbContext = dbContext;
        employeeRepo = new BaseRepository<Employee>(_dbContext);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
    {
        Console.WriteLine("GetAllEmployees");
        var employees = await employeeRepo.GetAllAsync();
        return Ok(employees);
    }

}

