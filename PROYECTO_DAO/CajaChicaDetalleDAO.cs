using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data.OracleClient;
using System.Data;

namespace PROYECTO_DAO
{
    public class CajaChicaDetalleDAO
    {
        public Boolean Insertar(CajaChicaDetalle oCajaChicaDetalle, String pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCAJA_CHICA_DETALLE.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("caja", OracleType.Number);
            oCommand.Parameters[0].Value = oCajaChicaDetalle.Caja;
            oCommand.Parameters.Add("movimiento", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCajaChicaDetalle.Movimiento;
            oCommand.Parameters.Add("credito", OracleType.Number);
            oCommand.Parameters[2].Value = oCajaChicaDetalle.Credito;
            oCommand.Parameters.Add("debito", OracleType.Number);
            oCommand.Parameters[3].Value = oCajaChicaDetalle.Debito;
            oCommand.Parameters.Add("empleado", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCajaChicaDetalle.Empleado;
            oCommand.Parameters.Add("documento", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oCajaChicaDetalle.Documento;
            oCommand.Parameters.Add("tipomovimiento", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oCajaChicaDetalle.TipoMovimiento;
            oCommand.Parameters.Add("justificacion", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oCajaChicaDetalle.Justificacion;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[8].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento LibroCuentassado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(string tipomovimiento, String pNo_cia)
        {
            String sql = "SELECT  DETCAJ_FECHAMOVIMIENTO, DETCAJ_EMPLEADO,'CAJA CHICA' emp_nombre, DETCAJ_DOCUMENTO , DETCAJ_CREDITO, DETCAJ_DEBITO, DETCAJ_MOVIMIENTO, DETCAJ_JUSTIFICACION FROM TBL_CAJA_CHICA_DETALLE, tbl_caja_chica where DETCAJ_CAJA = CAJ_LINEA and CAJ_ESTADO =1 and caj_usuarioabre = user ";
            if (!String.IsNullOrEmpty(tipomovimiento))
                sql += " and regexp_like(DETCAJ_MOVIMIENTO, '" + tipomovimiento + "','i') ";
            sql += " and no_cia = '" + pNo_cia + "' order by DETCAJ_FECHAMOVIMIENTO, DETCAJ_MOVIMIENTO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Consultar(String pNo_cia)
        {
            String sql = "SELECT  DETCAJ_FECHAMOVIMIENTO, DETCAJ_EMPLEADO,'CAJA CHICA' emp_nombre, DETCAJ_DOCUMENTO , DETCAJ_CREDITO, DETCAJ_DEBITO, DETCAJ_MOVIMIENTO, DETCAJ_JUSTIFICACION FROM TBL_CAJA_CHICA_DETALLE, tbl_caja_chica where DETCAJ_CAJA = CAJ_LINEA and CAJ_ESTADO =1 and caj_usuarioabre = user  and no_cia = '" + pNo_cia + "' order by DETCAJ_FECHAMOVIMIENTO, DETCAJ_MOVIMIENTO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DateTime FechaAperturaCaja(string caja, String pNo_cia)
        {
            String sql = "SELECT CAJ_FECHAAPERTURA FROM tbl_caja_chica where CAJ_LINEA =" + caja + " and CAJ_ESTADO =1 and caj_usuarioabre = user and no_cia = '" + pNo_cia + "'";
            DateTime oDateTime = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return oDateTime;
        }

        public DataSet Caja(String pNo_cia)
        {
            String sql = "SELECT CAJ_LINEA, CAJ_MONTO, CAJ_SALDO FROM tbl_caja_chica where CAJ_ESTADO =1 and caj_usuarioabre = user and no_cia = '" + pNo_cia + "'";
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

        public DateTime fecha()
        {
            String sql = "SELECT sysdate from dual";
            DateTime oDataSet = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return oDataSet;
        }

        public string Moneda(String pNo_cia)
        {
            String sql = "SELECT CAJ_Moneda FROM TBL_CAJA_CHICA where CAJ_ESTADO=1 and caj_usuarioabre = user and no_cia = '" + pNo_cia + "'";
            String oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
            return oDataSet;
        }
    }
}
