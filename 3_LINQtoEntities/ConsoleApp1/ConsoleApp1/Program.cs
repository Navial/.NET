
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

NorthwindContext nc = new NorthwindContext();

/*
Console.Write("Recherche par ville (entrez le nom de la ville) : ");

string city = Console.ReadLine();

var customersInTown = from customer in nc.Customers
                      where customer.City == city
                      select new
                      {
                          Id = customer.CustomerId,
                          FistName = customer.ContactName
                      };

foreach (var customer in customersInTown)
{
    Console.WriteLine(customer.Id + " : " + customer.FistName);
}
*/

/*
var BeveragesAndCondiments = from product in nc.Products
                             join category in nc.Categories on product.CategoryId equals category.CategoryId
                             where category.CategoryName == "Beverages" ||
                             category.CategoryName == "Condiments"
                             group product by category.CategoryName into productCategory
                             select new
                             {
                                 Category = productCategory.Key,
                                 Products = productCategory.Select(p => p.ProductName)
                             };

foreach (var categoryGroup in BeveragesAndCondiments)
{
    Console.WriteLine($"Catégorie : {categoryGroup.Category}");
    foreach (var product in categoryGroup.Products)
    {
        Console.WriteLine($"--- {product}");
    }
}
*/

/*
var clientOrders = from order in nc.Orders
                   where order.CustomerId == "LILAS" &&
                   order.ShippedDate.HasValue
                   orderby order.OrderDate descending
                   select order;

foreach (var order in clientOrders)
{
    Console.WriteLine($"client ID : {order.CustomerId} Order date {order.OrderDate} Shipped date {order.ShippedDate}");
}
*/

/*
var productSales = from orderDetail in nc.OrderDetails
                   join product in nc.Products on orderDetail.ProductId equals product.ProductId
                   group orderDetail by new { orderDetail.ProductId, product.ProductName } into productGroup
                   orderby productGroup.Key.ProductId
                   select new
                   {
                       ProductId = productGroup.Key.ProductId,
                       ProductName = productGroup.Key.ProductName,
                       TotalSales = productGroup.Sum(od => od.UnitPrice * od.Quantity)
                   };

foreach (var productSale in productSales)
{
    Console.WriteLine($"Product ID: {productSale.ProductId} | Product Name: {productSale.ProductName} | Total Sales: {productSale.TotalSales}");
}
*/


/*String employee_fn = "Michael";
String employee_ln = "Suyama";

var superiorId = from employee in nc.Employees
                 where employee.FirstName == employee_fn &&
                 employee.LastName == employee_ln
                 select employee.ReportsTo;
Console.WriteLine("--- superior id : " + superiorId.First());

var terr_from_superior = from employee in nc.Employees
                          where employee.EmployeeId == superiorId.First()
                          select employee.Territories;

Console.WriteLine("Michael Suyama's superior's territories");
Console.WriteLine("--- territories lenght : " + terr_from_superior.Count());
int count = 1;
foreach (var ter in terr_from_superior)
{
    foreach (var terr in ter)
    {
        Console.WriteLine(count + ") " + terr.TerritoryDescription);
        count++;
    }
}*/

/*
var customers = from c in nc.Customers
                select c;

// Mettre à jour chaque nom de client pour être en majuscules
foreach (var customer in customers)
{
    customer.ContactName = customer.ContactName.ToUpper();
}

// Sauvegarder les changements dans la base de données
nc.SaveChanges();

customers = from c in nc.Customers
            select c;

foreach (var customer in customers)
{
    Console.WriteLine(customer.ContactName);
}
*/

/*
var clients = from c in nc.Customers
              select c;

foreach(var client in clients)
{
    client.ContactName = client.ContactName.ToUpper();
}

nc.SaveChanges();
var nClients = from c in nc.Customers
              select c;

foreach( var client in nClients)
{
    Console.WriteLine(client.ContactName);
}*/



