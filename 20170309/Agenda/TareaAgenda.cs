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
    [Table("TareaAgenda")]
    public class TareaAgenda
    {
        public int TareaAgendaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Usuario Propietario")]
        public string UsuarioPropietario { get; set; }
         [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }
         [Display(Name = "Hora")]
        public String HoraInicio { get; set; }
         [Display(Name = "Fecha de Finalización")]
        public DateTime FechaFin { get; set; }
         [Display(Name = "Hora")]
        public String HoraFin    { get; set; }
        public String Asunto { get; set; }
         [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
        public int ReunionId { get; set; }
        [Display(Name = "Ubicación")]
        public String Ubicacion { get; set; }
        [Display(Name = "es Reunión")]
        public Boolean esReunion { get; set; }
         [Display(Name = "Estado")]
        public EstadoTareaAgenda EstadoTareaAgendaId { get; set; }
      
        public DateTime FechaOperacion { get; set; }
        public string Usuario { get; set; }
    }

    public enum EstadoTareaAgenda{
        Completada,
        Aceptada,
        AceptadaProvisional,
        Rechazada,
        Eliminada
    }
  /*   [Table("ReunionAgenda")]
    public class ReunionAgenda
    {
        public int ReunionAgendaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string UsuarioOrganizador { get; set; }
        public DateTime FechaInicio { get; set; }
        public String HoraInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String HoraFin { get; set; }
        public String Asunto { get; set; }
        public String Descripcion { get; set; }
        public int EventoId { get; set; }
        public String Ubicacion { get; set; }
        public string FechaOperacion { get; set; }
        public string Usuario { get; set; }
    }*/
    [Table("InvitadoAgenda")]
    public class InvitadoAgenda
    {
        public int InvitadoAgendaId { get; set; }
        public int ReunionAgendaId { get; set; }
         [Display(Name = "Invitado")]
        public string UsuarioInvitado { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string Usuario { get; set; }
    }

}


