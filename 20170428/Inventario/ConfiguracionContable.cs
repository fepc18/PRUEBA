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
    [Table("ConfiguracionContableGrupo")]
    public class ConfiguracionContableGrupo
    {
        [Display(Name = "Id")]
        public int ConfiguracionContableGrupoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "GrupoInventarioId")]
        public int GrupoInventarioId { get; set; }
        public virtual GrupoInventario GrupoInventario { get; set; }
        [Display(Name = "Cuenta Activo")]
        public string CuentaContableActivo { get; set; }
        [Display(Name = "Cuenta Gasto")]
        public string CuentaContableGasto { get; set; }
        [Display(Name = "Cuenta Costo")]
        public string CuentaContableCosto { get; set; }
        [Display(Name = "Cuenta Ingreso")]
        public string CuentaContableIngreso { get; set; }
             
    }
    [Table("ConfiguracionContableUbicacion")]
    public class ConfiguracionContableUbicacion
    {
        [Display(Name = "Id")]
        public int ConfiguracionContableUbicacionId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Ubicación")]
        public int UbicacionDestinoId { get; set; }
        public virtual UbicacionDestino UbicacionDestino { get; set; }
        [Display(Name = "Centro de Costo")]
        public string CentroCosto { get; set; }

    }


}
