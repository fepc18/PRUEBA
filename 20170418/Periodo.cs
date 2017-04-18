using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Financy.Entities
{
    [Table("Periodos")]
    public class Periodo
    {

        [Display(Name = "Id")]
        public int PeriodoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public String Nombre { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaTermino { get; set; }
        public Boolean Activo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Orden { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Ejercicio { get; set; }       


    }

    [Table("SaldosPeriodo")]
    public class SaldosPeriodo
    {
        [Display(Name = "Id")]
        public int SaldosPeriodoId { get; set; }
        public int PeriodoId { get; set; }
        public int BodegaId { get; set; }
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