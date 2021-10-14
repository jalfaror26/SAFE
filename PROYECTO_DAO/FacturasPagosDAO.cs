using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
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
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[11].Value = ofactura.Usuario;
            oCommand.Parameters.Add("responsable", OracleType.NVarChar);
            oCommand.Parameters[12].Value = ofactura.Responsable;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPagos.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = ofactura.Indice;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[2].Value = ofactura.Saldo;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[3].Value = ofactura.Usuario;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean ModificarExistente(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPagos.paModificarExistente";
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
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[11].Value = ofactura.Usuario;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(FacturasPago ofactura)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPagos.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = ofactura.Indice;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = ofactura.NumFactura;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[2].Value = ofactura.Usuario;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Vincular(string indice, string factura, int vinculo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURASPagos.paVincular";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = indice;
            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = factura;
            oCommand.Parameters.Add("vinculo", OracleType.Number);
            oCommand.Parameters[2].Value = vinculo;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet consultarFactura(String factura, string prov)
        {
            String sql = "select facpag_num_factura num, facpag_estado estado, facpag_estatus estatus from tbl_facturas_pendientes_pago where upper(facpag_num_factura) = '" + factura.Trim().ToUpper() + "' and upper(facpag_proveedor) = '" + prov.ToUpper() + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultar(String proveedor, string estatus)
        {
            String sql = "SELECT facpag_num_factura, facpag_indice, gas_nombre, FACPAG_MONTO, facpag_proveedor, FACPAG_SALDO, FACPAG_FECHA_EMISION, facpag_fecha_vence, facpag_moneda, facpag_tipo_cambio, facpag_estatus, prov_nombre, facpag_flujo, FACPAG_TIPO_GASTO from tbl_facturas_pendientes_pago, tbl_proveedor, tbl_gastos WHERE facpag_tipo_gasto= gas_codigo and facpag_proveedor=prov_id AND upper(facpag_proveedor)='" + proveedor + "' AND facpag_estado=1 AND facpag_estatus='" + estatus + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultar2(String proveedor, string estatus, string moneda, string vinculo)
        {

            String sql = "";
            if (moneda.Equals("COL"))
                sql = "SELECT FACPAG_NUM_FACTURA, FACPAG_PROVEEDOR, p.prov_nombre, FACPAG_FLUJO, FACPAG_TIPO_GASTO, g.gas_nombre, FACPAG_MONEDA,facpag_tipo_cambio, FACPAG_FECHA_EMISION, FACPAG_FECHA_VENCE, FACPAG_MONTO, FACPAG_SALDO, FACPAG_ESTATUS, FACPAG_INDICE FROM TBL_FACTURAS_PENDIENTES_PAGO fpp, tbl_proveedor p , tbl_gastos g where fpp.facpag_tipo_gasto = g.gas_codigo and fpp.facpag_proveedor=p.prov_id and upper(fpp.facpag_proveedor)='" + proveedor + "' and fpp.facpag_estado=1 and fpp.facpag_estatus='" + estatus + "' and fpp.facpag_moneda= '" + moneda + "' and FACPAG_SALDO >= 1 and facpag_vinculada=" + vinculo;
            else
                sql = "SELECT FACPAG_NUM_FACTURA, FACPAG_PROVEEDOR, p.prov_nombre, FACPAG_FLUJO, FACPAG_TIPO_GASTO, g.gas_nombre, FACPAG_MONEDA,facpag_tipo_cambio, FACPAG_FECHA_EMISION, FACPAG_FECHA_VENCE, FACPAG_MONTO, FACPAG_SALDO, FACPAG_ESTATUS, FACPAG_INDICE FROM TBL_FACTURAS_PENDIENTES_PAGO fpp, tbl_proveedor p , tbl_gastos g where fpp.facpag_tipo_gasto = g.gas_codigo and fpp.facpag_proveedor=p.prov_id and upper(fpp.facpag_proveedor)='" + proveedor + "' and fpp.facpag_estado=1 and fpp.facpag_estatus='" + estatus + "' and fpp.facpag_moneda= '" + moneda + "' and facpag_vinculada=" + vinculo;
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public String consultarDias(String proveedor)
        {
            String sql = "select prov_Dias from Tbl_Proveedor where upper(prov_id) = '" + proveedor + "'";
            String oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
            return oDataSet;
        }

        public String retornaError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Boolean error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet ConsultarGuiasCanceladas(string prov, string moneda)
        {
            String sql = "SELECT distinct PRE_ID, PRE_PROVEEDOR, PRE_MONEDA, to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy') PRE_FECHA_REGISTRO,  pre_monto_total from tbl_prepagos_proveedores,TBL_PAGOS_PROVEEDORES,TBL_CHEQUES where PRE_ESTADO='GC' and PRE_PROVEEDOR='" + prov + "' and PRE_MONEDA='" + moneda + "' and TO_CHAR(PRE_FECHA_REGISTRO,'mm/yyyy')=(SELECT DISTINCT case when CIECTA_MES<10 then '0'||CIECTA_MES ||'/' ||CIECTA_ANO else CIECTA_MES ||'/' ||CIECTA_ANO end FROM TBL_CIERRES_CUENTA WHERE CIECTA_ESTADO='ABIERTO') and PAG_ID=PRE_ID and(PAG_TIPO_PAGO='Transferencia' or PAG_TIPO_PAGO='TRANSFERENCIA' or(PAG_TIPO_PAGO='CHEQUE' and CHK_PAGOS=PRE_ID and CHK_ESTATUS='PENDIENTE')) order by PRE_ID desc";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarGuiasCanceladas(String prov, string moneda, int tipo, String palabra)
        {
            String sql = "SELECT distinct PRE_ID, PRE_PROVEEDOR, PRE_MONEDA, to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy') PRE_FECHA_REGISTRO, pre_monto_total from tbl_prepagos_proveedores where PRE_ESTADO='GC' and PRE_PROVEEDOR='" + prov + "' and PRE_MONEDA='" + moneda + "' and ";
            if (tipo == 1)
                sql += " regexp_like(PRE_ID,'" + palabra + "','i')";
            else if (tipo == 2)
                sql += " regexp_like(to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy'),'" + palabra + "','i')";
            else if (tipo == 3)
                sql = "SELECT distinct PRE_ID, PRE_PROVEEDOR, pre_moneda, to_char(PRE_FECHA_REGISTRO,'dd/mm/yyyy') PRE_FECHA_REGISTRO, pre_monto_total from tbl_prepagos_proveedores,tbl_detalle_prepago WHERE PRE_ESTADO ='GC' AND PRE_PROVEEDOR='" + prov + "' and pre_moneda   ='" + moneda + "' and detpre_prepago=pre_id and regexp_like(DETPRE_FACTURA,'" + palabra + "','i')";
            sql += " order by PRE_ID desc";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
    }
}
