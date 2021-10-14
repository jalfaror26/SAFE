using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;

using System.Data;
using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class TipoCambioDAO
    {

        public Boolean Agregar(TipoCambio oTipo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKTIPOCAMBIO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("dolar", OracleType.Number);
            oCommand.Parameters[0].Value = oTipo.Dolar;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oTipo.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oTipo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(TipoCambio oTipo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKTIPOCAMBIO.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("dolar", OracleType.Number);
            oCommand.Parameters[0].Value = oTipo.Dolar;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oTipo.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oTipo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Consulta(String pNo_cia) {
            String sql = "select fecha_registro from TBL_TIPOS_CAMBIO tc where tc.no_cia = '" + pNo_cia + "' and  to_char(fecha_registro,'dd/mm/yyyy') = to_char(sysdate,'dd/mm/yyyy')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            if(oDataSet.Tables[0].Rows.Count > 0)
                return false;
            else
                return true;
        }

        public DateTime fecha()
        {
            String sql = "select sysdate from dual";
            DateTime ofecha = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return ofecha;
        }

        public DataSet TipoCambio(String pNo_cia)
        {
            String sql = "select cambio_dolar, fecha_registro from TBL_TIPOS_CAMBIO tc where tc.no_cia = '" + pNo_cia + "' and  to_char(fecha_registro,'dd/mm/yyyy') = to_char(sysdate,'dd/mm/yyyy')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public Double Dolar(String pNo_cia)
        {
            String sql = "select cambio_dolar from TBL_TIPOS_CAMBIO tc where tc.no_cia = '" + pNo_cia + "' and  to_char(fecha_registro,'dd/mm/yyyy') = to_char(sysdate,'dd/mm/yyyy')";
            Double oDouble = OracleDAO.getInstance().EjecutarSQLScalarDouble(sql);
            return oDouble;
        }

        public DataSet TipoCambio(String fecha, String pNo_cia)
        {
            String sql = "select cambio_dolar from TBL_TIPOS_CAMBIO tc where tc.no_cia = '" + pNo_cia + "' and  '" + fecha + "' = to_char(fecha_registro,'dd/mm/yyyy')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public String DescError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Boolean Error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }
    }
}
