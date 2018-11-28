using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace CapaDatos
{
    public class CD_Usuarios
    {
        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        public OracleDataReader iniciarSesion(string user, string pass)
        {

            //OracleCommand comando = new OracleCommand("SPIniciarSesion", );
            // comando.CommandType = CommandType.StoredProcedure;
            //conexion.AbrirConexion();
            //OracleConnection Conexion = new OracleConnection("DATA SOURCE=Turismo;PASSWORD=avaras08;USER ID=PORTAFOLIO");
            //Conexion.Open();
            OracleCommand comandoLogin = new OracleCommand("select * from usuario where CORREO_USUARIO =:usuario and PASSWORD_USUARIO= :contrasena");
            comandoLogin.Connection = conexion.AbrirConexion();
            comandoLogin.Parameters.Add(":usuario", user);
            comandoLogin.Parameters.Add(":contrasena", pass);
            leer = comandoLogin.ExecuteReader();
            return leer;
        }
        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from usuario");
            comando.Connection = conexion.AbrirConexion();            
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarApoderado()
        {
            OracleCommand comando = new OracleCommand("select * from usuario where FK_ID_PERFIL = 2");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarEjecutivo()
        {
            OracleCommand comando = new OracleCommand("select * from usuario where FK_ID_PERFIL = 3");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarEncargado()
        {
            OracleCommand comando = new OracleCommand("select * from usuario where FK_ID_PERFIL = 4");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string apellido, string correo, string password, int idPerfil)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into USUARIO(ID_USUARIO,NOMBRE_USUARIO,APELLIDO_USUARIO,CORREO_USUARIO,PASSWORD_USUARIO,ACTIVE,FK_ID_PERFIL) values(ID_USUARIO_SEQ.nextval,:nombre, :apellido, :correo, :password, 1, :idPerfil)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":nombre", nombre);
            comando.Parameters.Add(":apellido", apellido);
            comando.Parameters.Add(":correo", correo);
            comando.Parameters.Add(":password", password);
            comando.Parameters.Add(":idPerfil", idPerfil);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        
        public void Editar(string nombre, string apellido, string correo, string password, int idPerfil, int id)
        {

            
            OracleCommand comando = new OracleCommand("update USUARIO set NOMBRE_USUARIO=:nombre,APELLIDO_USUARIO=:apellido,CORREO_USUARIO=:correo,PASSWORD_USUARIO=:password,FK_ID_PERFIL=:idPerfil where ID_USUARIO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":nombre", nombre);
            comando.Parameters.Add(":apellido", apellido);
            comando.Parameters.Add(":correo", correo);
            comando.Parameters.Add(":password", password);
            comando.Parameters.Add(":idPerfil", idPerfil);
            comando.Parameters.Add("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from usuario where id_usuario=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
