using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;

namespace Northwind_API.Repositories
{
    public interface IEmployeeRepository
    {

        // DELETE BY ID
        Task<Employee> DeleteAsync(int id);
    }
}
