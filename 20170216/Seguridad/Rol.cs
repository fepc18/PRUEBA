using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Seguridad
{
    [Table("Roles")]
    public class Rol
    {
        public int RolId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Nombre { get; set; }
        public Aplicacion Aplicacion { get; set; }
    }

    public class UsuarioRol
    {
        public int UsuarioRolId { get; set; }
        public string Usuario { get; set; }
        public int RolId { get; set; }        
    }
    [Table("PermisosRol")]
    public class PermisoRol
    {
        public int PermisosRolId { get; set; }
        public int RolId { get; set; }
        public ItemMenuAplicacion ItemMenuAplicacionId { get; set; }
    }
    [Table("ItemMenuAplicacion")]
    public class ItemMenuAplicacion
    {
        public int ItemMenuAplicacionId { get; set; }
        public string Opcion { get; set; }
        public TipoItemMenu TipoItemMenuId { get; set; }        
        public Aplicacion AplicacionId { get; set; }
    }
    public enum TipoItemMenu{
        Item,
        Menu
    }
    public enum Aplicacion{
        ControlResidentes
    }
}
