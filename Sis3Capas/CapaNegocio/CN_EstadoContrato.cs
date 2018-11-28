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
    public class CN_EstadoContrato
    {
        private CD_EstadoContrato objDato = new CD_EstadoContrato();//instancia a la capa datos 

        public DataTable MostrarEstadoContrato()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
        public void InsertarEstadoContrato(string descripcion)
        {

            objDato.Insertar(descripcion);
        }

        public void EditarEstadoContrato(string descripcion, string id)
        {
            objDato.Editar(descripcion, Convert.ToInt32(id));
        }

        public void EliminarEstadoContrato(string id)
        {

            objDato.Eliminar(Convert.ToInt32(id));
        }

    }


}
