//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cafe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        public int EmployeesID { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public int IDPosition { get; set; }
        public int IDCafe { get; set; }
        public int IDUser { get; set; }
    
        public virtual CafeShops CafeShops { get; set; }
        public virtual Positions Positions { get; set; }
        public virtual Users Users { get; set; }
    }
}
