using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;
using System.Collections;

namespace PROYECTO_DAO
{
    public class CotizacionDAO
    {
        public DataTable Agregar(Cotizacion oCotizacion)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMA.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("PROFORMA", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oCotizacion.NumCotizacion;
            oCommand.Parameters.Add("fechafac", OracleType.DateTime);
            oCommand.Parameters[1].Value = oCotizacion.FechaCotizacion;
            oCommand.Parameters.Add("cliente", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oCotizacion.Cliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oCotizacion.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCotizacion.Telefono;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oCotizacion.Ubicacion;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oCotizacion.Moneda;
            oCommand.Parameters.Add("tipocambio", OracleType.Number);
            oCommand.Parameters[7].Value = oCotizacion.Tipocambio;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[8].Value = 0;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[9].Value = oCotizacion.SubTotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[10].Value = oCotizacion.Impuesto;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[11].Value = oCotizacion.Descuento;
            oCommand.Parameters.Add("total", OracleType.Number);
            oCommand.Parameters[12].Value = oCotizacion.Total;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[13].Value = oCotizacion.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[14].Value = oCotizacion.Estado;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oCotizacion.Observacion;
            oCommand.Parameters.Add("TIPO", OracleType.NVarChar);
            oCommand.Parameters[16].Value = oCotizacion.Tipo;
            oCommand.Parameters.Add("INDICEDOCUMENTO", OracleType.Number);
            oCommand.Parameters[17].Value = oCotizacion.IndiceDocumento;
            oCommand.Parameters.Add("tIPODOCUMENTO", OracleType.NVarChar);
            oCommand.Parameters[18].Value = oCotizacion.TipoDocumento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oCotizacion.No_cia;

            oCommand.Parameters.Add(Util.CrearCursor());

            DataTable odata = OracleDAO.getInstance().EjecutarSQLDataTable(oCommand);

            return odata;
        }

        public Boolean Modificar(Cotizacion oCotizacion)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMA.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCotizacion.Indice;
            oCommand.Parameters.Add("PROFORMA", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCotizacion.NumCotizacion;
            oCommand.Parameters.Add("fechafac", OracleType.DateTime);
            oCommand.Parameters[2].Value = oCotizacion.FechaCotizacion;
            oCommand.Parameters.Add("cliente", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oCotizacion.Cliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCotizacion.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oCotizacion.Telefono;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oCotizacion.Ubicacion;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oCotizacion.Moneda;
            oCommand.Parameters.Add("tipocambio", OracleType.Number);
            oCommand.Parameters[8].Value = oCotizacion.Tipocambio;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[9].Value = 0;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[10].Value = oCotizacion.SubTotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[11].Value = oCotizacion.Impuesto;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[12].Value = oCotizacion.Descuento;
            oCommand.Parameters.Add("total", OracleType.Number);
            oCommand.Parameters[13].Value = oCotizacion.Total;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[14].Value = oCotizacion.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oCotizacion.Estado;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[16].Value = oCotizacion.Observacion;
            oCommand.Parameters.Add("TIPO", OracleType.NVarChar);
            oCommand.Parameters[17].Value = oCotizacion.Tipo;
            oCommand.Parameters.Add("pordescuento", OracleType.Number);
            oCommand.Parameters[18].Value = oCotizacion.PorDescuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oCotizacion.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Cotizacion oCotizacion)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMA.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCotizacion.Indice;
            oCommand.Parameters.Add("PROFORMA", OracleType.Number);
            oCommand.Parameters[1].Value = oCotizacion.NumCotizacion;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oCotizacion.No_cia;


            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataTable consultarRegistros(String pNo_cia)
        {
            String sql = "select * from TBL_PROFORMA P where p.no_cia = '" + pNo_cia + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable consultaCantProformas(String pNo_cia)
        {
            String sql = "select count(1) from TBL_PROFORMA p WHERE p.no_cia = '" + pNo_cia + "' order by 1";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultaCotizaciones(String pNo_cia)
        {
            String sql = "select fac_numero||'  -  ' ||fac_estado as cod, fac_nombre as descripcion from TBL_PROFORMA P where p.no_cia = '" + pNo_cia + "' order by to_number(fac_numero) desc";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultaCotizacion(String numProforma, String pNo_cia)
        {
            String sql = "SELECT fac_linea, fac_fecha, fac_cliente, fac_nombre, fac_telefono, fac_ubicacion, fac_moneda, fac_tipo_cambio, fac_excento, fac_subtotal, fac_impuesto, fac_descuento, fac_total, fac_saldo, fac_estado, fac_observacion, fac_tipo, fac_vendedor, fac_indicedocumento, fac_tipodocumento, fac_pordescuento, CASE WHEN (FAC_USUARIOMODIFICA IS NULL) THEN FAC_USUARIOCREA ELSE FAC_USUARIOMODIFICA END FAC_USUARIO FROM TBL_PROFORMA P where p.no_cia = '" + pNo_cia + "' and fac_numero = '" + numProforma + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }
        public Int32 ModificaComentario(String numProforma, String comentario, String pNo_cia)
        {
            String sql = "update TBL_PROFORMA P set fac_observacion = '" + comentario + "' where p.no_cia = '" + pNo_cia + "' and fac_numero = '" + numProforma + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Int32 ModificaEstadoProforma(Cotizacion oProforma)
        {
            String sql = "update TBL_PROFORMA P set fac_estado = 'EMITIDA', Fac_Subtotal = " + oProforma.SubTotal + ", fac_impuesto =" + oProforma.Impuesto + ", Fac_descuento = " + oProforma.Descuento + ", fac_total = " + oProforma.Total + ", fac_saldo = " + oProforma.Total + " where p.no_cia = '" + oProforma.No_cia + "' and fac_linea = " + oProforma.Indice + " and fac_numero = '" + oProforma.NumCotizacion + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public DataTable ConsultaCliente(String codigo, String pNo_cia)
        {
            String sql = "select cli_nombre, cli_telefono, cli_fax, cli_ubicacion, cli_dias, CLI_IDENTIFICACION from TBL_CLIENTES c WHERE c.no_cia = '" + pNo_cia + "' and  cli_estado = 1 and cli_linea = '" + codigo + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable Consulta(int tipo, String palabra, String pNo_cia)
        {
            String sql = "select fac_numero||'  -  ' ||fac_estado as cod, fac_nombre as descripcion from TBL_PROFORMA p where p.no_cia = '" + pNo_cia + "' and ";
            if (tipo == 1)
                sql += " regexp_like(fac_numero,'" + palabra + "','i')";
            else
                sql += " regexp_like(fac_nombre,'" + palabra + "','i')";
            sql += " order by c desc";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable TieneLotes(String codigo, String factura)
        {
            String sql = "select count(*) from tbl_lotes where lot_articulo = '" + codigo + "' and lot_factura = '" + factura + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public String DescError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Boolean Error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }

        public DataTable ConsultaUltima(String pNo_cia)
        {
            String sql = "select max(fac_numero) fac_numero from TBL_PROFORMA p where p.no_cia = '" + pNo_cia + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }
    }
}
