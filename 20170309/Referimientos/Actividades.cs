using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Inventario;
using Modelo.POS;
using System.ComponentModel;


namespace Modelo.Referimientos
{
    [Table("TareaPosibleCliente")]
    public class TareaPosibleCliente
    {
        public int TareaPosibleClienteId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Posible Cliente")]
        public int PosibleClienteId { get; set; }
        public virtual PosibleCliente PosibleCliente { get; set; }
        public string Asunto { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
         [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }
         [Display(Name = "Prioridad")]
        public PrioridadTarea PrioridadTareaId { get; set; }
         [Display(Name = "Propósito")]
        public PropositoTarea PropositoTareaId { get; set; }
         [Display(Name = "Estado")]
        public EstadoTarea EstadoTareaId { get; set; }
        [Display(Name = "Usuario Propietario")]
        public string UsuarioPropietario { get; set; }        

        public string FechaOperacion { get; set; }
        public string Usuario { get; set; }

    }
    
    public enum PrioridadTarea
    {
        [Description("Más Bajo")]
        MasBajo,
        [Description("Bajo")]
        Bajo,
        [Description("Normal")]
        Normal,
        [Description("Alto")]
        Alto,
        [Description("Más Alto")]
        MasAlto
    }
    public enum PropositoTarea
    {
        [Description("Ninguno")]
        Ninguno,
        [Description("Posible")]
        Posible,
        [Description("Administrativo")]
        Administrativo,
        [Description("Negociación")]
        Negociacion,
        [Description("Demostración")]
        Demostracion
    }
    public enum EstadoTarea
    {
        [Description("No Iniciada")]
        NoIniciada,
        [Description("Aplazada")]
        Aplazada,
        [Description("En Progreso")]
        EnProgreso,
        [Description("En Espera")]
        EnEspera,
        [Description("Terminada")]
        Terminada
        
    }       
    //PENDIENTE EVENTO

    [Table("NotaPosibleCliente")]
    public class NotaPosibleCliente
    {
        public int NotaPosibleClienteId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Posible Cliente")]
        public int PosibleClienteId { get; set; }
        public virtual PosibleCliente PosibleCliente { get; set; }
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
         [Display(Name = "Usuario Propietario")]
        public string UsuarioPropietario { get; set; }
        public string FechaOperacion { get; set; }
        public string Usuario { get; set; }
    }
    //PENDIENTE
    public class AdjuntoPosibleCliente
    {
        public int AdjuntoPosibleClienteId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int PosibleClienteId { get; set; }
        public virtual PosibleCliente PosibleCliente { get; set; }
        public string NombreArchivo { get; set; }
        public int Tamaño { get; set; }
        public string UsuarioPropietario { get; set; }
        public string FechaOperacion { get; set; }
        public string Usuario { get; set; }
    }
}


