using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Seguridad
{

    public class MenuControlResidentes
    {
        public Boolean IngresoResidente { get; set; }
        public Boolean LlamadaAutorizada { get; set; }
        public Boolean VisitaResidente { get; set; }
        public Boolean LlamadaResidente { get; set; }
        public Boolean TipoAdiccion { get; set; }
        public Boolean TipoSustancias { get; set; }
        public Boolean Lockers { get; set; }
        public Boolean Camas { get; set; }
        public Boolean Habitacion { get; set; }
        public Boolean TipoHabitacion { get; set; }
        public Boolean Piso { get; set; }
        public Boolean Edificio { get; set; }
        public Boolean Sede { get; set; }            

    }
}
