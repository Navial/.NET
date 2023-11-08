using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

using (NorthwindContext context = new NorthwindContext())
{

    /*Console.WriteLine("------ 1. Lister tous les Customers habitants dans une ville saisie au clavier ------");

    Console.WriteLine("Search customers by town : ");
    string town = Console.ReadLine().ToLower();
    IQueryable<Customer> customersByTown = from Customer cust in context.Customers
                                           where cust.City.ToLower() == town
                                           select cust;
    foreach (Customer c in customersByTown)
    {
        Console.WriteLine(c.ContactName);
    }

    Console.WriteLine("------ 2. ET 3. Afficher les produits de la catégorie Beverages et Condiments. Utilisez le lazy loading  (pas d’include !) ------");

    IQueryable<Category> categories = from Category cat in context.Categories.Include("Products")
                                      where (cat.CategoryName == "Beverages" ||
                                      cat.CategoryName == "Condiments")
                                      select cat;
    foreach (Category c in categories)
    {
        Console.WriteLine("Categ. : " + c.CategoryName);
        foreach (Product product in c.Products)
        {
            Console.WriteLine("Product : " + product.ProductName);
        }
    }
    
    Console.WriteLine("------ 4.\tDonnez pour un client donné saisi au clavier la liste de ces commandes et qui ont été livrées. ------");

    // le ID du client «CustomerID »,  la date de la commande « OrderDate » et la date de livraison « ShippedDate ».
    Console.WriteLine("User : ");
    string user = Console.ReadLine().ToLower();

    IQueryable<Order> deliveredOrdersForClient = from order in context.Orders.Include("Customer")
                                      where (order.Customer.CustomerId == user &&
                                      order.ShippedDate != null)
                                      select order;
    Console.WriteLine("Orders from " + user );

    foreach (Order o in deliveredOrdersForClient)
    {
        Console.WriteLine(o.OrderId + " : DATE - " + o.OrderDate.ToString() + " | Shipped : " + o.ShippedDate);
    }

    Console.WriteLine("------ 5.Afficher le total des ventes par produit trié par ordre de numéro produit. ------");

    var productsSales = from od in context.OrderDetails
                        group od by od.ProductId into g
                        orderby g.Key
                        select new
                        {
                            ProductId = g.Key,
                            TotalSales = g.Sum(od => od.Quantity)
                        };


    foreach (var ps in productsSales)
    {
        Console.WriteLine($"ProductId: {ps.ProductId}, TotalSales: {ps.TotalSales}");
    }
    
    
    
    Console.WriteLine("------ 6.Afficher tous les employés (leur nom) qui ont sous leur responsabilité la région « Western » ------");

    var workers_west = from employee in context.Employees
                       where employee.Region.Equals("WA")
                       select new
                        {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Region = employee.Region,
                        };

    Console.WriteLine("Employee from western region");
    foreach (var emp in workers_west)
    {
        Console.WriteLine(emp.FirstName + " " + emp.LastName + " | region : " + emp.Region);
    }
    

    Console.WriteLine("------ 7. Quels sont les territoires gérés par le supérieur de « Suyama Michael » ------");

    String employee_fn = "Michael";
    String employee_ln = "Suyama";

    var superiorId = from employee in context.Employees
                    where employee.FirstName == employee_fn &&
                    employee.LastName == employee_ln
                    select employee.ReportsTo;
    Console.WriteLine("--- superior id : " + superiorId.First());

    var terr_from_superior = (from employee in context.Employees
                             where employee.EmployeeId == superiorId.First()
                             select employee.Territories);

    Console.WriteLine("Michael Suyama's superior's territories");
    Console.WriteLine("--- territories lenght : " + terr_from_superior.Count());
    int count = 1;
    foreach (var ter in terr_from_superior)
    {
        foreach( var terr in ter)
        {
            Console.WriteLine(count + ") " + terr.TerritoryDescription);
            count++;
        }
    }
    

    // --- UPDATES ---
    var customers = from c in context.Customers
                    select c;

    // Mettre à jour chaque nom de client pour être en majuscules
    foreach (var customer in customers)
    {
        customer.ContactName = customer.ContactName.ToUpper();
    }

    // Sauvegarder les changements dans la base de données
    context.SaveChanges();

    customers = from c in context.Customers
                    select c;

    foreach( var customer in customers)
    {
        Console.WriteLine(customer.ContactName);
    }
    

    // --- INSERT --- 
    Console.WriteLine("Entrez le nom de la nouvelle catégorie:");
    string categoryName = Console.ReadLine();

    // Créer une nouvelle instance de la catégorie
    var newCategory = new Category
    {
        CategoryName = categoryName
    };

    // Ajouter la nouvelle catégorie au contexte
    context.Categories.Add(newCategory);

    // Sauvegarder les changements dans la base de données
    context.SaveChanges();

    var categories = from c in context.Categories
                     select c;

    foreach ( var category in categories)
    {
        Console.WriteLine(category.CategoryName);
    }
    */
    // --- DELETE --- 
    Console.WriteLine("Entrez le nom de la catégorie à supprimer:");
    string categoryNameToDelete = Console.ReadLine();

    var categoryToDelete = context.Categories.FirstOrDefault(c => c.CategoryName.Equals(categoryNameToDelete));
    if(categoryNameToDelete != null) 
    {
        // Supprimer la catégorie du contexte
        context.Categories.Remove(categoryToDelete);

        // Sauvegarder les changements dans la base de données
        context.SaveChanges();

        Console.WriteLine("Catégorie supprimée avec succès.");
        var categories = from c in context.Categories
                         select c;

        foreach (var category in categories)
        {
            Console.WriteLine(category.CategoryName);
        }
    }
    else
    {
        Console.WriteLine("Catégorie non trouvée.");
    }


}
