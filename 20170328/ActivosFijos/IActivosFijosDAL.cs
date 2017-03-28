using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Inventario.Dtos;
using Modelo.Comun;
using DAL.ActivosFIjos.Dtos;
namespace DAL.ActivosFijosDAL
{
    public interface IActivosFijosDAL
    {
        List<ListadoActivosFijos> ListarActivosFijos(int ubicacionId);
        string crearRevisionActivoFijoDetalle(int RevisionActivoFijoId);
    }
}
