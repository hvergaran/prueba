using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Perfil
    {

        OracleDataReader leer;
        DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();
        private CD_Conexion conexion = new CD_Conexion();

        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from perfil");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
