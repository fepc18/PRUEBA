using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Modelo.Seguridad;


namespace Modelo.Inventario
{
    public class Bodega
    {
        [Display(Name = "Id")]
        public int BodegaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public String Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo Bodega")]
        public int TipoBodegaId { get; set; }
        [Display(Name = "Tipo Bodega")]
        [Required(ErrorMessage = "Campo Requerido")]
        public virtual TipoBodega TipoBodega { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public Boolean Activo { get; set; }       
    }
    public class TipoBodega
    {
        [Display(Name = "Id")]
        public int TipoBodegaId { get; set; }
        [Required(ErrorMessage="Campo Requerido")]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
    }

    public class ProductoBodega
    {
        public int ProductoBodegaId  { get; set; }
        public int BodegaId { get; set; }
        public int ProductoId { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }

    }
    [Table("UsuariosBodega")]
    public class UsuarioBodega
    {
        public int UsuarioBodegaId { get; set; }
        public int BodegaId { get; set; }
        public virtual Bodega Bodega { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
    [Table("StockBodegas")]
    public class StockBodega
    {
        public int StockBodegaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int BodegaId { get; set; }
        public virtual Bodega Bodega { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public Double StockMin { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public Double StockMax { get; set; }
    }
   
    
}
