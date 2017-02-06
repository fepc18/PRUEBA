using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.POS;

namespace Modelo.ControlResidentes
{
    [Table("Locker")]
    public class Locker
    {
        public int LockerId { get; set; }
        public string Codigo { get; set; }
        public String Descripcion { get; set; }
        public int SedeId { get; set; }
        public virtual Sede Sede { get; set; }
        public EstadoLocker EstadoLockerId { get; set; }
    }

    public enum EstadoLocker { 
        Ocupado,
        Libre,
        Desactivado,
        Bloqueado
    }
    [Table("Locker")]
    public class LockerAsignado
    {
        public int LockerAsignadoId { get; set; }
        public int LockerId { get; set; }
        public virtual Locker Locker { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public Boolean vigente { get; set; }
    }

}
