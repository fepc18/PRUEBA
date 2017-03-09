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
    [Table("ActivoFijo")]
    public class ActivoFijo
    {
        [DisplayName("Id")]
        public int ActivoFijoId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Código")]
        public String Codigo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Número de Serie")]
        public String NumeroSerie { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Marca")]
        public String Marca { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Modelo")]
        public String Modelo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Color")]
        public String Color { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Ubicación")]
        public int UbicacionDestinoId { get; set; }
        public virtual UbicacionDestino UbicacionDestino { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Estado")]
        public int EstadoActivoFijoId { get; set; }
        public virtual EstadoActivoFijo EstadoActivoFijo { get; set; }

        public TipoIngreso TipoIngreso { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public DateTime FechaAlta { get; set; }
        public decimal ValorUnitario { get; set; }
        public int GrupoActivoId { get; set; }
        public virtual GrupoActivo GrupoActivo { get; set; }
        
        public string NumeroFactura { get; set; }

        public DateTime FechaOperacion { get; set; }
        public String Usuario { get; set; }
        public String PeriodoIngreso { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Responsable")]
        public int TerceroId { get; set; }
        public virtual Tercero TerceroId { get; set; }
        public String DescripcionEstado { get; set; }
        public Boolean MenorCuantia { get; set; }
        public EstadoIngreso EstadoIngreso { get; set; }

    }
    public class EstadoActivoFijo
    {
        [DisplayName("Id")]
        public int EstadoActivoFijoId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Descripción")]
        public String Descripcion { get; set; }
    }
    public enum TipoIngreso
    {
        Compra,
        Prestamo,
        Donacion,
        Leasing
    }
    public enum EstadoIngreso
    {
        Ingresado,
        Alta,
        Baja
    }

}
