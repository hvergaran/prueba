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
    public class CD_Contratos
    {
        private CD_Conexion conexion = new CD_Conexion();

        OracleDataReader leer;
        System.Data.DataTable tabla = new DataTable();
        OracleCommand comando = new OracleCommand();


        public DataTable Mostrar()
        {
            OracleCommand comando = new OracleCommand("select * from contrato");
            comando.Connection = conexion.AbrirConexion();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string codigo, string fechaInc, string fechaMeta, int montoMeta, string fechaFinal, int idCurso, int idUsuario, int idEstado, int idPaquete)
        {
            //PROCEDIMNIENTO

            OracleCommand comando = new OracleCommand("insert into contrato(ID_CONTRATO,CODIGO,FECHA_INCORPORACION,FECHA_META,MONTO_META,FECHA_FINAL,MONTO_ACTUAL_CONTRATO,FK_ID_CURSO,FK_ID_PROMOTOR,FK_ID_CLIENTE,FK_ID_ESTADO_CONTRATO,FK_ID_PAQUETE)" +
                " values(ID_CONTRATO_SEQ.nextval,:codigo,TO_DATE(:fechaInc, 'DD/MM/YYYY'),TO_DATE(:fechaMeta, 'DD/MM/YYYY'),:montoMeta,TO_DATE(:fechaFinal, 'DD/MM/YYYY'),0,:idColegio,:idUsuario,:idEstado,1,:idPaquete)");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":codigo", codigo);
            comando.Parameters.Add(":fechaInc", fechaInc);
            comando.Parameters.Add(":fechaMeta", fechaMeta);
            comando.Parameters.Add(":montoMeta", montoMeta);
            comando.Parameters.Add(":fechaFinal", fechaFinal);
            //comando.Parameters.Add(":montoActual", montoActual);
            comando.Parameters.Add(":idColegio", idCurso);
            comando.Parameters.Add(":idUsuario", idUsuario);
            comando.Parameters.Add(":idEstado", idEstado);
            comando.Parameters.Add(":idPaquete", idPaquete);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

           /* OracleCommand comando = new OracleCommand("insert into contrato(id_contrato,fecha_incorporacion,fecha_meta,monto_meta,fecha_final,monto_actual_contrato,colegio_id_colegio,fk_id_usuario,fk_id_estado_contrato)" +
                " values(5,TO_DATE(:fechaInc, 'DD/MM/YYYY HH24:MI:SS'),TO_DATE(:fechaMeta, 'DD/MM/YYYY HH24:MI:SS'),:montoMeta,TO_DATE(:fechaFinal, 'DD/MM/YYYY HH24:MI:SS'),:montoActual,:idColegio,:idUsuario,:idEstado)");
            */

        }

        public void Editar(int id,string fechaInc, string fechaMeta, int montoMeta, string fechaFinal, int idColegio, int idUsuario, int idEstado, int idPaquete)
        {


            OracleCommand comando = new OracleCommand("update CONTRATO set FECHA_INCORPORACION=TO_DATE(:fechaInc, 'DD/MM/YYYY'),FECHA_META=TO_DATE(:fechaMeta, 'DD/MM/YYYY'),MONTO_META=:montoMeta,FECHA_FINAL=TO_DATE(:fechaFinal, 'DD/MM/YYYY'),FK_ID_CURSO=:idColegio,FK_ID_PROMOTOR=:idUsuario,FK_ID_CLIENTE=:idEstado,FK_ID_PAQUETE=:idPaquete where ID_CONTRATO=:id");
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":fechaInc", fechaInc);
            comando.Parameters.Add(":fechaMeta", fechaMeta);
            comando.Parameters.Add(":montoMeta", montoMeta);
            comando.Parameters.Add(":fechaFinal", fechaFinal);
            //comando.Parameters.Add(":montoActual", montoActual);
            comando.Parameters.Add(":idColegio", idColegio);
            comando.Parameters.Add(":idUsuario", idUsuario);
            comando.Parameters.Add(":idEstado", idEstado);
            comando.Parameters.Add(":idPaquete", idPaquete);
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            OracleCommand comando = new OracleCommand("delete from CONTRATO where ID_CONTRATO=:id");

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Add(":id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}

