using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.POS;
using Modelo.Hospitalizacion;

namespace Modelo.ControlResidentes
{
    [Table("IngresoResidente")]
    public class IngresoResidente
    {
        public long IngresoResidenteId { get; set; }
        public int SedeId { get; set; }
        public virtual Sede Sede { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int PacienteId { get; set; }// nombres, fecha y lugar nacimiento
        public int TipoSustanciaId { get; set; }// nombres, fecha y lugar nacimiento
        public virtual TipoSustancia TipoSustancia { get; set; }// nombres, fecha y lugar nacimiento
        public Boolean RecibidoTratamientoTerapeutico { get; set; }
        public string InstitucionTratamientoTerapeutico { get; set; }
        public Boolean recibidoTratamientoPsiquiatrico { get; set; }
        public string InstitucionTratamientoPsiquiatrico { get; set; }

        public int AcudienteResidenteId  { get; set; }
        public virtual AcudienteResidente AcudienteResidente  { get; set; }        
         public string NombreFamiliaAmigo { get; set; }
         public string DireccionFamiliaAmigo { get; set; }
         public string TelefonoFamiliaAmigo { get; set; }
        public string CelularFamiliaAmigo { get; set; }
        public EstadoResidente EstadoResidente { get; set; }
        
    }
    public class TipoSustancia       //basuco, marihuana, cocaina, inhalante, otro,
    {
        public int TipoSustanciaId;
        public string Descripcion;
    }
    public class AcudienteResidente{
         public long AcudienteResidenteId { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }        
    }
    public enum EstadoResidente{
        Interno,
        Movilizado,
        Abandono,
        ReIngreso,
        Finalizado
    }

    public class ListadoResidentesLocker
    {
        public String Id { get; set; }
        public String Identificacion { get; set; }
        public String Nombre { get; set; }
        public String LockerAsignado { get; set; }
    }
    public class ListadoResidentesCama
    {
        public String Id { get; set; }
        public String Identificacion { get; set; }
        public String Nombre { get; set; }
        public String CamaAsignada { get; set; }
    }
    public class CamaAsignada
    {
        public int CamaAsignadaId { get; set; }
        public int CamaId { get; set; }
        public virtual Cama Cama { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public Boolean vigente { get; set; }
    }
    //MANEJO DE SALIDAS  --> DESPRENDIMIENTO??
    //RESTRICCION DE LLAMADAS
    //REGISTRO DE LLAMADAS
    //
}
