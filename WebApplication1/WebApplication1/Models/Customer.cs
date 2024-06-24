using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Customer
{
    public int? CustomerId { get; set; }

    public string Surname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? Number { get; set; }

}
