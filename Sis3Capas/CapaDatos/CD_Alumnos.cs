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
    public class CD_Alumnos
    {

        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        System.Data.DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();

        public void Insertar(string nom_alumno, string ape_alumno, string rut_alumno, int id_apoderado, int id_contrato)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into alumno(ID_ALUMNO,NOMBRE_ALUMNO,APELLIDO_ALUMNO,RUT_ALUMNO,FK_ID_USUARIO,FK_ID_CONTRATO)" +
                " values(ID_ALUMNO_SEQ.nextval,:nom,:ape,:rut,:idApo,:idCon)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":nom", nom_alumno);
            comando.Parameters.Add(":ape", ape_alumno);
            comando.Parameters.Add(":rut", rut_alumno);
            comando.Parameters.Add(":idApo", id_apoderado);
            comando.Parameters.Add(":idCon", id_contrato);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from alumno");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from alumno where id_alumno=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(string nombre, string apellido, string rut, int idApoderado, int idContrato, int id)
        {
            OracleCommand comando = new OracleCommand("update alumno set NOMBRE_ALUMNO=:nombre,APELLIDO_ALUMNO=:apellido,RUT_ALUMNO=:rut,FK_ID_USUARIO=:idApoderado,FK_ID_CONTRATO=:idContrato where ID_ALUMNO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":nombre", nombre);
            comando.Parameters.Add(":apellido", apellido);
            comando.Parameters.Add(":rut", rut);
            comando.Parameters.Add(":idApoderado", idApoderado);
            comando.Parameters.Add(":idContrato", idContrato);
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
