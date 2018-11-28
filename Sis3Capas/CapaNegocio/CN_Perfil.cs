using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Perfil
    {
        private CD_Perfil objDato = new CD_Perfil();

        public DataTable MostrarPerfil()
        {

            DataTable tabla = new DataTable();
            tabla = objDato.Mostrar();
            return tabla;
        }
    }
}
