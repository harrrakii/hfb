//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica1EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class MasterServices
    {
        public int MasterServiceID { get; set; }
        public Nullable<int> ID_Master { get; set; }
        public Nullable<int> ID_Service { get; set; }
    
        public virtual Masters Masters { get; set; }
        public virtual Services_ Services_ { get; set; }
    }
}
