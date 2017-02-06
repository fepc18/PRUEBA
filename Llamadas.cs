using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.POS;

namespace Modelo.ControlResidentes
{
    [Table("LlamadaAutorizada")]
    public class LlamadaAutorizada
    {
        public int LlamadaAutorizadaId { get; set; }
        public int PacienteId { get; set; }
        public String NombreAutorizado { get; set; }
        public String IdentificacionAutorizado { get; set; }
        public String Parentesco { get; set; }
        public String Telefono { get; set; }
        public String Observacion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public String Usuario { get; set; }
       
    }
    [Table("VisitaAutorizada")]
    public class VisitaAutorizada
    {
        public int VisitaAutorizadaId { get; set; }
        public int PacienteId { get; set; }
        public String NombreAutorizado { get; set; }
        public String IdentificacionAutorizado { get; set; }
        public String Parentesco { get; set; }
        public String Observacion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public String Usuario { get; set; }
    }
    [Table("VisitaResidente")]
    public class VisitaResidente
    {
        public int VisitaResidenteId { get; set; }
        public DateTime FechaVisita { get; set; }
        public long PacienteId { get; set; }
        public String NombreVisitante   { get; set; }
        public String EPSVisitante { get; set; }
        public String TelefonoVisitante { get; set; }
        public String Observaciones { get; set; }
        public DateTime FechaOperacion { get; set; }
        public String Usuario { get; set; }
    }
    [Table("LlamadaResidente")]
    public class LlamadaResidente
    {
        public int LlamadaResidenteId { get; set; }
        public DateTime FechaLlamada { get; set; }
        public long PacienteId { get; set; }
        public String NombreLlamada { get; set; }        
        public String TelefonoLlamada { get; set; }
        public String Observaciones { get; set; }
        public DateTime FechaOperacion { get; set; }
        public String Usuario { get; set; }
    }   


}

