﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PRACTICA1EF1Entities : DbContext
    {
        public PRACTICA1EF1Entities()
            : base("name=PRACTICA1EF1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Masters> Masters { get; set; }
        public virtual DbSet<MasterServices> MasterServices { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Services_> Services_ { get; set; }
    }
}