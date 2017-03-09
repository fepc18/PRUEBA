using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Inventario;
using Modelo.POS;


namespace Modelo.Referimientos
{
    [Table("ProductoReferimiento")]
    public class ProductoReferimiento
    {
        public int ProductoReferimientoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
       
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public Boolean Activo { get; set; }
        [Display(Name = "Fecha Inicio Ventas")]
        public DateTime? FechaInicioVentas { get; set; }     
        [Display(Name = "Fecha Final Ventas")]
        public DateTime? FechaFinalVentas { get; set; }
         [Display(Name = "Precio")]
        public decimal PrecioUnidad { get; set; }
        [Display(Name = "Comisión")]
        public decimal Comision { get; set; }      

    }
   

}



