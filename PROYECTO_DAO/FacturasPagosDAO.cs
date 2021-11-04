using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;
using System.Data;


namespace PROYECTO_DAO
{
    public class FacturasPagosDAO
    {

        public Boolean Insertar(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPAGOS.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.CodProveedor;
            oCommand.Parameters.Add("flujo", OracleType.Number);
            oCommand.Parameters[2].Value = ofactura.Flujo;
            oCommand.Parameters.Add("tipogasto", OracleType.NVarChar);
            oCommand.Parameters[3].Value = ofactura.TipoGasto;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[4].Value = ofactura.Moneda;
            oCommand.Parameters.Add("tipoCambio", OracleType.Number);
            oCommand.Parameters[5].Value = ofactura.Tipocambio;
            oCommand.Parameters.Add("fechaEmision", OracleType.DateTime);
            oCommand.Parameters[6].Value = ofactura.FechaEmision;
            oCommand.Parameters.Add("fechaVence", OracleType.DateTime);
            oCommand.Parameters[7].Value = ofactura.FechaVence;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[8].Value = ofactura.Monto;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[9].Value = ofactura.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[10].Value = ofactura.Estado;
            oCommand.Parameters.Add("responsable", OracleType.NVarChar);
            oCommand.Parameters[11].Value = ofactura.Responsable;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[12].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPAGOS.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = ofactura.Indice;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[2].Value = ofactura.Saldo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean ModificarExistente(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPAGOS.paModificarExistente";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.CodProveedor;
            oCommand.Parameters.Add("flujo", OracleType.Number);
            oCommand.Parameters[2].Value = ofactura.Flujo;
            oCommand.Parameters.Add("tipogasto", OracleType.NVarChar);
            oCommand.Parameters[3].Value = ofactura.TipoGasto;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[4].Value = ofactura.Moneda;
            oCommand.Parameters.Add("tipoCambio", OracleType.Number);
            oCommand.Parameters[5].Value = ofactura.Tipocambio;
            oCommand.Parameters.Add("fechaEmision", OracleType.DateTime);
            oCommand.Parameters[6].Value = ofactura.FechaEmision;
            oCommand.Parameters.Add("fechaVence", OracleType.DateTime);
            oCommand.Parameters[7].Value = ofactura.FechaVence;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[8].Value = ofactura.Monto;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[9].Value = ofactura.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[10].Value = ofactura.Estado;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[11].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPAGOS.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = ofactura.Indice;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = ofactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Vincular(string indice, string factura, int vinculo, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPAGOS.paVincular";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = indice;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = factura;
            oCommand.Parameters.Add("vinculo", OracleType.Number);
            oCommand.Parameters[2].Value = vinculo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet consultarFactura(String factura, string prov, String pNo_cia)
        {
            String sql = "select facpag_num_factura num, facpag_estado estado, facpag_estatus estatus from TBL_FACTURAS_PENDIENTE_PAGO FPP where fpp.no_cia = '" + pNo_cia + "' and upper(facpag_num_factura) = '" + factura.Trim().ToUpper() + "' and upper(facpag_proveedor) = '" + prov.ToUpper() + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Consultar(String proveedor, string estatus, String pNo_cia)
        {
            String sql = "SELECT facpag_num_factura, facpag_indice, gas_nombre, FACPAG_MONTO, facpag_proveedor, FACPAG_SALDO, FACPAG_FECHA_EMISION, facpag_fecha_vence, facpag_moneda, facpag_tipo_cambio, facpag_estatus, prov_nombre, facpag_flujo, FACPAG_TIPO_GASTO from TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_PROVEEDOR p, TBL_GASTOS g WHERE p.no_cia = '" + pNo_cia + "' and p.no_cia = fpp.no_Cia and p.no_cia = g.no_Cia and facpag_tipo_gasto= gas_codigo and facpag_proveedor=prov_linea AND facpag_proveedor='" + proveedor + "' AND facpag_estado=1 AND facpag_estatus='" + estatus + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta(String proveedor, string estatus, string moneda, string vinculo, String pNo_cia)
        {

            String sql = "";
            if (moneda.Equals("CRC"))
                sql = "SELECT FACPAG_NUM_FACTURA, FACPAG_PROVEEDOR, p.prov_nombre, FACPAG_FLUJO, FACPAG_TIPO_GASTO, g.gas_nombre, FACPAG_MONEDA,facpag_tipo_cambio, FACPAG_FECHA_EMISION, FACPAG_FECHA_VENCE, FACPAG_MONTO, FACPAG_SALDO, FACPAG_ESTATUS, FACPAG_INDICE FROM TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_PROVEEDOR p , TBL_GASTOS g where fpp.no_cia = '" + pNo_cia + "' and fpp.no_cia = p.no_Cia and fpp.no_cia = g.no_cia and fpp.facpag_tipo_gasto = g.gas_codigo and fpp.facpag_proveedor=p.prov_linea and upper(fpp.facpag_proveedor)='" + proveedor + "' and fpp.facpag_estado=1 and fpp.facpag_estatus='" + estatus + "' and fpp.facpag_moneda= '" + moneda + "' and FACPAG_SALDO >= 1 and facpag_vinculada= '" + vinculo + "'";
            else
                sql = "SELECT FACPAG_NUM_FACTURA, FACPAG_PROVEEDOR, p.prov_nombre, FACPAG_FLUJO, FACPAG_TIPO_GASTO, g.gas_nombre, FACPAG_MONEDA,facpag_tipo_cambio, FACPAG_FECHA_EMISION, FACPAG_FECHA_VENCE, FACPAG_MONTO, FACPAG_SALDO, FACPAG_ESTATUS, FACPAG_INDICE FROM TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_PROVEEDOR p , TBL_GASTOS g where fpp.no_cia = '" + pNo_cia + "' and fpp.no_cia = p.no_Cia and fpp.no_cia = g.no_cia and fpp.facpag_tipo_gasto = g.gas_codigo and fpp.facpag_proveedor=p.prov_linea and upper(fpp.facpag_proveedor)='" + proveedor + "' and fpp.facpag_estado=1 and fpp.facpag_estatus='" + estatus + "' and fpp.facpag_moneda= '" + moneda + "' and facpag_vinculada= '" + vinculo + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public String consultarDias(String proveedor, String pNo_cia)
        {
            String sql = "select prov_Dias from TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and prov_linea = '" + proveedor + "'";
            String oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
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

        public DataSet ConsultarGuiasCanceladas(string prov, string moneda, String pNo_cia)
        {
            String sql = "SELECT distinct PRE_ID, PRE_PROVEEDOR, PRE_MONEDA, to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy') PRE_FECHA_REGISTRO,  pre_monto_total from TBL_PREPAGOS_PROVEEDORES PPP, TBL_PAGOS_PROVEEDORES PP where ppp.no_cia = '" + pNo_cia + "' and ppp.no_cia = pp.no_cia and PRE_ESTADO='GC' and PRE_PROVEEDOR='" + prov + "' and PRE_MONEDA='" + moneda + "'";

            //  sql += " and TO_CHAR(PRE_FECHA_REGISTRO,'mm/yyyy')=(SELECT DISTINCT case when CIECTA_MES<10 then '0'||CIECTA_MES ||'/' ||CIECTA_ANO else CIECTA_MES ||'/' ||CIECTA_ANO end FROM TBL_CIERRES_CUENTA WHERE CIECTA_ESTADO='ABIERTO') ";

            sql += " and PAG_ID=PRE_ID order by PRE_ID desc";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarGuiasCanceladas(String prov, string moneda, int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT distinct PRE_ID, PRE_PROVEEDOR, PRE_MONEDA, to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy') PRE_FECHA_REGISTRO, pre_monto_total from TBL_PREPAGOS_PROVEEDORES PPP where ppp.no_cia = '" + pNo_cia + "' and PRE_ESTADO='GC' and PRE_PROVEEDOR='" + prov + "' and PRE_MONEDA='" + moneda + "' and ";
            if (tipo == 1)
                sql += " regexp_like(PRE_ID,'" + palabra + "','i')";
            else if (tipo == 2)
                sql += " regexp_like(to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy'),'" + palabra + "','i')";
            else if (tipo == 3)
                sql = "SELECT distinct PRE_ID, PRE_PROVEEDOR, pre_moneda, to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy') PRE_FECHA_REGISTRO, pre_monto_total from TBL_PREPAGOS_PROVEEDORES PPP, TBL_DETALLE_PREPAGO DPP WHERE dpp.no_cia = '" + pNo_cia + "' and dpp.no_cia = ppp.no_cia and PRE_ESTADO ='GC' AND PRE_PROVEEDOR='" + prov + "' and pre_moneda   ='" + moneda + "' and detpre_prepago=pre_id and regexp_like(DETPRE_FACTURA,'" + palabra + "','i')";
            sql += " order by PRE_ID desc";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
    }
}
