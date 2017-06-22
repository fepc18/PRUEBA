using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServicesABC
{
    public partial class FinancyContext : DbContext
    {
        public FinancyContext()
            : base("name=FinancyContext")
        {
        }

        public virtual DbSet<Modelo.Seguridad.LogServiceABC> LogServiceABC { get; set; }
        public virtual DbSet<Modelo.Seguridad.Usuario> Usuario { get; set; }  
        
    }
}
