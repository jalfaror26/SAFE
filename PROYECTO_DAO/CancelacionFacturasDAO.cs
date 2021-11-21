using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using ENTIDADES;
using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class CancelacionFacturasDAO
    {
        
        public DataSet Consulta(String cliente, String pNo_cia, String pmoneda)
        {
            String sql = "select facp_numero_factura as factura, facp_moneda as moneda, facp_tipo_cambio as tc, facp_monto as monto, facp_saldo as saldo, to_char(facp_fecha_factura,'dd/MM/yyyy') as fechafac, to_char(facp_fecha_vence, 'dd/MM/yyyy') as fechavence, FACP_TIPODOCUMENTO from TBL_FACTURAS_PENDIENTES_CTA FPC where fpc.no_cia = '" + pNo_cia + "' and facp_estado = 1 and facp_saldo <> 0 and (facp_estatus = 'PE' or facp_estatus = 'FT') and facp_cliente = '" + cliente + "' and facp_moneda = '" + pmoneda + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public Boolean insertar(Transaccion oTransaccion)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCANCELACIONFACTURA.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("fechaRegistro", OracleType.DateTime);
            oCommand.Parameters[0].Value = oTransaccion.FechaRegistro;
            oCommand.Parameters.Add("idCliente", OracleType.Number);
            oCommand.Parameters[1].Value = oTransaccion.IdCliente;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oTransaccion.NumFactura;
            oCommand.Parameters.Add("tipoTrans", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oTransaccion.Tipotransaccion;
            oCommand.Parameters.Add("documento", OracleType.Number);
            oCommand.Parameters[4].Value = oTransaccion.NumDocumento;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[5].Value = oTransaccion.Monto;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oTransaccion.Moneda;
            oCommand.Parameters.Add("texto", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oTransaccion.Texto;
            oCommand.Parameters.Add("saldoAnterior", OracleType.Number);
            oCommand.Parameters[8].Value = oTransaccion.SaldoAnterior;
            oCommand.Parameters.Add("saldoActual", OracleType.Number);
            oCommand.Parameters[9].Value = oTransaccion.SaldoActual;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oTransaccion.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[11].Value = oTransaccion.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean modificaFacturas(Transaccion oTransaccion, String tipoPago)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCANCELACIONFACTURA.paModificaFacturas";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oTransaccion.NumFactura;
            oCommand.Parameters.Add("saldoActual", OracleType.Number);
            oCommand.Parameters[1].Value = oTransaccion.SaldoActual;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oTransaccion.Usuario;
            oCommand.Parameters.Add("tipoPago", OracleType.NVarChar);
            oCommand.Parameters[3].Value = tipoPago;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oTransaccion.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean modificaRecibos(int numRecibo, Double saldoActual, String usuario, String tipoPago, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCANCELACIONFACTURA.paModificaRecibos";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numRecibo", OracleType.Number);
            oCommand.Parameters[0].Value = numRecibo;
            oCommand.Parameters.Add("saldoActual", OracleType.Number);
            oCommand.Parameters[1].Value = saldoActual;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[2].Value = usuario;
            oCommand.Parameters.Add("tipoPago", OracleType.NVarChar);
            oCommand.Parameters[3].Value = tipoPago;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
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
    }
}
