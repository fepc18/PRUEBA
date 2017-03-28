using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionBaseDatos;

using Modelo.ActivosFijos;
using DAL.ActivosFIjos.Dtos;

namespace DAL.ActivosFijosDAL
{
    public class ActivosFijosDAL : IActivosFijosDAL
    {
        public List<ListadoActivosFijos> ListarActivosFijos(int ubicacionId)
        {
            Conexion objConexionMedical = new Conexion();
            List<ListadoActivosFijos> respuesta = new List<ListadoActivosFijos>();
            Conexion objConexion = new Conexion();
            String sql = "SELECT ActivoFijoId, Codigo,af.Descripcion + ', Número de Serie: '+NumeroSerie+ ', Marca: '+Marca+', Modelo: '+Modelo+',"
                        + " Color: '+Modelo+'.' Descripcion ,AF.TerceroId,T.RazonSocial Responsable,AF.EstadoActivoFijoId,E.Descripcion Estado,DescripcionEstado "
                        +" FROM activofijo AF INNER JOIN Tercero T on T.TerceroId=Af.TerceroId "
                        +" INNER JOIN EstadoActivoFijo E ON E.EstadoActivoFijoId=AF.EstadoActivoFijoId "
                        +"  WHERE ubicacionDestinoid="+ubicacionId.ToString();
            Paquete paquete = objConexion.consultar(sql);
            respuesta = descargarDataTable(paquete);
            return respuesta;
        }



        private List<ListadoActivosFijos> descargarDataTable(Paquete paquete)
    {
        List<ListadoActivosFijos> respuesta = new List<ListadoActivosFijos>();
        if (!paquete.Error)

        {
            if (!paquete.esVacio())
            {
                for (int i = 0; i < paquete.Datos.Rows.Count; i++)
                {
                        ListadoActivosFijos obj = new ListadoActivosFijos();
                        obj.ActivoFijoId = paquete.Datos.Rows[i]["ActivoFijoId"].ToString();
                        obj.Codigo = paquete.Datos.Rows[i]["Codigo"].ToString();
                        obj.Descripcion = paquete.Datos.Rows[i]["Descripcion"].ToString();
                        obj.TerceroId = Convert.ToInt16(paquete.Datos.Rows[i]["TerceroId"]);
                        obj.Responsable = paquete.Datos.Rows[i]["Responsable"].ToString();
                        obj.EstadoActivoFijoId = Convert.ToInt16(paquete.Datos.Rows[i]["EstadoActivoFijoId"]);
                        obj.Estado = paquete.Datos.Rows[i]["Estado"].ToString();
                        obj.DescripcionEstado = paquete.Datos.Rows[i]["DescripcionEstado"].ToString();                        
                        respuesta.Add(obj);
                }
            }
        }
        return respuesta;
    }

        public string crearRevisionActivoFijoDetalle(int RevisionActivoFijoId)
        {
            Conexion objConexionMedical = new Conexion();
            List<ListadoActivosFijos> respuesta = new List<ListadoActivosFijos>();
            Conexion objConexion = new Conexion();
            String sql = "  INSERT INTO RevisionActivoFijoDetalle "
                         +" ([RevisionActivoFijoId],[ActivoFijoId],[EstadoActivoFijo],[TerceroId],[DescripcionEstado],[Usuario],[FechaOperacion])"
                         +" SELECT R.RevisionActivoFijoId, AF.ActivoFijoId,AF.EstadoActivoFijoId,AF.TerceroId,AF.DescripcionEstado,'',GETDATE() "
                         +"    FROM activofijo AF INNER JOIN Tercero T on T.TerceroId=Af.TerceroId "
                         +"    INNER JOIN EstadoActivoFijo E ON E.EstadoActivoFijoId=AF.EstadoActivoFijoId "
                         +"    INNER JOIN RevisionActivoFijo R ON R.UbicacionDestinoId=AF.UbicacionDestinoId "
                         +"     WHERE R.RevisionActivoFijoId="+RevisionActivoFijoId.ToString();
            
            
            Paquete paquete = objConexion.actualizar(sql);
            if (!paquete.Error)
                return "OK";
            else
                return paquete.Mensaje;
            
        }
    }
}



