using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;

namespace PROYECTO_DAO
{
    public class FacturaDetalleDAO
    {
        public Boolean Agregar(FacturaDetalle oFacturaDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURADETALLE.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indiceFactura", OracleType.Number);
            oCommand.Parameters[0].Value = oFacturaDetalle.IndiceFactura;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[1].Value = oFacturaDetalle.Cantidad;
            oCommand.Parameters.Add("medida", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oFacturaDetalle.Medida;
            oCommand.Parameters.Add("codServicio", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oFacturaDetalle.CodServicio;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oFacturaDetalle.Descripcion;
            oCommand.Parameters.Add("precioUnitario", OracleType.Number);
            oCommand.Parameters[5].Value = oFacturaDetalle.PrecioUnitario;
            oCommand.Parameters.Add("SubTotal", OracleType.Number);
            oCommand.Parameters[6].Value = oFacturaDetalle.Subtotal;
            oCommand.Parameters.Add("monto_IV", OracleType.Number);
            oCommand.Parameters[7].Value = oFacturaDetalle.MontoIV;
            oCommand.Parameters.Add("PrecioTotal", OracleType.Number);
            oCommand.Parameters[8].Value = oFacturaDetalle.PrecioTotal;

            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[9].Value = oFacturaDetalle.Descuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oFacturaDetalle.No_cia;
            oCommand.Parameters.Add("IVI", OracleType.NVarChar);
            oCommand.Parameters[11].Value = oFacturaDetalle.IVI;
            oCommand.Parameters.Add("pCOD_CABYS", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oFacturaDetalle.Cod_cabys;
            
            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(FacturaDetalle oFacturaDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURADETALLE.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oFacturaDetalle.Indice;
            oCommand.Parameters.Add("indiceFactura", OracleType.Number);
            oCommand.Parameters[1].Value = oFacturaDetalle.IndiceFactura;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[2].Value = oFacturaDetalle.Cantidad;
            oCommand.Parameters.Add("medida", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oFacturaDetalle.Medida;
            oCommand.Parameters.Add("codServicio", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oFacturaDetalle.CodServicio;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oFacturaDetalle.Descripcion;
            oCommand.Parameters.Add("precioUnitario", OracleType.Number);
            oCommand.Parameters[6].Value = oFacturaDetalle.PrecioUnitario;
            oCommand.Parameters.Add("SubTotal", OracleType.Number);
            oCommand.Parameters[7].Value = oFacturaDetalle.Subtotal;
            oCommand.Parameters.Add("monto_IV", OracleType.Number);
            oCommand.Parameters[8].Value = oFacturaDetalle.MontoIV;
            oCommand.Parameters.Add("PrecioTotal", OracleType.Number);
            oCommand.Parameters[9].Value = oFacturaDetalle.PrecioTotal;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[10].Value = oFacturaDetalle.Descuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[11].Value = oFacturaDetalle.No_cia;
            oCommand.Parameters.Add("IVI", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oFacturaDetalle.IVI;
            oCommand.Parameters.Add("pCOD_CABYS", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oFacturaDetalle.Cod_cabys;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(FacturaDetalle oFacturaDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURADETALLE.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oFacturaDetalle.Indice;
            oCommand.Parameters.Add("indiceFactura", OracleType.Number);
            oCommand.Parameters[1].Value = oFacturaDetalle.IndiceFactura;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[2].Value = oFacturaDetalle.Cantidad;
            oCommand.Parameters.Add("codServicio", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oFacturaDetalle.CodServicio;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oFacturaDetalle.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consulta(int indiceFactura, String pNo_cia)
        {
            String sql = "select detfac_numerolinea, detfac_codigo, detfac_cantidad, detfac_descripcion, DETFAC_SUBTOTAL, DETFAC_MONTO_IV, detfac_medida, DETFAC_PRECIO_UNITARIO, DETFAC_DESCUENTO, DETFAC_PRECIO_TOTAL detfac_total, SER_CODIGO, detfac_ivi, SER_impuestos, SER_TIPO_CODIGO, fd.Cod_cabys from TBL_FACTURA_DETALLE fd, TBL_SERVICIOS ar where ar.no_cia = '" + pNo_cia + "' and ar.no_cia = fd.no_cia and DETFAC_INDICEFACTURA = '" + indiceFactura + "' and SER_INDICE = detfac_codigo ORDER BY detfac_numerolinea desc";
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
