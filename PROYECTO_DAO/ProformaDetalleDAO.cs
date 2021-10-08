using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;

namespace PROYECTO_DAO
{
    public class ProformaDetalleDAO
    {
        public Boolean Agregar(ProformaDetalle oProformaDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMADETALLE.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indiceProforma", OracleType.Number);
            oCommand.Parameters[0].Value = oProformaDetalle.IndiceProforma;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[1].Value = oProformaDetalle.Cantidad;
            oCommand.Parameters.Add("medida", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oProformaDetalle.Medida;
            oCommand.Parameters.Add("codArticulo", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProformaDetalle.CodArticulo;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProformaDetalle.Descripcion;
            oCommand.Parameters.Add("precioUnitario", OracleType.Number);
            oCommand.Parameters[5].Value = oProformaDetalle.PrecioUnitario;
            oCommand.Parameters.Add("SubTotal", OracleType.Number);
            oCommand.Parameters[6].Value = oProformaDetalle.SubTotal;
            oCommand.Parameters.Add("monto_IV", OracleType.Number);
            oCommand.Parameters[7].Value = oProformaDetalle.Monto_IV;
            oCommand.Parameters.Add("PrecioTotal", OracleType.Number);
            oCommand.Parameters[8].Value = oProformaDetalle.PrecioTotal;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oProformaDetalle.Usuario;

                  oCommand.Parameters.Add("tipoPrecio", OracleType.Number);
            oCommand.Parameters[10].Value = oProformaDetalle.TipoPrecio;

           
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[11].Value = oProformaDetalle.Descuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oProformaDetalle.No_cia;
            oCommand.Parameters.Add("IVI", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oProformaDetalle.IVI;
            

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(ProformaDetalle oProformaDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMADETALLE.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProformaDetalle.Indice;
            oCommand.Parameters.Add("indiceProforma", OracleType.Number);
            oCommand.Parameters[1].Value = oProformaDetalle.IndiceProforma;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[2].Value = oProformaDetalle.Cantidad;
            oCommand.Parameters.Add("medida", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProformaDetalle.Medida;
            oCommand.Parameters.Add("codArticulo", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProformaDetalle.CodArticulo;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oProformaDetalle.Descripcion;
            oCommand.Parameters.Add("precioUnitario", OracleType.Number);
            oCommand.Parameters[6].Value = oProformaDetalle.PrecioUnitario;
            oCommand.Parameters.Add("SubTotal", OracleType.Number);
            oCommand.Parameters[7].Value = oProformaDetalle.SubTotal;
            oCommand.Parameters.Add("monto_IV", OracleType.Number);
            oCommand.Parameters[8].Value = oProformaDetalle.Monto_IV;
            oCommand.Parameters.Add("PrecioTotal", OracleType.Number);
            oCommand.Parameters[9].Value = oProformaDetalle.PrecioTotal;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oProformaDetalle.Usuario;

            oCommand.Parameters.Add("tipoPrecio", OracleType.Number);
            oCommand.Parameters[11].Value = oProformaDetalle.TipoPrecio;

            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[12].Value = oProformaDetalle.Descuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oProformaDetalle.No_cia;
            oCommand.Parameters.Add("IVI", OracleType.NVarChar);
            oCommand.Parameters[14].Value = oProformaDetalle.IVI;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(ProformaDetalle oProformaDetalle)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMADETALLE.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProformaDetalle.Indice;
            oCommand.Parameters.Add("indiceProforma", OracleType.Number);
            oCommand.Parameters[1].Value = oProformaDetalle.IndiceProforma;
            oCommand.Parameters.Add("cantidad", OracleType.Number);
            oCommand.Parameters[2].Value = oProformaDetalle.Cantidad;
            oCommand.Parameters.Add("codArticulo", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProformaDetalle.CodArticulo;       
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProformaDetalle.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consulta(int indiceProforma, String pNo_cia)
        {
            String sql = "select detfac_numerolinea, detfac_codigo, detfac_cantidad, detfac_descripcion, DETFAC_SUBTOTAL, DETFAC_MONTO_IV, detfac_medida, DETFAC_PRECIO_UNITARIO, detfac_tipoprecio, DETFAC_DESCUENTO, DETFAC_PRECIO_TOTAL, ART_CODIGO, detfac_ivi, art_impuestos from TBL_PROFORMA_DETALLE pf, TBL_SERVICIOS ar where ar.no_cia = '" + pNo_cia + "' and ar.no_cia = pf.no_cia and DETFAC_INDICEFACTURA = " + indiceProforma + " and ART_INDICE = detfac_codigo ORDER BY detfac_numerolinea desc";
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
