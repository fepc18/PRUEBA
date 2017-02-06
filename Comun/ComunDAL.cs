using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionBaseDatos;
using Modelo.Comun;
using Modelo.ControlResidentes;
namespace DAL.Comun
{
    public class ComunDAL : IComunDAL
    {
        public List<Paciente> listarPacientes()
        {

            List<Paciente> respuesta = new List<Paciente>();
            Conexion objConexion = new Conexion("OpenMedical");
            String sql = "SELECT [Id],[Identificacion],[Carnet],[Nom1Afil],[Nom2Afil],[Ape1Afil],[Ape2Afil],[Profesion],[FechaNac],[Sexo],[DirAfil] " +
                        " ,[TelRes],[TelOfic],[EstadoCivil],[Regimen],[Zona],[TipoID],[Municipio],[UnidadEdad],[Responsable],[Acompañante],[TelAcomp]" +
                        ",[Expedicion],[Historia],[Usuario],[Nivel],[TipoUsuario],[Facturarlo],[Activo],[DirCatastrofe],[MunicipioCatastrofe],[DepartamentoCatastrofe]" +
                        ",[ZonaCatastrofe],[FechaCatastrofe],[FechaOp],[Grado],[Parentesco],[FechaAfil],[Pensionado],[FechaInsc],[ConsHistoria],[ConsEvol]" +
                        ",[CA],[Diagnostico],[Multado],[Recibo],[Escolaridad],[Sangre],[Etnia],[Barrio],[FichaSisben],[FechaEPS],[TipoCabFamilia],[IdCabFamilia]" +
                        ",[CodAdministradora],[GrupoPoblacional],[CondBenef],[ModalidadSubsi],[TipoCotizante],[FechaSisben],[FechaAfiliacionSisben],[Muerto]" +
                        ",[OrigenMuerte],[FechaMuerte],[Control],[Huella],[TelResponsable],[Nombre],[bHuella],[EstadoEmbarazo],[idReligion],[Foto],[NombreCUI]" +
                        "  FROM[dbo].[Pacientes]";
            Paquete paquete = objConexion.consultar(sql);
            if (!paquete.Error)
            {
                if (!paquete.esVacio())
                {
                    for (int i = 0; i < paquete.Datos.Rows.Count; i++)
                    {
                        Paciente objPaciente = new Paciente();
                        objPaciente.Id = paquete.Datos.Rows[i]["Id"].ToString();
                        objPaciente.Identificacion = paquete.Datos.Rows[i]["Identificacion"].ToString();
                        objPaciente.Carnet = paquete.Datos.Rows[i]["Carnet"].ToString();
                        objPaciente.Nom1Afil = paquete.Datos.Rows[i]["Nom1Afil"].ToString();
                        objPaciente.Nom2Afil = paquete.Datos.Rows[i]["Nom2Afil"].ToString();
                        objPaciente.Ape1Afil = paquete.Datos.Rows[i]["Ape1Afil"].ToString();
                        objPaciente.Ape2Afil = paquete.Datos.Rows[i]["Ape2Afil"].ToString();
                        objPaciente.Profesion = paquete.Datos.Rows[i]["Profesion"].ToString();
                        objPaciente.FechaNac = paquete.Datos.Rows[i]["FechaNac"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaNac"]);
                        objPaciente.Sexo = paquete.Datos.Rows[i]["Sexo"].ToString();
                        objPaciente.DirAfil = paquete.Datos.Rows[i]["DirAfil"].ToString();
                        objPaciente.TelRes = paquete.Datos.Rows[i]["TelRes"].ToString();
                        objPaciente.TelOfic = paquete.Datos.Rows[i]["TelOfic"].ToString();
                        objPaciente.EstadoCivil = paquete.Datos.Rows[i]["EstadoCivil"].ToString();
                        objPaciente.Regimen = paquete.Datos.Rows[i]["Regimen"].ToString();
                        objPaciente.Zona = paquete.Datos.Rows[i]["Zona"].ToString();
                        objPaciente.TipoID = paquete.Datos.Rows[i]["TipoID"].ToString();
                        objPaciente.Municipio = paquete.Datos.Rows[i]["Municipio"].ToString();
                        objPaciente.UnidadEdad = paquete.Datos.Rows[i]["UnidadEdad"].ToString();
                        objPaciente.Responsable = paquete.Datos.Rows[i]["Responsable"].ToString();
                        objPaciente.Acompañante = paquete.Datos.Rows[i]["Acompañante"].ToString();
                        objPaciente.TelAcomp = paquete.Datos.Rows[i]["TelAcomp"].ToString();
                        objPaciente.Expedicion = paquete.Datos.Rows[i]["Expedicion"].ToString();
                        objPaciente.Historia = paquete.Datos.Rows[i]["Historia"].ToString();
                        objPaciente.Usuario = paquete.Datos.Rows[i]["Usuario"].ToString();
                        objPaciente.Nivel = paquete.Datos.Rows[i]["Nivel"].ToString();
                        objPaciente.TipoUsuario = paquete.Datos.Rows[i]["TipoUsuario"].ToString();
                        objPaciente.Facturarlo = Convert.ToBoolean(paquete.Datos.Rows[i]["Facturarlo"]);
                        objPaciente.Activo = Convert.ToBoolean(paquete.Datos.Rows[i]["Activo"]);
                        objPaciente.DirCatastrofe = paquete.Datos.Rows[i]["DirCatastrofe"].ToString();
                        objPaciente.MunicipioCatastrofe = paquete.Datos.Rows[i]["MunicipioCatastrofe"].ToString();
                        objPaciente.DepartamentoCatastrofe = paquete.Datos.Rows[i]["DepartamentoCatastrofe"].ToString();
                        objPaciente.ZonaCatastrofe = paquete.Datos.Rows[i]["ZonaCatastrofe"].ToString();
                        objPaciente.FechaCatastrofe = paquete.Datos.Rows[i]["FechaCatastrofe"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaCatastrofe"]);
                        objPaciente.FechaOp = paquete.Datos.Rows[i]["FechaOp"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaOp"]);
                        objPaciente.Grado = paquete.Datos.Rows[i]["Grado"].ToString();
                        objPaciente.Parentesco = paquete.Datos.Rows[i]["Parentesco"].ToString();
                        objPaciente.FechaAfil = paquete.Datos.Rows[i]["FechaAfil"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaAfil"]);
                        objPaciente.Pensionado = paquete.Datos.Rows[i]["Pensionado"].ToString();
                        objPaciente.FechaInsc = paquete.Datos.Rows[i]["FechaInsc"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaInsc"]);
                        objPaciente.ConsHistoria = paquete.Datos.Rows[i]["ConsHistoria"].ToString().Equals("") ? 0 : Convert.ToInt16(   paquete.Datos.Rows[i]["ConsHistoria"]);
                        objPaciente.ConsEvol = paquete.Datos.Rows[i]["ConsEvol"].ToString().Equals("")?0: Convert.ToInt16(paquete.Datos.Rows[i]["ConsEvol"]);
                        objPaciente.CA = paquete.Datos.Rows[i]["CA"].ToString();
                        objPaciente.Diagnostico = paquete.Datos.Rows[i]["Diagnostico"].ToString();
                        objPaciente.Multado = paquete.Datos.Rows[i]["Multado"].ToString().Equals("") ? false : Convert.ToBoolean(paquete.Datos.Rows[i]["Multado"]);
                        objPaciente.Recibo = paquete.Datos.Rows[i]["Recibo"].ToString();
                        objPaciente.Escolaridad = paquete.Datos.Rows[i]["Escolaridad"].ToString();
                        objPaciente.Sangre = paquete.Datos.Rows[i]["Sangre"].ToString();
                        objPaciente.Etnia = paquete.Datos.Rows[i]["Etnia"].ToString();
                        objPaciente.Barrio = paquete.Datos.Rows[i]["Barrio"].ToString();
                        objPaciente.FichaSisben = paquete.Datos.Rows[i]["FichaSisben"].ToString();
                        objPaciente.FechaEPS = paquete.Datos.Rows[i]["FechaEPS"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaEPS"]);
                        objPaciente.TipoCabFamilia = paquete.Datos.Rows[i]["TipoCabFamilia"].ToString();
                        objPaciente.IdCabFamilia = paquete.Datos.Rows[i]["IdCabFamilia"].ToString();
                        objPaciente.CodAdministradora = paquete.Datos.Rows[i]["CodAdministradora"].ToString();
                        objPaciente.GrupoPoblacional = paquete.Datos.Rows[i]["GrupoPoblacional"].ToString();
                        objPaciente.CondBenef = paquete.Datos.Rows[i]["CondBenef"].ToString();
                        objPaciente.ModalidadSubsi = paquete.Datos.Rows[i]["ModalidadSubsi"].ToString();
                        objPaciente.TipoCotizante = paquete.Datos.Rows[i]["TipoCotizante"].ToString();
                        objPaciente.FechaSisben = paquete.Datos.Rows[i]["FechaSisben"].ToString().Equals("")? Convert.ToDateTime("01/01/1900"):  Convert.ToDateTime(paquete.Datos.Rows[i]["FechaSisben"]);
                        objPaciente.FechaAfiliacionSisben = paquete.Datos.Rows[i]["FechaAfiliacionSisben"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaAfiliacionSisben"]);
                        objPaciente.Muerto = paquete.Datos.Rows[i]["Muerto"].ToString().Equals("") ? false : Convert.ToBoolean(paquete.Datos.Rows[i]["Muerto"]);
                        objPaciente.OrigenMuerte = paquete.Datos.Rows[i]["OrigenMuerte"].ToString();
                        objPaciente.FechaMuerte = paquete.Datos.Rows[i]["FechaMuerte"].ToString().Equals("") ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(paquete.Datos.Rows[i]["FechaMuerte"]);
                        objPaciente.Control = paquete.Datos.Rows[i]["Control"].ToString();
                        objPaciente.Huella = paquete.Datos.Rows[i]["Huella"].ToString();
                        objPaciente.TelResponsable = paquete.Datos.Rows[i]["TelResponsable"].ToString();
                        objPaciente.Nombre = paquete.Datos.Rows[i]["Nombre"].ToString();
                        objPaciente.bHuella = paquete.Datos.Rows[i]["bHuella"].ToString().Equals("")?false: Convert.ToBoolean(paquete.Datos.Rows[i]["bHuella"]);
                        objPaciente.EstadoEmbarazo = paquete.Datos.Rows[i]["EstadoEmbarazo"].ToString().Equals("") ? false : Convert.ToBoolean(paquete.Datos.Rows[i]["EstadoEmbarazo"]);
                        objPaciente.idReligion = paquete.Datos.Rows[i]["idReligion"].ToString().Equals("") ? 0 : Convert.ToInt16(paquete.Datos.Rows[i]["idReligion"]);
                        objPaciente.Foto = paquete.Datos.Rows[i]["Foto"].ToString();
                        objPaciente.NombreCUI = paquete.Datos.Rows[i]["NombreCUI"].ToString();
                        respuesta.Add(objPaciente);
                    }
                }
            }



            return respuesta;
        }
        public List<ListadoResidentesLocker> listarPacientesLocker(string BDMedical)
        {

            List<ListadoResidentesLocker> respuesta = new List<ListadoResidentesLocker>();
            Conexion objConexion = new Conexion("OpenMedical");
            String sql = "SELECT P.Id, P.Identificacion,P.Nombre,ISNULL(L.Codigo+' - '+ L.Descripcion) Locker FROM paciente P  INNER JOIN " + BDMedical + ".dbo.IngresoResidente IR ON IR.PacienteId=P.Id " +
                        " LEFT JOIN " + BDMedical + ".dbo.LockerAsignado LA on LA.Pacientesid=P.id " +
                        " LEFT JOIN " + BDMedical + ".dbo.Locker L on L.LockerId=LA.LockerId";
            Paquete paquete = objConexion.consultar(sql);
            if (!paquete.Error)
            {
                if (!paquete.esVacio())
                {
                    for (int i = 0; i < paquete.Datos.Rows.Count; i++)
                    {
                        ListadoResidentesLocker objPaciente = new ListadoResidentesLocker();
                        objPaciente.Id = paquete.Datos.Rows[i]["Id"].ToString();
                        objPaciente.Identificacion = paquete.Datos.Rows[i]["Identificacion"].ToString();
                        objPaciente.Nombre = paquete.Datos.Rows[i]["Nombre"].ToString();
                        objPaciente.LockerAsignado = paquete.Datos.Rows[i]["Locker"].ToString();                        
                        respuesta.Add(objPaciente);
                    }
                }
            }



            return respuesta;
        }
        public List<ListadoResidentesCama> listarPacientesCama(string BDMedical)
        {

            List<ListadoResidentesCama> respuesta = new List<ListadoResidentesCama>();
            Conexion objConexion = new Conexion("OpenMedical");
            String sql = "SELECT P.Id, P.Identificacion,P.Nombre,ISNULL(L.Nombre) Cama FROM paciente P  INNER JOIN " + BDMedical + ".dbo.IngresoResidente IR ON IR.PacienteId=P.Id " +
                        " LEFT JOIN " + BDMedical + ".dbo.CamaAsignada LA on LA.Pacientesid=P.id " +
                        " LEFT JOIN " + BDMedical + ".dbo.Cama L on L.CamaId=LA.CamaId";
            Paquete paquete = objConexion.consultar(sql);
            if (!paquete.Error)
            {
                if (!paquete.esVacio())
                {
                    for (int i = 0; i < paquete.Datos.Rows.Count; i++)
                    {
                        ListadoResidentesCama objPaciente = new ListadoResidentesCama();
                        objPaciente.Id = paquete.Datos.Rows[i]["Id"].ToString();
                        objPaciente.Identificacion = paquete.Datos.Rows[i]["Identificacion"].ToString();
                        objPaciente.Nombre = paquete.Datos.Rows[i]["Nombre"].ToString();
                        objPaciente.CamaAsignada = paquete.Datos.Rows[i]["Cama"].ToString();
                        respuesta.Add(objPaciente);
                    }
                }
            }



            return respuesta;
        }
    }
}



