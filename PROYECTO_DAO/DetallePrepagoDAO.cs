using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using ENTIDADES;
using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class DetallePrepagoDAO
    {
        public Boolean Agregar(DetallePrepago oDetalle)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKDETALLEPREPAGO.paAgregar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("prepago", OracleType.Number);
            oCommand.Parameters[0].Value = oDetalle.Prepago;
            oCommand.Parameters.Add("proveedor", OracleType.Number);
            oCommand.Parameters[1].Value = oDetalle.CodProveedor;
            oCommand.Parameters.Add("factura", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oDetalle.NumFactura;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[3].Value = oDetalle.Monto;
            oCommand.Parameters.Add("abono", OracleType.Number);
            oCommand.Parameters[4].Value = oDetalle.Abono;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[5].Value = oDetalle.Saldo;
            oCommand.Parameters.Add("indiceFact", OracleType.Number);
            oCommand.Parameters[6].Value = oDetalle.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oDetalle.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Quitar(Double indice, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKDETALLEPREPAGO.paQuitar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Cerrar(Double indice, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKDETALLEPREPAGO.paCerrar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet consultar(String proveedor, Double prepago, string moneda, String pNo_cia)
        {
            String sql = "SELECT DETPRE_PREPAGO, DETPRE_PROVEEDOR, DETPRE_FACTURA, DETPRE_MONTO, DETPRE_ABONO, DETPRE_SALDO, DETPRE_INDICEfactura FROM TBL_DETALLE_PREPAGO DPP, TBL_PREPAGOS_PROVEEDORES PPP where dpp.no_cia = '" + pNo_cia + "' and dpp.no_cia = ppp.no_cia and DETPRE_PREPAGO='" + prepago + "' and DETPRE_ESTADO='FP'and detpre_prepago= ppp.pre_id and ppp.pre_moneda='" + moneda + "' and upper(DETPRE_PROVEEDOR)=upper('" + proveedor + "')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta(String proveedor, Double prepago, string moneda, String pNo_cia)
        {
            String sql = "SELECT DETPRE_PREPAGO guia, PROV_NOMBRE proveedor, DETPRE_FACTURA factura , DETPRE_MONTO monto , DETPRE_SALDO saldo , DETPRE_ABONO abono , TO_CHAR(sysdate,'DD/MM/YYYY') fecha , PRE_MONEDA moneda , GAS_NOMBRE gasto, EMPR_NOMBRE, EMPR_LOGO, EMPR_DIRECCION ||' - Telefono: '||EMPR_TELEFONO EMPR_OTROS, user usuario FROM TBL_DETALLE_PREPAGO DPP , TBL_PREPAGOS_PROVEEDORES PPP , TBL_PROVEEDOR p , TBL_GASTOS g , TBL_FACTURAS_PENDIENTE_PAGO FPP, TBL_EMPRESA e WHERE dpp.no_cia = '" + pNo_cia + "' and dpp.no_cia = ppp.no_cia and dpp.no_cia = p.no_cia and dpp.no_cia = g.no_cia and dpp.no_cia = fpp.no_cia and fpp.no_cia = e.no_cia and DETPRE_FACTURA = FACPAG_NUM_FACTURA AND GAS_CODIGO = FACPAG_TIPO_GASTO AND prov_linea =PRE_PROVEEDOR AND pre_id = '" + prepago + "' AND detpre_prepago = pre_id AND DETPRE_ESTADO ='FP' AND pre_moneda ='" + moneda + "' AND DETPRE_PROVEEDOR = " + proveedor + " and facpag_proveedor= pre_proveedor and facpag_estado = 1";
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
