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
    public class CN_EstadoEvento
    {
        private CD_EstadoEvento objDato = new CD_EstadoEvento();//instancia a la capa datos 

        public DataTable MostrarEstadoEvento()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
        public void InsertarEstadoEvento(string descripcion)
        {

            objDato.Insertar(descripcion);
        }

        public void EditarEstadoEvento(string descripcion, string id)
        {
            objDato.Editar(descripcion, Convert.ToInt32(id));
        }

        public void EliminarEstadoEvento(string id)
        {

            objDato.Eliminar(Convert.ToInt32(id));
        }

    }
}
