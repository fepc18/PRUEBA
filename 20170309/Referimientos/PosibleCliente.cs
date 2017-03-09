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
    [Table("PosibleCliente")]
    public class PosibleCliente
    {
        public int PosibleClienteId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Usuario Propietario")]
        public string UsuarioPropietario { get; set; }

        public string Empresa { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
          [Display(Name = "Título")]
        public string Titulo { get; set; }
          [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }
          [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        public string Fax { get; set; }
          [Display(Name = "Célular")]
        public string Celular { get; set; }
          [Display(Name = "Sitio Web")]
        public string SitioWeb { get; set; }
          [Display(Name = "Fuente (Origen del Posible Cliente)")]
        public int FuentePosibleClienteId { get; set; }
        public FuentePosibleCliente FuentePosibleCliente { get; set; }
          [Display(Name = "Estado")]
        public EstadoPosibleCliente EstadoPosibleClienteId { get; set; }
          [Display(Name = "Sector")]
        public int SectorPosibleClienteId { get; set; }
        public SectorPosibleCliente SectorPosibleCliente { get; set; }
          [Required(ErrorMessage = "Campo Requerido")]
          [Display(Name = "Cantidad de Empleados")]
        public int CantidadEmpleados { get; set; }
          [Display(Name = "Ingresos Anuales")]
        public decimal IngresosAnuales { get; set; }
          [Display(Name = "Calificación")]
        public CalificacionPosibleCliente CalificacionPosibleClienteId { get; set; }
        public string Skype { get; set; }
         public string Twiter { get; set; }
          [Display(Name = "Dirección")]
        public string Direccion { get; set; }
          [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string FechaOperacion { get; set; }
        public string Usuario { get; set; }

    }
     [Table("FuentePosibleCliente")]
    public class FuentePosibleCliente // De donde llego el cliente -->Anuncio, Llamada, Recomendacion de emnpleados, Seminario, Sitio Web, Remisión Externa, Campaña Correo Electronico
    {
        public int FuentePosibleClienteId { get; set; }
          [Required(ErrorMessage = "Campo Requerido")] 
         [Display(Name = "Descripción")]
        public string Descripcion  { get; set; }
    }
    [Table("SectorPosibleCliente")]
    public class SectorPosibleCliente //Grandes Empresas, Pequeñas/Medianas Empresas, Gobierno/Militar, Independendiente, Estudiante
    {
        public int SectorPosibleClienteId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
    public enum EstadoPosibleCliente
    {
        [Description("No ha sido Contactado")]
        NoContactado,
        [Description("Contactar en el Futuro")]
        ContactarEnElFuturo,
        [Description("Contactado")]
        Contactado,
        [Description("Esperar Contacto")]
        EsperarContacto,
        [Description("No Contactar")]
        NoContactar
    }
    public enum CalificacionPosibleCliente
        {
            Adquirido,
            Activo,
            MercadeoFallo,
            ProyectoCancelado,
            Riesgoso //Que nos quieren copiar,polémico,Mala Imagen,Abusivos, Mal Pagadores,Equivocado, mal informado o desacertado
        }

}


