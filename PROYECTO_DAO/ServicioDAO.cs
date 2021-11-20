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
            oCommand.Parameters[3].Value = oServicio.Nombre;
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
            oCommand.Parameters.Add("pCod_cabys", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oServicio.Cod_cabys;

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
            String sql = "Select SER_INDICE as cod, SER_DESC_BREVE as descripcion FROM tbl_servicios ar where ar.no_cia = '" + pNo_cia + "' and SER_ESTADO = 1 ORDER BY SER_DESC_BREVE,SER_TIPO, SER_INDICE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarTodo(String pNo_cia)
        {
            String sql = "SELECT SER_INDICE, SER_TIPO, SER_CODIGO, SER_DESC_BREVE, SER_IMPUESTOS, SER_VENTA_IVI, SER_ESTADO, SER_TIPO_CODIGO, Cod_cabys FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and SER_ESTADO = 1 AND SER_TIPO = 'SER' ORDER BY SER_DESC_BREVE,SER_TIPO, SER_INDICE";


            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataTable ConsultarEspecificoIndice(String codIndice, String pNo_cia)
        {
            String sql = "SELECT SER_INDICE, SER_TIPO, SER_INDICE, SER_DESC_BREVE, SER_IMPUESTOS, SER_ESTADO, SER_TIPO_CODIGO, SER_CODIGO, SER_VENTA_IVI, Cod_cabys FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and SER_ESTADO = 1 AND SER_INDICE = '" + codIndice + "' order by SER_DESC_BREVE";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataSet Busqueda_Consulta(String pNo_cia)
        {
            String sql = "Select SER_INDICE as cod, SER_DESC_BREVE as descripcion, SER_INDICE dato1, 0 dato2, '' dato3 FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and SER_TIPO = 'ART' AND SER_ESTADO = 1 ORDER BY SER_DESC_BREVE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            string sql = "SELECT SER_INDICE, SER_TIPO, SER_CODIGO, SER_DESC_BREVE, SER_IMPUESTOS, SER_VENTA_IVI, SER_ESTADO, SER_TIPO_CODIGO, Cod_cabys FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and SER_ESTADO = 1 AND SER_TIPO = 'SER' ";


            if (palabra.Length > 0)
            {
                if (tipo == 1)
                    sql += "AND regexp_like(SER_CODIGO,'" + palabra + "','i') ";
                if (tipo == 2)
                    sql += "AND regexp_like(SER_DESC_BREVE,'" + palabra + "','i') ";
            }
            sql += "ORDER BY SER_DESC_BREVE, SER_TIPO, SER_INDICE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }



        public DataSet ConsultarInventario(String pOrigen, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT SER_INDICE, SER_CODIGO, SER_DESC_BREVE SER_NOMBRE, SER_venta_ivi INV_IVI, SER_impuestos INV_IMPUESTO_VENTAS, Cod_cabys FROM tbl_servicios ar, tbl_empresa e WHERE ar.no_cia = '" + pNo_cia + "' and  SER_TIPO = 'SER' AND SER_ESTADO = 1 and ('" + pOrigen + "' = 'C' or ('" + pOrigen + "' = 'F' and (e.IND_FACT_ELECT = 'N' or (e.IND_FACT_ELECT = 'S' and SER_TIPO_CODIGO = 'EX')))) ORDER BY SER_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarInventario(String pOrigen, string codigo, string descripcion, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT SER_INDICE, SER_CODIGO, SER_DESC_BREVE SER_NOMBRE, SER_venta_ivi INV_IVI, SER_impuestos INV_IMPUESTO_VENTAS, Cod_cabys FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  SER_TIPO = 'SER' AND SER_ESTADO = 1 ";

            if (!codigo.Equals(""))
                sql += " AND regexp_like(SER_INDICE,'" + codigo + "','i')";
            if (!descripcion.Equals(""))
                sql += " AND regexp_like(SER_DESC_BREVE,'" + descripcion + "','i')";
            sql += " and ('" + pOrigen + "' = 'C' or ('" + pOrigen + "' = 'F' and (e.IND_FACT_ELECT = 'N' or (e.IND_FACT_ELECT = 'S' and SER_TIPO_CODIGO = 'EX'))))";
            sql += " ORDER BY SER_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultaCodigo(string codigo, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT DISTINCT SER_INDICE, SER_CODIGO, SER_DESC_BREVE SER_NOMBRE, SER_venta_ivi INV_IVI, SER_impuestos INV_IMPUESTO_VENTAS, Cod_cabys FROM tbl_servicios ar, tbl_empresa e WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = e.no_cia and SER_TIPO = 'SER' AND SER_ESTADO = 1 and (e.IND_FACT_ELECT = 'N' or (e.IND_FACT_ELECT = 'S' and SER_TIPO_CODIGO = 'EX'))  ";

            if (!codigo.Equals(""))
                sql += " AND SER_CODIGO = '" + codigo + "'";

            sql += " ORDER BY SER_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarSinInventario(string codigo, string descripcion, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end ARPRE_EMBALAJE,ARPRE_INDICE,SER_INDICE, SER_CODIGO, SER_PROVEEDOR,'' ARTALM_ALMACEN, SER_DESC_BREVE SER_NOMBRE, '' ALM_DESCRIPCION, 0 inv_total , cat_descripcion, Cod_cabys";

            sql += " FROM tbl_servicios ar, TBL_ARTICULO_PRESENTACION ap, TBL_CATEGORIA c WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = ap.no_cia and ar.no_cia = c.no_cia and SER_TIPO = 'ART' AND SER_ESTADO = 1 AND ARPRE_ARTICULO = SER_INDICE and SER_categoria = cat_indice";

            if (!codigo.Equals(""))
                sql += " AND regexp_like(SER_CODIGO,'" + codigo + "')";
            if (!descripcion.Equals(""))
                sql += " AND regexp_like(SER_DESC_BREVE,'" + descripcion + "')";

            sql += " ORDER BY SER_desc_breve, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

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