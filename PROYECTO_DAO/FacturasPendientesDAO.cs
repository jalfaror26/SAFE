using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;
using System.Data;


namespace PROYECTO_DAO
{
    public class FacturasPendientesDAO
    {

        public Boolean insertar(FacturasPendientes ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPENDIENTES.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("cliente", OracleType.Number);
            oCommand.Parameters[0].Value = ofactura.IdCliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.Nombre;
            oCommand.Parameters.Add("fechaRegistro", OracleType.DateTime);
            oCommand.Parameters[2].Value = ofactura.FechaActual;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[3].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("nombrede", OracleType.NVarChar);
            oCommand.Parameters[4].Value = ofactura.Anombrede1;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[5].Value = ofactura.Moneda;
            oCommand.Parameters.Add("tipoCambio", OracleType.Number);
            oCommand.Parameters[6].Value = ofactura.Tipocambio;
            oCommand.Parameters.Add("fechaFactura", OracleType.DateTime);
            oCommand.Parameters[7].Value = ofactura.FechaEmision;
            oCommand.Parameters.Add("fechaVence", OracleType.DateTime);
            oCommand.Parameters[8].Value = ofactura.FechaVence;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[9].Value = ofactura.Exento;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[10].Value = ofactura.Subtotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[11].Value = ofactura.Impuesto;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[12].Value = ofactura.Monto;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[14].Value = ofactura.Saldo;
            oCommand.Parameters.Add("estatus", OracleType.NVarChar);
            oCommand.Parameters[15].Value = ofactura.Estatus;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[16].Value = ofactura.Observacion;
            oCommand.Parameters.Add("tipodocumento", OracleType.NVarChar);
            oCommand.Parameters[19].Value = ofactura.TipoDocumento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[21].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(FacturasPendientes ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPENDIENTES.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("nombrede", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.Anombrede1;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[4].Value = ofactura.Saldo;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[6].Value = ofactura.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[7].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(FacturasPendientes ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPENDIENTES.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numFactura", OracleType.Number);
            oCommand.Parameters[0].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[2].Value = ofactura.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet consultar(String cliente, String pNo_cia)
        {
            String sql = "select facp_cliente, facp_nombre, facp_fecha_registro, facp_numero_factura, facp_moneda, facp_tipo_cambio, facp_fecha_factura, facp_fecha_vence, facp_excento, facp_subtotal, facp_impuesto, facp_monto, facp_retencion, facp_saldo, facp_estatus, FACP_OBSERVACION, facp_aplica_retencion, facp_retencion_real, facp_tipodocumento, facp_anombrede, Cli_Dias, facp_indice from TBL_FACTURAS_PENDIENTES_CTA FPC, TBL_CLIENTES cl where fpc.no_cia = '" + pNo_cia + "' and fpc.no_cia= cl.no_cia and facp_Estatus in ('PE','FT') and facp_saldo > 0 and facp_estado = 1 and Cli_linea = facp_cliente and facp_cliente = '" + cliente + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarEstado(String Factura, String pNo_cia)
        {
            String sql = "select facp_estatus from TBL_FACTURAS_PENDIENTES_CTA FPC where fpc.no_cia = '" + pNo_cia + "' and facp_numero_factura = '" + Factura + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultarDias(String cliente, String pNo_cia)
        {
            String sql = "select Cli_Dias from TBL_CLIENTES c WHERE c.no_cia = '" + pNo_cia + "' and  Cli_linea = '" + cliente + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultarTipoCambios(String pNo_cia)
        {
            String sql = "select Cambio_Dolar from TBL_TIPOS_CAMBIO tc where tc.no_cia = '" + pNo_cia + "' and  to_char(fecha_registro,'dd/mm/yyyy') = to_char(sysdate,'dd/mm/yyyy')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataTable ConsultaMontoSaldo(String factura, String pNo_cia)
        {
            String sql = "select facp_monto, facp_saldo from TBL_FACTURAS_PENDIENTES_CTA FPC where fpc.no_cia = '" + pNo_cia + "' and FACP_NUMERO_FACTURA = '" + factura + "'";
            DataTable oTabla = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oTabla;
        }

        public Boolean Anular(String factura, String pNo_cia)
        {
            String sql = "Update TBL_FACTURAS_PENDIENTES_CTA FPC set FACP_Estatus = 'AN', facp_monto = 0, facp_saldo = 0 where fpc.no_cia = '" + pNo_cia + "' and FACP_NUMERO_FACTURA = '" + factura + "'";
            OracleDAO.getInstance().EjecutarSQL(sql);
            return !OracleDAO.getInstance().ErrorSQL;
        }
        public Boolean DeshacerAnular(String factura, string monto, string saldo, String pNo_cia)
        {
            String sql = "Update TBL_FACTURAS_PENDIENTES_CTA FPC set FACP_Estatus = 'PE', facp_monto = '" + monto + "', facp_saldo = '" + saldo + "' where fpc.no_cia = '" + pNo_cia + "' and FACP_NUMERO_FACTURA = '" + factura + "'";
            OracleDAO.getInstance().EjecutarSQL(sql);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Incobrable(String factura, String pNo_cia)
        {
            String sql = "Update TBL_FACTURAS_PENDIENTES_CTA FPC set FACP_Estatus = 'IN', facp_saldo = 0 where fpc.no_cia = '" + pNo_cia + "' and FACP_NUMERO_FACTURA = '" + factura + "'";
            OracleDAO.getInstance().EjecutarSQL(sql);
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

        public DateTime Fecha()
        {
            String sql = "select sysdate from dual";
            DateTime oDataSet = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return oDataSet;
        }
    }
}
