using Northwind_API.Entities;
using Repository;
using Semaine_4___LegumesDemo.Models;

namespace Northwind_API.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeDTO>
    {
        //public EmployeeRepository(EmployeeContext context) : base(context) { }
        public EmployeeRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
