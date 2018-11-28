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
    public class CD_EstadoCuota
    {
        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from estado_cuota");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string descripcion)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into ESTADO_CUOTA(ID_ESTADO_CUOTA,DESCRIPCION_ESTADO_CUOTA,ACTIVE) values(ID_ESTADOS_SEQ.nextval,:descripcion,1)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":descripcion", descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string descripcion, int id)
        {


            OracleCommand comando = new OracleCommand("update estado_cuota set DESCRIPCION_ESTADO_CUOTA=:descripcion where ID_ESTADO_CUOTA=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":descripcion", descripcion);
            comando.Parameters.Add("id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from estado_cuota where ID_ESTADO_CUOTA=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
