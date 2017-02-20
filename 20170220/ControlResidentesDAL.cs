using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionBaseDatos;
using DAL.ControlResidentes.Dtos;
using Modelo.ControlResidentes;
namespace DAL.ControlResidentes
{
    public class ControlResidentesDAL : IControlResidentesDAL
    {
        public List<ListadoIngresoResidentes> ListarIngresoResidentes()
        {
            Conexion objConexionMedical = new Conexion();
            String dbMedical = objConexionMedical.DbConexion.Database;
            List<ListadoIngresoResidentes> respuesta = new List<ListadoIngresoResidentes>();
            Conexion objConexion = new Conexion("OpenMedical");
            String sql = "SELECT I.IngresoResidenteId,S.Nombre Sede,P.Identificacion Identificacion,P.Nombre Paciente,I.FechaIngreso,TA.Descripcion TipoAdiccion,I.Acudiente,I.Celular CelularAcudiente,EstadoResidente,ISNULL(L.Descripcion,'Sin Asignar') Locker,ISNULL(C.Nombre +' - '+H.Nombre+' - '+Piso.Nombre,'Sin Asignar') Cama FROM " + dbMedical + ".dbo.IngresoResidente I INNER JOIN " +
                         " Pacientes P ON P.Id = I.PacienteId INNER JOIN " + dbMedical + ".dbo.Sedes S ON S.SedeId = I.SedeId " +
                         " INNER JOIN " + dbMedical + ".dbo.TipoAdiccion TA ON TA.TipoAdiccionId = I.TipoAdiccionId" +
                         " LEFT JOIN " + dbMedical + ".dbo.LockerAsignado LA ON LA.PacienteId = P.Id AND LA.Vigente = 1  LEFT JOIN " + dbMedical + ".dbo.Locker L ON L.LockerId = LA.LockerId " +
                         " LEFT JOIN " + dbMedical + ".dbo.CamaAsignada CA ON CA.PacienteId = P.Id AND CA.Vigente = 1 LEFT JOIN " + dbMedical + ".dbo.Cama C ON C.CamaId = CA.CamaId " +
                         "LEFT JOIN " + dbMedical + ".dbo.Habitacion H ON H.HabitacionId = C.HabitacionId LEFT JOIN " + dbMedical + ".dbo.Piso Piso ON Piso.PisoId = H.PisoId ";
            Paquete paquete = objConexion.consultar(sql);
            respuesta = descargarDataTable(paquete);
            return respuesta;
        }

      

        private List<ListadoIngresoResidentes> descargarDataTable(Paquete paquete)
    {
        List<ListadoIngresoResidentes> respuesta = new List<ListadoIngresoResidentes>();
        if (!paquete.Error)

        {
            if (!paquete.esVacio())
            {
                for (int i = 0; i < paquete.Datos.Rows.Count; i++)
                {
                        ListadoIngresoResidentes obj= new ListadoIngresoResidentes();
                        obj.IngresoResidenteId = paquete.Datos.Rows[i]["IngresoResidenteId"].ToString();
                        obj.Sede = paquete.Datos.Rows[i]["Sede"].ToString();
                        obj.Identificacion = paquete.Datos.Rows[i]["Identificacion"].ToString();
                        obj.Paciente = paquete.Datos.Rows[i]["Paciente"].ToString();
                        obj.FechaIngreso = paquete.Datos.Rows[i]["FechaIngreso"].ToString().Substring(0,10);
                        obj.TipoAdiccion = paquete.Datos.Rows[i]["TipoAdiccion"].ToString();
                        obj.CelularAcudiente = paquete.Datos.Rows[i]["CelularAcudiente"].ToString();                        
                        if(paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("0"))
                            obj.Estado = "Interno";
                        if (paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("1"))
                            obj.Estado = "ReIngreso";
                        if (paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("2"))
                            obj.Estado = "Movilizado";
                        if (paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("3"))
                            obj.Estado = "Abandono";
                        if (paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("4"))
                            obj.Estado = "Interno";
                        if (paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("5"))
                            obj.Estado = "Expulsado";
                        if (paquete.Datos.Rows[i]["EstadoResidente"].ToString().Equals("6"))
                            obj.Estado = "Desprendimiento";
                        obj.Cama = paquete.Datos.Rows[i]["Cama"].ToString();
                        obj.Locker = paquete.Datos.Rows[i]["Locker"].ToString();
                        respuesta.Add(obj);
                }
            }
        }
        return respuesta;
    }
    }
}



