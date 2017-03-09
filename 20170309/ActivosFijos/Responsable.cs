using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Modelo.POS;

namespace Modelo.ActivosFijos
{
    [Table("ResponsableAsignado")]
    public class ResponsableAsignado
    {
        public int ResponsableAsignadoId { get; set; }
        public int ActivoFijoId { get; set; }
        public virtual ActivoFijo ActivoFijo { get; set; }
        public int TerceroId { get; set; }
        public virtual Tercero Tercero { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public Boolean vigente { get; set; }
    }
}
