﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Musical_Course.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MusicalBaseEntities2 : DbContext
    {
        private static MusicalBaseEntities2 _context;
        public MusicalBaseEntities2()
        : base("name=MusicalBaseEntities")
        {
        }

        public static MusicalBaseEntities2 GetContext()
        {
            if (_context == null)
            {
                _context = new MusicalBaseEntities2();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<AutorisationHistory> AutorisationHistory { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Rolls> Rolls { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeAdvertisement> TypeAdvertisement { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
