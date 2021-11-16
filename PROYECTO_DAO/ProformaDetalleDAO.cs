using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;

namespace PROYECTO_DAO
{
    public class CotizacionDetalleDAO
    {
        public Boolean Agregar(CotizacionDetalle oCotizacionDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMADETALLE.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indiceProforma", OracleType.Number);
            oCommand.Parameters[0].Value = oCotizacionDetalle.IndiceProforma;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[1].Value = oCotizacionDetalle.Cantidad;
            oCommand.Parameters.Add("medida", OracleType.NVarChar);
            oCommand.Parameters[2].Value = "";
            oCommand.Parameters.Add("codArticulo", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oCotizacionDetalle.CodServicio;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCotizacionDetalle.Descripcion;
            oCommand.Parameters.Add("precioUnitario", OracleType.Number);
            oCommand.Parameters[5].Value = oCotizacionDetalle.PrecioUnitario;
            oCommand.Parameters.Add("SubTotal", OracleType.Number);
            oCommand.Parameters[6].Value = oCotizacionDetalle.SubTotal;
            oCommand.Parameters.Add("monto_IV", OracleType.Number);
            oCommand.Parameters[7].Value = oCotizacionDetalle.Monto_IV;
            oCommand.Parameters.Add("PrecioTotal", OracleType.Number);
            oCommand.Parameters[8].Value = oCotizacionDetalle.PrecioTotal;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oCotizacionDetalle.Usuario;

                  oCommand.Parameters.Add("tipoPrecio", OracleType.Number);
            oCommand.Parameters[10].Value = oCotizacionDetalle.TipoPrecio;

           
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[11].Value = oCotizacionDetalle.Descuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oCotizacionDetalle.No_cia;
            oCommand.Parameters.Add("IVI", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oCotizacionDetalle.IVI;
            

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(CotizacionDetalle oCotizacionDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMADETALLE.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCotizacionDetalle.Indice;
            oCommand.Parameters.Add("indiceProforma", OracleType.Number);
            oCommand.Parameters[1].Value = oCotizacionDetalle.IndiceProforma;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[2].Value = oCotizacionDetalle.Cantidad;
            oCommand.Parameters.Add("medida", OracleType.NVarChar);
            oCommand.Parameters[3].Value = "";
            oCommand.Parameters.Add("codArticulo", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCotizacionDetalle.CodServicio;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oCotizacionDetalle.Descripcion;
            oCommand.Parameters.Add("precioUnitario", OracleType.Number);
            oCommand.Parameters[6].Value = oCotizacionDetalle.PrecioUnitario;
            oCommand.Parameters.Add("SubTotal", OracleType.Number);
            oCommand.Parameters[7].Value = oCotizacionDetalle.SubTotal;
            oCommand.Parameters.Add("monto_IV", OracleType.Number);
            oCommand.Parameters[8].Value = oCotizacionDetalle.Monto_IV;
            oCommand.Parameters.Add("PrecioTotal", OracleType.Number);
            oCommand.Parameters[9].Value = oCotizacionDetalle.PrecioTotal;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oCotizacionDetalle.Usuario;

            oCommand.Parameters.Add("tipoPrecio", OracleType.Number);
            oCommand.Parameters[11].Value = oCotizacionDetalle.TipoPrecio;

            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[12].Value = oCotizacionDetalle.Descuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oCotizacionDetalle.No_cia;
            oCommand.Parameters.Add("IVI", OracleType.NVarChar);
            oCommand.Parameters[14].Value = oCotizacionDetalle.IVI;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(CotizacionDetalle oCotizacionDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMADETALLE.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCotizacionDetalle.Indice;
            oCommand.Parameters.Add("indiceProforma", OracleType.Number);
            oCommand.Parameters[1].Value = oCotizacionDetalle.IndiceProforma;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[2].Value = oCotizacionDetalle.Cantidad;
            oCommand.Parameters.Add("codArticulo", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oCotizacionDetalle.CodServicio;       
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCotizacionDetalle.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consulta(int indiceProforma, String pNo_cia)
        {
            String sql = "select detfac_numerolinea, detfac_codigo, detfac_cantidad, detfac_descripcion, DETFAC_SUBTOTAL, DETFAC_MONTO_IV, detfac_medida, DETFAC_PRECIO_UNITARIO, detfac_tipoprecio, DETFAC_DESCUENTO, DETFAC_PRECIO_TOTAL, SER_CODIGO, detfac_ivi, SER_impuestos from TBL_PROFORMA_DETALLE pf, TBL_SERVICIOS ar where ar.no_cia = '" + pNo_cia + "' and ar.no_cia = pf.no_cia and DETFAC_INDICEFACTURA = " + indiceProforma + " and SER_INDICE = detfac_codigo ORDER BY detfac_numerolinea desc";
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
