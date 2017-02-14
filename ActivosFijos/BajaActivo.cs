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
    [Table("BajaActivo")]
    public class BajaActivo
    {
        [DisplayName("Id")]
        public int BajaActivoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Activo Fijo")]
        public int ActivoFijoId { get; set; }
        public virtual ActivoFijo ActivoFijo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Fecha de Baja")]
        public DateTime FechaBaja { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Tipo de Baja")]
        public int TipoBajaId { get; set; }
        public virtual TipoBaja TipoBaja { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public String Usuario { get; set; }

      
    }
    public class TipoBaja
    {
        [DisplayName("Id")]
        public int TipoBajaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Descripción")]
        public String Descripcion { get; set; }
    }
}
