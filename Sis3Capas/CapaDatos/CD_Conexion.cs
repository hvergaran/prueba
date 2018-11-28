using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CapaDatos
{
    public class CD_Conexion
    {
        //private SqlConnection Conexion = new SqlConnection("Server=localhost;DataBase=bd_turismo;Integrated Security=true");
        OracleConnection Conexion = new OracleConnection("DATA SOURCE=Tour;PASSWORD=avaras08;USER ID=TOUR");

        public OracleConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public OracleConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
