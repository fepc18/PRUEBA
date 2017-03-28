using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.ActivosFIjos.Dtos
{
    public class ListadoActivosFijos
    {
        [Display(Name = "Id")]
        public string ActivoFijoId { get; set; }
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public int TerceroId { get; set; }
        public string Responsable { get; set; }
        public int EstadoActivoFijoId { get; set; }
        public string Estado { get; set; }
         [Display(Name = "Descripción del Estado")]
        public string DescripcionEstado { get; set; }
        
    }
}
