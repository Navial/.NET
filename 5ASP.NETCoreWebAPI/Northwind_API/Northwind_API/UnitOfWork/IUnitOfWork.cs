using Northwind_API.Entities;

namespace Northwind_API.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Employee> EmployeeRepository { get; }

    }
}
