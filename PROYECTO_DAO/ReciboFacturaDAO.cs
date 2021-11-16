using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;

using System.Data.OracleClient;
using System.Data;

namespace PROYECTO_DAO
{
    public class ReciboFacturaDAO
    {
        public Boolean Agregar(ReciboFactura oReciboFactura)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECIBOFACTURA.paAgregar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("factura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oReciboFactura.Factura;
            oCommand.Parameters.Add("recibo", OracleType.Number);
            oCommand.Parameters[1].Value = oReciboFactura.Recibo;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oReciboFactura.Moneda;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[3].Value = oReciboFactura.Monto;
            oCommand.Parameters.Add("monto_original", OracleType.Number);
            oCommand.Parameters[4].Value = oReciboFactura.MontoOriginal;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oReciboFactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Quitar(ReciboFactura oReciboFactura)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKRECIBOFACTURA.paQuitar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("factura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oReciboFactura.Factura;
            oCommand.Parameters.Add("recibo", OracleType.Number);
            oCommand.Parameters[1].Value = oReciboFactura.Recibo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oReciboFactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String factura, String pNo_Cia)
        {
            String sql = "select RECFAC_FACTURA,recfac_recibo,REC_NUMERO, FAC_MONEDA RECFAC_MONEDA, recfac_monto from TBL_RECIBOS_FACTURA RF, TBL_RECIBOS_DINERO RD, TBL_FACTURA F where rd.no_Cia = '" + pNo_Cia + "' and rd.no_cia = rf.no_cia and rd.no_Cia = f.no_cia and REC_INDICE=recfac_recibo  and FAC_NUMERO=RECFAC_FACTURA and RECFAC_FACTURA = '" + factura + "'";

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
