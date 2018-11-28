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
    public class CN_Usuarios
    {
        //Encapsular variables
        private CD_Usuarios objDato = new CD_Usuarios();//instancia a la capa datos de empleado
        //Variables
        private String _Usuario;//Este variable tendra el valor de no ha ingresado usuario........tendra el valor del texbox enviado del fomrilario
        private String _Contraseña;
        //todas las demas...
        //METODOS GET Y SET -->para el manejo de variables
        public String Usuario
        {
            set {
                if (value == "Usuario") { _Usuario = "no ha ingresado usuario"; }
                else { _Usuario = value; }
            }
            get { return _Usuario; }
        }
        public String Contraseña
        {
            set {
                if (value == "Contraseña") _Contraseña = "Ingrese su contraseña";
                else _Contraseña = value;
            }
            get { return _Contraseña; }
        }
        //CONTRUCTOR 
        public CN_Usuarios() { }
        //FUNCIONES O METODOS
        public OracleDataReader IniciarSesion() {

            OracleDataReader Loguear;
            Loguear=objDato.iniciarSesion(Usuario,Contraseña);
            return Loguear;
        }

        public DataTable MostrarUser()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }

        public DataTable MostrarApoderados()
        {
            DataTable tabla = new DataTable();
            tabla = objDato.MostrarApoderado();
            return tabla;
        }

        public DataTable MostrarEjecutivo()
        {
            DataTable tabla = new DataTable();
            tabla = objDato.MostrarEjecutivo();
            return tabla;
        }

        public DataTable MostrarEncargado()
        {
            DataTable tabla = new DataTable();
            tabla = objDato.MostrarEncargado();
            return tabla;
        }

        public void InsertarUser(string nombre, string apellido, string correo, string password, string idPerfil)
        {

            objDato.Insertar(nombre, apellido, correo, password, Convert.ToInt32(idPerfil));
        }
        
        public void EditarUser(string nombre, string apellido, string correo, string password, string idPerfil, string id)
        {
            objDato.Editar(nombre, apellido, correo, password, Convert.ToInt32(idPerfil), Convert.ToInt32(id));
        }

        public void EliminarUser(string id)
        {

            objDato.Eliminar(Convert.ToInt32(id));
        }


    }
}
