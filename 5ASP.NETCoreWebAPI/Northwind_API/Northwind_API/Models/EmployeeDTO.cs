using System;
using System.Collections.Generic;

namespace Northwind_API.Entities;

public partial class EmployeeDTO
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;
}
