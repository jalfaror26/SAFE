using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;

namespace PROYECTO_DAO
{
    public class RecordatorioDAO
    {
        public Boolean Guardar(Recordatorio oRecordatorio)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECORDATORIO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oRecordatorio.Linea;
            oCommand.Parameters.Add("detalle", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oRecordatorio.Detalle;
            oCommand.Parameters.Add("fecha", OracleType.DateTime);
            oCommand.Parameters[2].Value = oRecordatorio.FechaHora;
            oCommand.Parameters.Add("indiceproviene", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oRecordatorio.IndiceProviene;
            oCommand.Parameters.Add("detalleproviene", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oRecordatorio.DetalleProviene;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oRecordatorio.Usuario;
            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oRecordatorio.Tipo;
            oCommand.Parameters.Add("persona", OracleType.Number);
            oCommand.Parameters[7].Value = oRecordatorio.Persona;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oRecordatorio.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Recordatorioado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Recordatorio oRecordatorio)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKRECORDATORIO.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oRecordatorio.Linea;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oRecordatorio.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oRecordatorio.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Recordatorioado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String usuario, DateTime fecha, String pNo_cia)
        {
            String sql = "select rec_indice,rec_detalle, TO_CHAR(REC_FECHA,'HH:mi am') hora FROM TBL_RECORDATORIO r where r.no_cia = '" + pNo_cia + "' and  rec_usuario ='" + usuario + "' and rec_estadoregistro=1 and rec_estado='PEN' and trunc(rec_fecha)='" + fecha.ToShortDateString() + "' order by rec_fecha";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public Boolean CrearComentario(Recordatorio oRecordatorio, String detalle)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECORDATORIO.paCrearComentario";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oRecordatorio.Linea;
            oCommand.Parameters.Add("detalle", OracleType.NVarChar);
            oCommand.Parameters[1].Value = detalle;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oRecordatorio.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Recordatorioado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public String DescError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Boolean Error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean CambiarEstado(string estado, int linea, String pNo_cia)
        {
            OracleDAO.getInstance().EjecutarSQL("update TBL_RECORDATORIO r set rec_estado='" + estado + "' where r.no_cia = '" + pNo_cia + "' and rec_indice= '" + linea + "'");
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Posponer(Recordatorio oRecordatorio)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECORDATORIO.paPosponer";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oRecordatorio.Linea;
            oCommand.Parameters.Add("fecha", OracleType.DateTime);
            oCommand.Parameters[1].Value = oRecordatorio.FechaHora;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oRecordatorio.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Recordatorioado
            return !OracleDAO.getInstance().ErrorSQL;
        }
    }
}
