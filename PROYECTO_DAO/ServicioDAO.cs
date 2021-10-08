using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data;
using System.Data.OracleClient;


namespace PROYECTO_DAO
{
    public class ServicioDAO
    {
        public string Agregar(Servicio oServicio)
        {
            OracleCommand oCommand = new OracleCommand();
            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "linea";
            oParametro.Value = 0;

            oCommand.CommandText = "PCKSERVICIO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oServicio.Tipo;
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oServicio.Codigo;
            oCommand.Parameters.Add("desbreve", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oServicio.Descripcion;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oServicio.Descripcion;
            oCommand.Parameters.Add("impuestos", OracleType.Number);
            oCommand.Parameters[4].Value = oServicio.Impuestos;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[5].Value = oServicio.Indice;

            oCommand.Parameters.Add("tipo_codigo", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oServicio.TipoCodigo;
            oCommand.Parameters.Add("venta_IVI", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oServicio.Venta_IVI;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oServicio.No_cia;

            oCommand.Parameters.Add(oParametro);

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return oParametro.Value.ToString();
        }

        public Boolean Eliminar(Servicio oArticulos)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKSERVICIO.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oArticulos.Tipo;
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = "";
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[2].Value = oArticulos.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oArticulos.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String pNo_cia)
        {
            String sql = "Select ART_INDICE as cod, ART_DESC_BREVE as descripcion FROM tbl_servicios ar where ar.no_cia = '" + pNo_cia + "' and ART_ESTADO = 1 ORDER BY ART_DESC_BREVE,ART_TIPO, ART_INDICE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarTodo(String pNo_cia)
        {
            String sql = "SELECT ART_INDICE, ART_TIPO, ART_CODIGO, ART_DESC_BREVE, ART_IMPUESTOS, ART_VENTA_IVI, ART_ESTADO, ART_TIPO_CODIGO FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and ART_ESTADO = 1 AND ART_TIPO = 'SER' ORDER BY ART_DESC_BREVE,ART_TIPO, ART_INDICE";


            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataTable ConsultarEspecificoIndice2(String codIndice, String pNo_cia)
        {
            String sql = "SELECT ART_INDICE, ART_TIPO, ART_INDICE, ART_DESC_BREVE, ART_IMPUESTOS, ART_ESTADO, ART_TIPO_CODIGO, ART_CODIGO, ART_VENTA_IVI FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and ART_ESTADO = 1 AND ART_INDICE = '" + codIndice + "' order by ART_DESC_BREVE";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataSet Busqueda_Consulta(String pNo_cia)
        {
            String sql = "Select ART_INDICE as cod, ART_DESC_BREVE as descripcion, ART_INDICE dato1, 0 dato2, '' dato3 FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and ART_TIPO = 'ART' AND ART_ESTADO = 1 ORDER BY ART_DESC_BREVE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            string sql = "SELECT ART_INDICE, ART_TIPO, ART_CODIGO, ART_DESC_BREVE, ART_IMPUESTOS, ART_VENTA_IVI, ART_ESTADO, ART_TIPO_CODIGO FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and ART_ESTADO = 1 AND ART_TIPO = 'SER' ";


            if (palabra.Length > 0)
            {
                if (tipo == 1)
                    sql += "AND regexp_like(ART_CODIGO,'" + palabra + "','i') ";
                if (tipo == 2)
                    sql += "AND regexp_like(ART_DESC_BREVE,'" + palabra + "','i') ";
            }
            sql += "ORDER BY ART_DESC_BREVE, ART_TIPO, ART_INDICE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }



        public DataSet ConsultarInventario(String pNo_cia)
        {
            String sql = "";

            sql = "SELECT DISTINCT ART_INDICE INV_COD_ARTICULO, ART_CODIGO, ART_DESC_BREVE ART_NOMBRE, art_venta_ivi INV_IVI, art_impuestos INV_IMPUESTO_VENTAS FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  ART_TIPO = 'SER' AND ART_ESTADO = 1 ORDER BY art_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarInventario(string codigo, string descripcion, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT DISTINCT ART_INDICE INV_COD_ARTICULO, ART_CODIGO, ART_DESC_BREVE ART_NOMBRE, art_venta_ivi INV_IVI, art_impuestos INV_IMPUESTO_VENTAS FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  ART_TIPO = 'SER' AND ART_ESTADO = 1 ";

            if (!codigo.Equals(""))
                sql += " AND regexp_like(ART_INDICE,'" + codigo + "','i')";
            if (!descripcion.Equals(""))
                sql += " AND regexp_like(ART_DESC_BREVE,'" + descripcion + "','i')";

            sql += " ORDER BY art_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultaCodigo(string codigo, Boolean MostrarPromocion, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT DISTINCT ART_INDICE INV_COD_ARTICULO, ART_CODIGO, ART_DESC_BREVE ART_NOMBRE, art_venta_ivi INV_IVI, art_impuestos INV_IMPUESTO_VENTAS FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  ART_TIPO = 'SER' AND ART_ESTADO = 1 ";

            if (!codigo.Equals(""))
                sql += " AND ART_CODIGO = '" + codigo + "'";

            sql += " ORDER BY art_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarSinInventario(string codigo, string descripcion, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end ARPRE_EMBALAJE,ARPRE_INDICE,ART_INDICE, ART_CODIGO, ART_PROVEEDOR,'' ARTALM_ALMACEN, ART_DESC_BREVE ART_NOMBRE, '' ALM_DESCRIPCION, 0 inv_total , cat_descripcion";

            sql += " FROM tbl_servicios ar, TBL_ARTICULO_PRESENTACION ap, TBL_CATEGORIA c WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = ap.no_cia and ar.no_cia = c.no_cia and ART_TIPO = 'ART' AND ART_ESTADO = 1 AND ARPRE_ARTICULO = ART_INDICE and art_categoria = cat_indice";

            if (!codigo.Equals(""))
                sql += " AND regexp_like(ART_CODIGO,'" + codigo + "')";
            if (!descripcion.Equals(""))
                sql += " AND regexp_like(ART_DESC_BREVE,'" + descripcion + "')";

            sql += " ORDER BY art_desc_breve, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

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