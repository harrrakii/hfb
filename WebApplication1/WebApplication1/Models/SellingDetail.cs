using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class SellingDetail
{
    public int SellingDetailId { get; set; }

    public int? Idselling { get; set; }

    public int? Idproduct { get; set; }

    public int? Count { get; set; }

    public decimal? Amount { get; set; }

    public virtual Product? IdproductNavigation { get; set; }

    public virtual Selling? IdsellingNavigation { get; set; }
}
