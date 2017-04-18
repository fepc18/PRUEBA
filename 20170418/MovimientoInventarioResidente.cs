using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Modelo.Seguridad;
using Modelo.Inventario;
using Modelo.Comun;

namespace Financy.Entities
{
    [Table("MovimientoInventarioResidente")]
    public class MovimientoInventarioResidente
    {
        [Display(Name = "Id")]
        public int MovimientoInventarioResidenteId { get; set; }
        public int MovimientoInventarioId { get; set; }
        public virtual MovimientoInventario MovimientoInventario { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public String Usuario { get; set; }
        [Display(Name = "Fecha Operación")]
        public DateTime FechaOperacion { get; set; }
    }
    [Table("SaldosPeriodoResidente")]
    public class SaldosPeriodoResidente
    {
        [Display(Name = "Id")]
        public int SaldosPeriodoResidenteId { get; set; }      
        public int PeriodoId { get; set; }
        public int BodegaId { get; set; }
        public int PacienteId { get; set; }
        public int ProductoId { get; set; }
        public int LoteId { get; set; }
        public double Anterior { get; set; }
        public double Entradas { get; set; }
        public double Salidas { get; set; }
        public decimal ValorAnterior { get; set; }
        public decimal ValorEntradas { get; set; }
        public decimal ValorSalidas { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Stock { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal ValorStock { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Costo { get; set; }


    }


}



