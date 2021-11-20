using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;
using System.Collections;

namespace PROYECTO_DAO
{
    public class FacturaDAO
    {
        public DataTable Agregar(Factura oFactura)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURA.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("factura", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oFactura.NumFactura;
            oCommand.Parameters.Add("fechafac", OracleType.DateTime);
            oCommand.Parameters[1].Value = oFactura.FechaFactura;
            oCommand.Parameters.Add("cliente", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oFactura.Cliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oFactura.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oFactura.Telefono;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oFactura.Ubicacion;
            oCommand.Parameters.Add("tipoCredito", OracleType.NVarChar);
            oCommand.Parameters[6].Value = "";
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oFactura.Moneda;
            oCommand.Parameters.Add("tipocambio", OracleType.Number);
            oCommand.Parameters[8].Value = oFactura.Tipocambio;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[9].Value = 0;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[10].Value = oFactura.SubTotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[11].Value = oFactura.Impuesto;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[12].Value = oFactura.Descuento;
            oCommand.Parameters.Add("total", OracleType.Number);
            oCommand.Parameters[13].Value = oFactura.Total;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[14].Value = oFactura.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oFactura.Estado;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[16].Value = oFactura.Observacion;
            oCommand.Parameters.Add("adelanto", OracleType.Number);
            oCommand.Parameters[17].Value = oFactura.Adelanto;
            oCommand.Parameters.Add("FORMAPAGO", OracleType.NVarChar);
            oCommand.Parameters[18].Value = oFactura.FormaPago;
            oCommand.Parameters.Add("TIPO", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oFactura.Tipo;
            oCommand.Parameters.Add("INDICEDOCUMENTO", OracleType.Number);
            oCommand.Parameters[20].Value = oFactura.IndiceDocumento;
            oCommand.Parameters.Add("tIPODOCUMENTO", OracleType.NVarChar);
            oCommand.Parameters[21].Value = oFactura.TipoDocumento;
            oCommand.Parameters.Add("diasCredito", OracleType.Number);
            oCommand.Parameters[22].Value = oFactura.DiasCredito;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[23].Value = oFactura.No_cia;

            oCommand.Parameters.Add(Util.CrearCursor());

            DataTable odata = OracleDAO.getInstance().EjecutarSQLDataTable(oCommand);

            return odata;
        }

        public Boolean Modificar(Factura oFactura)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURA.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oFactura.Indice;
            oCommand.Parameters.Add("factura", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oFactura.NumFactura;
            oCommand.Parameters.Add("fechafac", OracleType.DateTime);
            oCommand.Parameters[2].Value = oFactura.FechaFactura;
            oCommand.Parameters.Add("cliente", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oFactura.Cliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oFactura.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oFactura.Telefono;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oFactura.Ubicacion;
            oCommand.Parameters.Add("tipoCredito", OracleType.NVarChar);
            oCommand.Parameters[7].Value = "";
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oFactura.Moneda;
            oCommand.Parameters.Add("tipocambio", OracleType.Number);
            oCommand.Parameters[9].Value = oFactura.Tipocambio;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[10].Value = 0;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[11].Value = oFactura.SubTotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[12].Value = oFactura.Impuesto;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[13].Value = oFactura.Descuento;
            oCommand.Parameters.Add("total", OracleType.Number);
            oCommand.Parameters[14].Value = oFactura.Total;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[15].Value = oFactura.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[16].Value = oFactura.Estado;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[17].Value = oFactura.Observacion;
            oCommand.Parameters.Add("adelanto", OracleType.Number);
            oCommand.Parameters[18].Value = oFactura.Adelanto;
            oCommand.Parameters.Add("FORMAPAGO", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oFactura.FormaPago;
            oCommand.Parameters.Add("TIPO", OracleType.NVarChar);
            oCommand.Parameters[20].Value = oFactura.Tipo;
            oCommand.Parameters.Add("pordescuento", OracleType.Number);
            oCommand.Parameters[21].Value = oFactura.PorDescuento;
            oCommand.Parameters.Add("diasCredito", OracleType.Number);
            oCommand.Parameters[22].Value = oFactura.DiasCredito;
            oCommand.Parameters.Add("Tipopago", OracleType.NVarChar);
            oCommand.Parameters[23].Value = oFactura.Tipopago;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[24].Value = oFactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Factura oFactura)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFACTURA.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oFactura.Indice;
            oCommand.Parameters.Add("factura", OracleType.Number);
            oCommand.Parameters[1].Value = oFactura.NumFactura;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oFactura.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataTable consultarRegistros(String pNo_cia)
        {
            String sql = "select * from TBL_FACTURA F, TBL_FACTURA_DETALLE fd WHERE f.no_cia = '" + pNo_cia + "' and f.no_cia = fd.no_cia order by 1";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable consultaCantFacturas(String pNo_cia)
        {
            String sql = "select count(1) from TBL_FACTURA f WHERE f.no_cia = '" + pNo_cia + "' order by 1";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultaFacturas(String pNo_cia)
        {
            String sql = "select fac_numero , fac_estado ,  fac_fecha , fac_nombre,FE_CONSECUTIVO, upper(FE_RECEPCION) FE_RECEPCION, decode(FE_COMPROBACION,'por_comprobar','POR COMPROBAR',upper(FE_COMPROBACION)) FE_COMPROBACION from TBL_FACTURA F where f.no_cia = '" + pNo_cia + "' order by to_number(fac_numero) desc";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultaBodegaConsignacion(String codigo, String pNo_cia)
        {
            String sql = "select alm_cliente, Cli_nombre from TBL_BODEGA b, TBL_CLIENTES c where b.no_cia = '" + pNo_cia + "' b.no_cia = c.no_cia and alm_cliente = cli_linea and alm_id = '" + codigo + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultaFactura(String numFactura, String pNo_cia)
        {
            String sql = "SELECT fac_linea, fac_fecha, fac_cliente, fac_nombre, FAC_DIAS_CREDITO,fac_telefono, fac_ubicacion, fac_tipo_credito, fac_moneda, fac_tipo_cambio, fac_excento, fac_subtotal, fac_impuesto, fac_descuento, fac_total, fac_saldo, fac_estado, fac_observacion, fac_adelanto, fac_formapago, fac_tipo, fac_vendedor, fac_indicedocumento, fac_tipodocumento, fac_pordescuento, NVL(FAC_USUARIOMODIFICA,FAC_USUARIOCREA) FAC_USUARIO, FAC_CREA_FE, f.fe_clave, f.fe_consecutivo, f.fe_comprobacion, f.fe_recepcion, fac_tipopago, fac_numero FROM TBL_FACTURA F where f.no_cia = '" + pNo_cia + "' and fac_numero = '" + numFactura + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public Int32 ModificaComentario(String numFactura, String comentario, String pNo_cia)
        {
            String sql = "update TBL_FACTURA F set fac_observacion = '" + comentario + "' where f.no_cia = '" + pNo_cia + "' and fac_numero = '" + numFactura + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Int32 ModificaEstadoFactura(Factura oFactura)
        {
            String sql = "update TBL_FACTURA f set fac_estado = 'FACTURADA', Fac_Subtotal = " + oFactura.SubTotal + ", fac_impuesto =" + oFactura.Impuesto + ", Fac_descuento = " + oFactura.Descuento + ", fac_total = " + oFactura.Total + ", fac_saldo = " + oFactura.Saldo + " where f.no_cia = '" + oFactura.No_cia + "' and fac_linea = " + oFactura.Indice + " and fac_numero = '" + oFactura.NumFactura + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Int32 ModificaEstadoCreaFactura_FE(Factura oFactura)
        {
            String sql = "update TBL_FACTURA f set Fe_Clave = '" + oFactura.Fe_Clave + "', Fe_Consecutivo = '" + oFactura.Fe_Consecutivo + "', Fe_Codigo = '" + oFactura.Fe_Codigo + "', Fe_Comprobacion = '" + oFactura.Fe_Comprobacion + "', FE_RECEPCION = '" + oFactura.Fe_Recepcion + "' where f.no_cia = '" + oFactura.No_cia + "' and fac_linea = " + oFactura.Indice + " and fac_numero = '" + oFactura.NumFactura + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Int32 ModificaEstadoFactura_FE(Factura oFactura)
        {
            String sql = "update TBL_FACTURA f set Fe_Codigo = '" + oFactura.Fe_Codigo + "', Fe_Comprobacion = '" + oFactura.Fe_Comprobacion + "', FE_RECEPCION = 'Recibido' where f.no_cia = '" + oFactura.No_cia + "' and fac_linea = " + oFactura.Indice + " and fac_numero = '" + oFactura.NumFactura + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Int32 Anular(Factura oFactura, String administrador, String pNo_cia)
        {
            String sql = "SELECT FAC_INDICEDOCUMENTO, FAC_TIPODOCUMENTO FROM TBL_FACTURA F WHERE f.no_cia = '" + oFactura.No_cia + "' and fac_linea = '" + oFactura.Indice + "' and fac_numero = '" + oFactura.NumFactura + "'";
            DataTable oTabla = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            if (oTabla.Rows.Count > 0)
            {
                if (oTabla.Rows[0].ItemArray[1].ToString().Equals("COT"))
                {
                    sql = "update TBL_COTIZACION c set COT_ESTADOREGISTRO = 'ABIERTA' WHERE c.no_cia = '" + oFactura.No_cia + "' and COT_NUMERO = '" + oTabla.Rows[0].ItemArray[0].ToString() + "'";
                    OracleDAO.getInstance().EjecutarSQL(sql);
                }
            }

            sql = "update TBL_FACTURA F set fac_estado = 'ANULADA', FAC_USUARIOMODIFICA = user, FAC_FECHAMODIFICA= sysdate,FAC_ADMINISTRADOR_ANULA='" + administrador + "', FAC_FECHA_ANULA=sysdate, fac_comentario='" + oFactura.Comentario + "' where f.no_cia = '" + oFactura.No_cia + "' and fac_linea = " + oFactura.Indice + " and fac_numero = " + oFactura.NumFactura;
            OracleDAO.getInstance().EjecutarSQL(sql);

            sql = "INSERT INTO TBL_FACTURA_AUTORIZACION fa VALUES ('" + oFactura.NumFactura + "', '" + oFactura.Cliente + "', user, '" + administrador + "', '" + oFactura.Comentario + "', 'ANULAR FACTURA', sysdate, '" + oFactura.No_cia + "')";
            return OracleDAO.getInstance().EjecutarSQL(sql);

        }

        public DataTable ConsultaCliente(String codigo, String pNo_cia)
        {
            String sql = "select cli_nombre, cli_telefono, cli_fax, cli_ubicacion, cli_dias, cli_identificacion from TBL_CLIENTES c WHERE c.no_cia = '" + pNo_cia + "' and  cli_estado = 1 and cli_linea = '" + codigo + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable Consulta(int tipo, String palabra, String pNo_cia)
        {
            String sql = "select fac_numero , fac_estado ,  fac_fecha , fac_nombre,FE_CONSECUTIVO, upper(FE_RECEPCION) FE_RECEPCION, decode(FE_COMPROBACION,'por_comprobar','POR COMPROBAR',upper(FE_COMPROBACION)) FE_COMPROBACION from TBL_FACTURA F where f.no_cia = '" + pNo_cia + "' and ";
            if (tipo == 1)
                sql += " regexp_like(fac_numero,'" + palabra + "','i')";
            else
                sql += " regexp_like(fac_nombre,'" + palabra + "','i')";
            sql += " order by TO_NUMBER(fac_numero) desc";
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
            String sql = "select max(fac_numero) fac_numero from TBL_FACTURA F where f.no_cia = '" + pNo_cia + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }
    }
}
