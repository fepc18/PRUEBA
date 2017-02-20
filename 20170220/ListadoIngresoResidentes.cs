using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.ControlResidentes.Dtos
{
    public class ListadoIngresoResidentes
    {
        [Display(Name = "Id")]
        public string IngresoResidenteId { get; set; }
        public string Sede { get; set; }
        public string Identificacion { get; set; }
        public string Paciente { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public string FechaIngreso { get; set; }
        [Display(Name = "Adicción")]
        public string TipoAdiccion { get; set; }
        public string Acudiente { get; set; }
        [Display(Name = "Celular Acudiente")]
        public string CelularAcudiente { get; set; }
        public string Locker { get; set; }
        public string Cama { get; set; }
        public string Estado { get; set; }
        
    }
}
