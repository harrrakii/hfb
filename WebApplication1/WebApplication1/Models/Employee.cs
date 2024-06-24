using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Employee
{
    public int? EmployeesId { get; set; }

    public string Surname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int? Idposition { get; set; }

    public int? Idcafe { get; set; }

    public int? Iduser { get; set; }



}
