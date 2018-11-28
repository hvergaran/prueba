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
    public class CN_Paquete
    {
        //Encapsular variables
        private CD_Paquete objDato = new CD_Paquete();//instancia a la capa datos


        public DataTable MostrarPaquetes()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
    }
}
