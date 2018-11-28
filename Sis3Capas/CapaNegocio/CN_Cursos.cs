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
    public class CN_Cursos
    {
        //Encapsular variables
        private CD_Cursos objDato = new CD_Cursos();//instancia a la capa datos

        public DataTable MostrarCursos()
        {
            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
    }
}
