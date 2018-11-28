using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CapaNegocio
{
    public class CN_EstadoCuota
    {
        private CD_EstadoCuota objDato = new CD_EstadoCuota();//instancia a la capa datos 

        public DataTable MostrarEstadoCuota()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
        public void InsertarEstadoCuota(string descripcion)
        {

            objDato.Insertar(descripcion);
        }

        public void EditarEstadoCuota(string descripcion, string id)
        {
            objDato.Editar(descripcion, Convert.ToInt32(id));
        }

        public void EliminarEstadoCuota(string id)
        {

            objDato.Eliminar(Convert.ToInt32(id));
        }

    }
}
