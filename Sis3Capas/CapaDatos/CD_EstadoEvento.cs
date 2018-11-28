using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CapaDatos
{
    public class CD_EstadoEvento
    {

        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from estado_evento");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string descripcion)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into ESTADO_EVENTO(ID_ESTADO_EVENTO,DESCRIPCION_ESTADO_EVENTO,ACTIVE) values(ID_ESTADOS_SEQ.nextval,:descripcion,1)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":descripcion", descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string descripcion, int id)
        {


            OracleCommand comando = new OracleCommand("update estado_evento set DESCRIPCION_ESTADO_EVENTO=:descripcion where ID_ESTADO_EVENTO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":descripcion", descripcion);
            comando.Parameters.Add("id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from estado_evento where ID_ESTADO_EVENTO=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
