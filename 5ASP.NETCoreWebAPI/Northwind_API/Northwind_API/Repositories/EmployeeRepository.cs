using Microsoft.EntityFrameworkCore;
using Northwind_API.Entities;
using Repository;

namespace Northwind_API.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(NorthwindContext _dbContext) : base(_dbContext)
        {

        }

        // DELETE BY ID
        public override async Task<Employee?> DeleteAsync(int id)
        {
            var employee = await _dbContext.Employees
                                           .Include(e => e.InverseReportsToNavigation) // Inclure les employés qui rapportent à cet employé
                                           .Include(e => e.Orders).ThenInclude(o => o.OrderDetails)
                                           .Include(e => e.Territories) // Inclure les territoires liés
                                           .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Entité avec l'ID '{id}' non trouvée.");
            }

            // Mise à jour du champ ReportsTo pour les employés qui rapportent à cet employé
            foreach (var subordinate in employee.InverseReportsToNavigation)
            {
                subordinate.ReportsTo = null; // Ou mettre à jour avec un autre employé valide
            }

            // Supprimer les détails des commandes et des commandes
            foreach (var order in employee.Orders)
            {
                _dbContext.OrderDetails.RemoveRange(order.OrderDetails);
            }
            _dbContext.Orders.RemoveRange(employee.Orders);

            // Supprimer l'employé
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return employee;
        }
    }
}
