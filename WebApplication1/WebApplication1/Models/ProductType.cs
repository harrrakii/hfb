﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string ProductType1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
