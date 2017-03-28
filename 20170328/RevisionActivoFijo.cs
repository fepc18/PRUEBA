using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Modelo.Inventario;
using Modelo.POS;
namespace Modelo.ActivosFijos
{
    [Table("RevisionActivoFijo")]
    public class RevisionActivoFijo
    {
        [DisplayName("Id")]
        public int RevisionActivoFijoId { get; set; }
       
        public int UbicacionDestinoId { get; set; }
        public virtual UbicacionDestino UbicacionDestino { get; set; }
        [DisplayName("Fecha Revisión")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Requerido")]
        public virtual DateTime Fecha { get; set; }

        [DisplayName("Observación")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Observacion { get; set; }

        public string Usuario { get; set; }
        public DateTime FechaOperacion { get; set; }
        

    }
    [Table("RevisionActivoFijoDetalle")]
    public class RevisionActivoFijoDetalle
    {
        [DisplayName("Id")]
        public int RevisionActivoFijoDetalleId { get; set; }
        public int RevisionActivoFijoId { get; set; }
        public virtual RevisionActivoFijo RevisionActivoFijo { get; set; }
        public int ActivoFijoId { get; set; }
        [DisplayName("Activo Fijo")]
        public virtual ActivoFijo ActivoFijo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Estado")]

        public EstadoActivoFijo EstadoActivoFijo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Responsable")]
        public int TerceroId { get; set; }
        [DisplayName("Responsable")]

        public string Usuario { get; set; }
        public DateTime FechaOperacion { get; set; }
    }
}
