using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Modelo.ActivosFijos
{
    [Table("GrupoActivo")]
    public class GrupoActivo
    {
        [DisplayName("Id")]
        public int GrupoActivoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Código")]
        public String Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]  
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Vida Útil")]
        public int VidaUtil { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Es Inmueble")]
        public Boolean Inmueble { get; set; }
    }
}
