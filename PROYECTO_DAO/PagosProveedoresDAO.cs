using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data.OracleClient;
using System.Data;

namespace PROYECTO_DAO
{
    public class PagosProveedoresDAO
    {

        public Boolean Insertar(PagosProveedores oPagosProveedores, string guia, string numFactura, double saldo)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "PCKPagosProveedores.paInsertar";

            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oPagosProveedores.Proveedor;

            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[1].Value = guia;

            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[2].Value = numFactura;
            oCommand.Parameters.Add("saldoFactura", OracleType.Number);
            oCommand.Parameters[3].Value = saldo;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public int InsertarPago(PagosProveedores oPagosProveedores, int guia)
        {
            OracleCommand oCommand = new OracleCommand();
            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "indicelibro";
            oParametro.Value = 0;

            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "PCKPagosProveedores.paInsertarPago";

            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oPagosProveedores.Proveedor;
            oCommand.Parameters.Add("tipoPago", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oPagosProveedores.TipoPago;
            oCommand.Parameters.Add("flujo", OracleType.Number);
            oCommand.Parameters[2].Value = oPagosProveedores.Flujo;
            oCommand.Parameters.Add("documento", OracleType.Number);
            oCommand.Parameters[3].Value = oPagosProveedores.Documento;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[4].Value = oPagosProveedores.Monto;
            oCommand.Parameters.Add("detallePago", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oPagosProveedores.DetallePago;
            
            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[6].Value = guia;
            oCommand.Parameters.Add(oParametro);
            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return int.Parse(oParametro.Value.ToString());
        }

        public Boolean InsertarPagoCheque(PagosProveedores oPagosProveedores, int guia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "PCKPagosProveedores.paInsertarPagoCheque";

            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oPagosProveedores.Proveedor;
            oCommand.Parameters.Add("tipoPago", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oPagosProveedores.TipoPago;
            oCommand.Parameters.Add("flujo", OracleType.Number);
            oCommand.Parameters[2].Value = oPagosProveedores.Flujo;
            oCommand.Parameters.Add("documento", OracleType.Number);
            oCommand.Parameters[3].Value = oPagosProveedores.Documento;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[4].Value = oPagosProveedores.Monto;
            oCommand.Parameters.Add("detallePago", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oPagosProveedores.DetallePago;
            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[6].Value = guia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }

        public String DescError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Double Saldo(string factura)
        {
            String sql = "select facpag_saldo from tbl_facturas_pendientes_pago where upper(facpag_num_factura)=upper('" + factura + "')";
            double saldo = OracleDAO.getInstance().EjecutarSQLScalarDouble(sql);
            return saldo;
        }

               public int Eliminar(int indice)
        {
            String sql = "delete from TBL_PAGOS_PROVEEDORES where PAG_ID = " + indice;
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Boolean Cancelar(int guia, String usuario)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKROLLBACKPAGOS.parollback";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[0].Value = guia;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = usuario;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public int CrearGuia(GuiaPrepagoProveedor oGuia, Double monto)
        {

            OracleCommand oCommand = new OracleCommand();

            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "guia";
            oParametro.Value = 0;
            oCommand.CommandText = "PCKPLANILLAS.paCrearGuiaPrepagoProveedor";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oGuia.Proveedor;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oGuia.Moneda;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oGuia.Usuario;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[3].Value = monto;
            oCommand.Parameters.Add(oParametro);
            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            if (OracleDAO.getInstance().ErrorSQL)
                OracleDAO.getInstance().EjecutarSQL("rollback");

            return int.Parse(oParametro.Value.ToString());
        }

        public Boolean CrearPago(FacturasPago oFacturaPago, DetallePrepago oDetallePrepago)
        {
            int indiceDetalle = 0;

            OracleCommand oCommand = new OracleCommand();
            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "indice";
            oParametro.Value = 0;

            oCommand.CommandText = "PCKPLANILLAS.paInsertarFacturaPendientePago";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oFacturaPago.NumFactura;
            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oFacturaPago.CodProveedor;
            oCommand.Parameters.Add("tipogasto", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oFacturaPago.TipoGasto;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oFacturaPago.Moneda;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[4].Value = oFacturaPago.Monto;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oFacturaPago.Usuario;
            oCommand.Parameters.Add("responsable", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oFacturaPago.Responsable;
            oCommand.Parameters.Add(oParametro);
            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            indiceDetalle = int.Parse(oParametro.Value.ToString());
            if (OracleDAO.getInstance().ErrorSQL)
                OracleDAO.getInstance().EjecutarSQL("rollback");
            else
            {
                oCommand = new OracleCommand();
                oCommand.CommandText = "PCKPLANILLAS.paAgregarDetallePrepago";
                oCommand.CommandType = CommandType.StoredProcedure;

                oCommand.Parameters.Add("prepago", OracleType.Number);
                oCommand.Parameters[0].Value = oDetallePrepago.Prepago;
                oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
                oCommand.Parameters[1].Value = oDetallePrepago.CodProveedor;
                oCommand.Parameters.Add("factura", OracleType.NVarChar);
                oCommand.Parameters[2].Value = oDetallePrepago.NumFactura;
                oCommand.Parameters.Add("monto", OracleType.Number);
                oCommand.Parameters[3].Value = oDetallePrepago.Monto;
                oCommand.Parameters.Add("indiceDetalle", OracleType.Number);
                oCommand.Parameters[4].Value = indiceDetalle;
                OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
                if (OracleDAO.getInstance().ErrorSQL)
                    OracleDAO.getInstance().EjecutarSQL("rollback");
            }
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataTable TipoCambio()
        {
            string sql = "SELECT CAMBIO_DOLAR FROM TBL_TIPOS_CAMBIO where trunc(FECHA_REGISTRO)=trunc(sysdate)";
            DataTable oTabla = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oTabla;
        }

        public double Dolar()
        {
            String sql = "SELECT CAMBIO_DOLAR fROM TBL_TIPOS_CAMBIO where trunc(FECHA_REGISTRO)= trunc(sysdate)";
            Double dolar = OracleDAO.getInstance().EjecutarSQLScalarDouble(sql);
            return dolar;
        }
    }
}
