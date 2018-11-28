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
    public class CD_EstadoContrato
    {

        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from ESTADO_CONTRATO");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string descripcion)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into ESTADO_CONTRATO(ID_CONTRATO,DESCRIPCION) values(ID_ESTADOS_SEQ.nextval,:descripcion)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":descripcion", descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string descripcion, int id)
        {


            OracleCommand comando = new OracleCommand("update ESTADO_CONTRATO set DESCRIPCION=:descripcion where ID_CONTRATO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":descripcion", descripcion);
            comando.Parameters.Add("id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from ESTADO_CONTRATO where ID_CONTRATO=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
