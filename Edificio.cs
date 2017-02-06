using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.POS;

namespace Modelo.Hospitalizacion
{
    [Table("Edificio")]
    public class Edificio
    {
        public int EdificioId { get; set; }
        public string Codigo { get; set; }
        public String Nombre { get; set; }
        public int SedeId { get; set; }
        public virtual Sede Sede { get; set; }
    }

    [Table("Piso")]
    public class Piso
    {
        public int PisoId { get; set; }
        public String Nombre { get; set; }
        public int EdificioId { get; set; }
        public virtual Edificio Edificio { get; set; }
    }
    [Table("TipoHabitacion")]
    public class TipoHabitacion
    {
        public int TipoHabitacionId { get; set; }
        public String Nombre { get; set; } //   (EJ Unipersonal, Compartida)
     
    }
    [Table("Habitacion")]
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        public String Nombre { get; set; }       
        public int TipoHabitacionId { get; set; }
        public virtual TipoHabitacion TipoHabitacion { get; set; }
        public int PisoId { get; set; }
        public virtual Piso Piso { get; set; }
    }
    [Table("Cama")]
    public class Cama
    {
        public int CamaId { get; set; }
        public String Nombre { get; set; }
        public int HabitacionId { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        public EstadoCama EstadoCamaId { get; set; }
    }
    public enum EstadoCama { 
        Ocupado,
        Libre,
        Desactivada,
        Limpieza
    }
}