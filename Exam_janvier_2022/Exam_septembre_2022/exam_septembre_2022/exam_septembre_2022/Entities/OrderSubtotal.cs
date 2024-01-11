using System;
using System.Collections.Generic;

namespace exam_septembre_2022.Entities;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
