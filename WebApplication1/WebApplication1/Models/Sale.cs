using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<Selling> Sellings { get; set; } = new List<Selling>();
}
