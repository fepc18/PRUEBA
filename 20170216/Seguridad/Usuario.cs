using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Seguridad
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]        
        public String Login { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Identificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Apellidos { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public Boolean Activo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public Boolean Bloqueado { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime? FechaUltimoCambioPassword { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int NumeroIntentosFallidos { get; set; }               

    }
}
