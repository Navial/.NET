using Northwind_API.Entities;
using Repository;

namespace Northwind_API.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;
        private BaseRepository<Employee> _employeeRepository;

        public UnitOfWork(NorthwindContext context)
        {
            this._context = context;
            this._employeeRepository = new BaseRepository<Employee>(context);
        }

        public IRepository<Employee> EmployeeRepository { get { return _employeeRepository; } }

        public IRepository<Employee> LegumesRepository => throw new NotImplementedException();
    }
}
