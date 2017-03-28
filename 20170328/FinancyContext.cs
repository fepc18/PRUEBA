using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Modelo.Seguridad;
using Modelo.ActivosFijos;
namespace Financy.Models
{
    public class FinancyContext : DbContext
    {



        public System.Data.Entity.DbSet<Modelo.Seguridad.Usuario> Usuario { get; set; }

        public System.Data.Entity.DbSet<Modelo.POS.Sede> Sedes { get; set; }
        
        public System.Data.Entity.DbSet<Modelo.Seguridad.UsuarioRol> UsuarioRols { get; set; }

        public System.Data.Entity.DbSet<Modelo.Seguridad.Rol> Rols { get; set; }
        public System.Data.Entity.DbSet<Modelo.ActivosFijos.EstadoActivoFijo> EstadoActivoFijoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.ActivosFijos.GrupoActivo> GrupoActivoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.ActivosFijos.TipoBaja> TipoBajas { get; set; }

        public System.Data.Entity.DbSet<Modelo.ActivosFijos.ActivoFijo> ActivoFijoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.POS.Tercero> Terceroes { get; set; }

        public System.Data.Entity.DbSet<Modelo.Inventario.UbicacionDestino> UbicacionDestinoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.ActivosFijos.RevisionActivoFijo> RevisionActivoFijoes { get; set; }
      
    }
}

