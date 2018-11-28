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
    public class CN_Alumnos
    {
        //Encapsular variables
        private CD_Alumnos objDato = new CD_Alumnos();//instancia a la capa datos de empleado

        public void InsertarAlumno(string nombre, string apellido, string rut, string idApoderado, string idContrato)
        {
            objDato.Insertar(nombre, apellido, rut, Convert.ToInt32(idApoderado), Convert.ToInt32(idContrato));
        }

        public DataTable MostrarAlumnos()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }

        public void EliminarALumno(string id)
        {
            objDato.Eliminar(Convert.ToInt32(id));
        }

        public void EditarAlumno(string nombre, string apellido, string rut, string idApoderado, string idContrato, string id)
        {
            objDato.Editar(nombre, apellido, rut, Convert.ToInt32(idApoderado), Convert.ToInt32(idContrato), Convert.ToInt32(id));
        }

    }
}
