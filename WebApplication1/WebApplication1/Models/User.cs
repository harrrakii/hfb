using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Idrole { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual UserRole IdroleNavigation { get; set; } = null!;
}
