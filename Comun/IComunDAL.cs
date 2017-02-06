using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Inventario.Dtos;
using Modelo.Comun;
using DAL.POS.Dtos;
namespace DAL.Comun
{
    public interface IComunDAL
    {
        List<Paciente> listarPacientes();
    }
}
