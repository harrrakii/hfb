using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Selling
{
    public int SellingId { get; set; }

    public int? IdcoffeeShop { get; set; }

    public int? Idcustomer { get; set; }

    public DateTime? SaleDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? Idsale { get; set; }

    public virtual CafeShop? IdcoffeeShopNavigation { get; set; }

    public virtual Customer? IdcustomerNavigation { get; set; }

    public virtual Sale? IdsaleNavigation { get; set; }

    public virtual ICollection<SellingDetail> SellingDetails { get; set; } = new List<SellingDetail>();
}
