using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace CapaDatos
{
    public class CD_Colegios
    {
        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        System.Data.DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        
        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from colegio");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string razon_social, string nombre_encargado, string email_encargado)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into colegio(ID_COLEGIO,RAZON_SOCIAL_COLEGIO,DIRECCION_COLEGIO,RUT_SOSTENEDOR) values(ID_COLEGIO_SEQ.nextval,:razon,:nombre,:correo)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":razon", razon_social);
            comando.Parameters.Add(":nombre", nombre_encargado);
            comando.Parameters.Add(":correo", email_encargado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string razon_social, string nombre_encargado, string email_encargado, int id)
        {


            OracleCommand comando = new OracleCommand("update colegio set RAZON_SOCIAL_COLEGIO=:razon,DIRECCION_COLEGIO=:nombre,RUT_SOSTENEDOR=:correo where ID_COLEGIO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":razon", razon_social);
            comando.Parameters.Add(":nombre", nombre_encargado);
            comando.Parameters.Add(":correo", email_encargado);
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from colegio where id_colegio=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
