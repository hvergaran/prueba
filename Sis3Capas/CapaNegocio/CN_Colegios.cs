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
    public class CN_Colegios
    {
        //Encapsular variables
        private CD_Colegios objDato = new CD_Colegios();//instancia a la capa datos de empleado
        
        public CN_Colegios() { }
        //FUNCIONES O METODOS
        
        public DataTable MostrarColegio()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
        public void InsertarColegio(string razonSocial, string nombre, string correo)
        {

            objDato.Insertar(razonSocial,nombre, correo);
        }
        
        public void EditarColegio(string razonSocial, string nombre, string correo, string id)
        {
            objDato.Editar(razonSocial, nombre, correo, Convert.ToInt32(id));
        }

        public void EliminarColegio(string id)
        {

            objDato.Eliminar(Convert.ToInt32(id));
        }
    }
}
