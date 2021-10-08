using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;

using System.Data;
using System.Collections;

namespace PROYECTO_DAO
{
    public class ProformaDAO
    {
        public DataTable Agregar(Proforma oProforma)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMA.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("PROFORMA", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oProforma.NumProforma;
            oCommand.Parameters.Add("fechafac", OracleType.DateTime);
            oCommand.Parameters[1].Value = oProforma.FechaProforma;
            oCommand.Parameters.Add("cliente", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oProforma.Cliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProforma.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProforma.Telefono;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oProforma.Ubicacion;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oProforma.Moneda;
            oCommand.Parameters.Add("tipocambio", OracleType.Number);
            oCommand.Parameters[7].Value = oProforma.Tipocambio;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[8].Value = 0;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[9].Value = oProforma.SubTotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[10].Value = oProforma.Impuesto;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[11].Value = oProforma.Descuento;
            oCommand.Parameters.Add("total", OracleType.Number);
            oCommand.Parameters[12].Value = oProforma.Total;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[13].Value = oProforma.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[14].Value = oProforma.Estado;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oProforma.Observacion;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[16].Value = oProforma.Usuario;
            oCommand.Parameters.Add("TIPO", OracleType.NVarChar);
            oCommand.Parameters[17].Value = oProforma.Tipo;
            oCommand.Parameters.Add("VENDEDOR", OracleType.NVarChar);
            oCommand.Parameters[18].Value = oProforma.Vendedor;
            oCommand.Parameters.Add("INDICEDOCUMENTO", OracleType.Number);
            oCommand.Parameters[19].Value = oProforma.IndiceDocumento;
            oCommand.Parameters.Add("tIPODOCUMENTO", OracleType.NVarChar);
            oCommand.Parameters[20].Value = oProforma.TipoDocumento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[21].Value = oProforma.No_cia;

            oCommand.Parameters.Add(Util.CrearCursor());

            DataTable odata = OracleDAO.getInstance().EjecutarSQLDataTable(oCommand);

            return odata;
        }

        public Boolean Modificar(Proforma oProforma)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMA.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProforma.Indice;
            oCommand.Parameters.Add("PROFORMA", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oProforma.NumProforma;
            oCommand.Parameters.Add("fechafac", OracleType.DateTime);
            oCommand.Parameters[2].Value = oProforma.FechaProforma;
            oCommand.Parameters.Add("cliente", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProforma.Cliente;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProforma.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oProforma.Telefono;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oProforma.Ubicacion;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oProforma.Moneda;
            oCommand.Parameters.Add("tipocambio", OracleType.Number);
            oCommand.Parameters[8].Value = oProforma.Tipocambio;
            oCommand.Parameters.Add("exento", OracleType.Number);
            oCommand.Parameters[9].Value = 0;
            oCommand.Parameters.Add("subtotal", OracleType.Number);
            oCommand.Parameters[10].Value = oProforma.SubTotal;
            oCommand.Parameters.Add("impuesto", OracleType.Number);
            oCommand.Parameters[11].Value = oProforma.Impuesto;
            oCommand.Parameters.Add("descuento", OracleType.Number);
            oCommand.Parameters[12].Value = oProforma.Descuento;
            oCommand.Parameters.Add("total", OracleType.Number);
            oCommand.Parameters[13].Value = oProforma.Total;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[14].Value = oProforma.Saldo;
            oCommand.Parameters.Add("estado", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oProforma.Estado;
            oCommand.Parameters.Add("observacion", OracleType.NVarChar);
            oCommand.Parameters[16].Value = oProforma.Observacion;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[17].Value = oProforma.Usuario;
            oCommand.Parameters.Add("TIPO", OracleType.NVarChar);
            oCommand.Parameters[18].Value = oProforma.Tipo;
            oCommand.Parameters.Add("VENDEDOR", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oProforma.Vendedor;
            oCommand.Parameters.Add("pordescuento", OracleType.Number);
            oCommand.Parameters[20].Value = oProforma.PorDescuento;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[21].Value = oProforma.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Proforma oProforma)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROFORMA.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProforma.Indice;
            oCommand.Parameters.Add("PROFORMA", OracleType.Number);
            oCommand.Parameters[1].Value = oProforma.NumProforma;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProforma.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProforma.No_cia;


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
            String sql = "select count(1) from TBL_PROFORMA p WHERE f.no_cia = '" + pNo_cia + "' order by 1";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultaProformas(String pNo_cia)
        {
            String sql = "select fac_numero||'  -  ' ||fac_estado as cod, fac_nombre as descripcion from TBL_PROFORMA P where p.no_cia = '" + pNo_cia + "' order by to_number(fac_numero) desc";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }
        
        public DataTable ConsultaProforma(String numProforma, String pNo_cia)
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

        public Int32 ModificaEstadoProforma(Proforma oProforma)
        {
            String sql = "update TBL_PROFORMA P set fac_estado = 'FACTURADA', Fac_Subtotal = " + oProforma.SubTotal + ", fac_impuesto =" + oProforma.Impuesto + ", Fac_descuento = " + oProforma.Descuento + ", fac_total = " + oProforma.Total + ", fac_saldo = " + oProforma.Total + " where p.no_cia = '" + oProforma.No_cia + "' and fac_linea = " + oProforma.Indice + " and fac_numero = '" + oProforma.NumProforma + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Int32 Anular(Proforma oProforma, String administrador)
        {
            String sql = "SELECT FAC_INDICEDOCUMENTO, FAC_TIPODOCUMENTO FROM TBL_PROFORMA p WHERE p.no_cia = '" + oProforma.No_cia + "' and fac_linea = '" + oProforma.Indice + "' and fac_numero = '" + oProforma.NumProforma + "'";
            DataTable oTabla = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            if (oTabla.Rows.Count > 0)
            {
                if (oTabla.Rows[0].ItemArray[1].ToString().Equals("COT"))
                {
                    sql = "update TBL_COTIZACION c set COT_ESTADOREGISTRO = 'ABIERTA' WHERE c.no_cia = '" + oProforma.No_cia + "' and COT_NUMERO = '" + oTabla.Rows[0].ItemArray[0].ToString() + "'";
                    OracleDAO.getInstance().EjecutarSQL(sql);
                }
            }

            sql = "update TBL_PROFORMA p set fac_estado = 'ANULADA', FAC_USUARIOMODIFICA='" + oProforma.Usuario + "', FAC_FECHAMODIFICA= sysdate,FAC_ADMINISTRADOR_ANULA='" + administrador + "', FAC_FECHA_ANULA=sysdate, fac_comentario='" + oProforma.Comentario + "' where p.no_cia = '" + oProforma.No_cia + "' and fac_linea = " + oProforma.Indice + " and fac_numero = " + oProforma.NumProforma;
            OracleDAO.getInstance().EjecutarSQL(sql);

            sql = "INSERT INTO tbl_Proforma_AUTORIZACION VALUES ('" + oProforma.NumProforma + "', '" + oProforma.Cliente + "', '" + oProforma.Usuario + "', '" + administrador + "', '" + oProforma.Comentario + "', 'ANULAR FACTURA', sysdate)";
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
