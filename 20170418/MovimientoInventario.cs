using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Modelo.Seguridad;
using Modelo.Inventario;

namespace Modelo.Inventario
{
    [Table("MovimientosInventario")]
    public class MovimientoInventario
    {
        [Display(Name = "Id")]
        public int MovimientoInventarioId { get; set; }
        public String Consecutivo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime Fecha { get; set; }
        [Display(Name = "Bodega")]
        public int BodegaId { get; set; }
        [Display(Name = "Bodega")]
        public virtual Bodega Bodega { get; set; }
        public int TipoMovimientoId { get; set; }
        [Display(Name = "Tipo Movimiento")]
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage ="Campo Requerido")]
        public String Descripcion { get; set; }
        [Display(Name = "Estado")]
        public int EstadoMovimientoId { get; set; }
        [Display(Name = "Estado")]
        public virtual EstadoMovimiento EstadoMovimiento { get; set; }
        [Display(Name = "Tercero")]
        public int TerceroId { get; set; }
        [Display(Name = "Tercero")] 
        public virtual Tercero Tercero { get; set; }
        [Display(Name = "Documento Referencia")]
        [Required(ErrorMessage = "Campo Requerido")]
        public String DocumentoReferencia { get; set; }
        public String Usuario { get; set; }
        [Display(Name = "Fecha Operación")]
        public DateTime FechaOperacion { get; set; }
        [Display(Name = "Destino")]
        public int UbicacionDestinoId { get; set; }
        [Display(Name = "Destino")]
        public virtual UbicacionDestino UbicacionDestino { get; set; }

        public List<MovimientoInventarioDetalle> MovimientoInventarioDetalle { get; set; }

    }
    [Table("EstadoMovimiento")]
    public class EstadoMovimiento {
        [Display(Name = "Id")]
        public int EstadoMovimientoId { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido")]
        public String Descripcion { get; set; }
    }

    [Table("MovimientoInventarioDetalle")]
    public class MovimientoInventarioDetalle
    {
        [Display(Name = "Id")]
        public int MovimientoInventarioDetalleId { get; set; }
        [Display(Name = "Movimiento")]
        public int    MovimientoInventarioId { get; set; }
        public int   BodegaId { get; set; }
        public int   ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public int   LoteId { get; set; }
        public virtual Lote Lote { get; set; }
        public double   Cantidad { get; set; }
        public double  Pendiente { get; set; }
        public decimal    Valor { get; set; }
        public String    IO  { get; set; }
        public String Observacion { get; set; }

        

    }
    [Table("Lotes")]
    public class Lote
    {
        public int LoteId { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo Requerido")]
        public String NumeroLote { get; set; }
        [Display(Name = "Fecha Vencimiento")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
       // [RegularExpression("(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d", ErrorMessage = "Fecha Invalida")]
        public DateTime FechaVencimiento { get; set; } 

    }
    [Table("TipoMovimiento")]
    public class TipoMovimiento
    {
        [Display(Name = "Id")]
        public int TipoMovimientoId { get; set; }
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Requerido")]
        public String Codigo { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Requerido")]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String IO { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Prefijo { get; set; }
        [Display(Name = "Máscara")]
        [Required(ErrorMessage = "Campo Requerido")]
        public String Mascara { get; set; }
        [Display(Name = "Valor Actual")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Int32 ValorActual { get; set; }         
    }
   
    [Table("UsuariosTipoMovimiento")]
    public class UsuarioTipoMovimiento
    {
        public int UsuarioTipoMovimientoId { get; set; }
        public int TipoMovimientoId { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}


