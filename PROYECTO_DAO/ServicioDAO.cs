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
            oCommand.Parameters[1].Value = oServicio.CodigoBarras;
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

        public Boolean Eliminar(Servicio oArticulos_MC)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKSERVICIO.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oArticulos_MC.Tipo;
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = "";
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[2].Value = oArticulos_MC.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oArticulos_MC.No_cia;

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



        public DataSet ConsultarInventario(String almacen, Boolean MostrarPromocion, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT DISTINCT ART_INDICE INV_COD_ARTICULO, ART_CODIGO, ART_DESC_BREVE ART_NOMBRE, '' ART_EMBALAJE, 0 INV_EXISTENCIA, 0 inv_total, '' INV_MON_COMPRA, '' INV_PRECIO_COMPRA, 0 ARPRE_INDICE, 0 INV_COD_PROVEEDOR, '' INV_COD_ALMACEN, 0 INV_IMPUESTO_VENTAS, '' INV_MON_VENTA , '' INV_PRECIO_VENTA, '' INV_INDICE, null Imagen, '' ALM_DESCRIPCION, '' INV_IVI, 'N' Ind_maneja_inv FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  ART_TIPO = 'SER' AND ART_ESTADO = 1 ORDER BY art_desc_breve";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarSinInventario(String almacen, String pNo_cia)
        {
            String sql = "";

            sql = "SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end ARPRE_EMBALAJE,ARPRE_INDICE,ART_INDICE, ART_CODIGO, ART_PROVEEDOR,'' ARTALM_ALMACEN, ART_DESC_BREVE ART_NOMBRE, '' ALM_DESCRIPCION, 0 inv_total, cat_descripcion ";

            //sql = " (SELECT INV_CANTIDAD FROM TBL_INVENTARIO_MC i where i.no_cia = '" + pNo_cia + "' and INV_COD_ARTICULO=ART_INDICE and INV_COD_ALMACEN=ARTALM_ALMACEN and INV_COD_PROVEEDOR=ART_PROVEEDOR and INV_PRESENTACION=ARPRE_INDICE  AND inv_fecha = (SELECT MIN(inv_fecha) FROM TBL_INVENTARIO_MC i WHERE i.no_cia = '" + pNo_cia + "' and INV_COD_ARTICULO = ART_INDICE  AND INV_COD_PROVEEDOR = ART_PROVEEDOR AND ALM_ID=INV_COD_ALMACEN)) inv_total";

            //sql += " FROM tbl_servicios ar, TBL_BODEGA_MC b, TBL_ARTICULO_PRESENTACION_MC ap, TBL_ARTICULO_BODEGA_MC aa WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = b.no_cia and ar.no_cia = ap.no_cia and ar.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and ART_TIPO = 'ART' AND ART_ESTADO = 1 AND ARPRE_ARTICULO = ART_INDICE AND ARTALM_CODIGO =ART_INDICE AND ARTALM_PROVEEDOR=ART_PROVEEDOR AND ALM_ID =ARTALM_ALMACEN   ";

            sql += " FROM tbl_servicios ar, TBL_ARTICULO_PRESENTACION_MC ap,TBL_CATEGORIA_MC c WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = ap.no_cia and ar.no_cia = c.no_cia and ART_TIPO = 'ART' AND ART_ESTADO = 1 AND ARPRE_ARTICULO = ART_INDICE and art_categoria = cat_indice";

            //if (!almacen.Equals(""))
            //    sql += "and ARTALM_ALMACEN=INV_COD_ALMACEN and INV_COD_ALMACEN='" + almacen + "' ";

            //sql += " ORDER BY art_desc_breve, ARTALM_ALMACEN, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

            sql += " ORDER BY art_desc_breve, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
        
        public DataSet ListarInventario(String almacen, string codigo, string descripcion, string tipo, Boolean MostrarPromocion, String pNo_cia, String pCentro)
        {
            String sql = "";
            if (tipo.Equals("ART"))
            {
                sql = "SELECT INV_COD_ARTICULO, ART_CODIGO, ART_DESC_BREVE ART_NOMBRE, decode(ARPRE_EMBALAJE, 'talla', (ARPRE_CANTIDAD || ' ' || ARPRE_EMBALAJE), ARPRE_EMBALAJE) ART_EMBALAJE, (INV_CANTIDAD - INV_CANTIDAD_TRANSITO) AS INV_EXISTENCIA, INV_CANTIDAD inv_total, INV_MON_COMPRA, INV_PRECIO_COMPRA, ARPRE_INDICE, INV_COD_PROVEEDOR, INV_COD_ALMACEN, INV_IMPUESTO_VENTAS, INV_MON_VENTA, decode(INV_MON_VENTA, 'COL', (TO_CHAR(INV_PRECIO_VENTA, '999,999,999.99') || ' ¢'), (TO_CHAR(INV_PRECIO_VENTA, '999,999,999.99') || ' $')) INV_PRECIO_VENTA,  INV_IVI, INV_INDICE, ap.Imagen, ALM_DESCRIPCION, cat_descripcion, Ind_maneja_inv ";

                sql += " FROM TBL_INVENTARIO_MC i2, tbl_servicios ar, TBL_BODEGA_MC b, TBL_ARTICULO_PRESENTACION_MC ap, TBL_CATEGORIA_MC C ";

                sql += " WHERE i2.no_cia = '" + pNo_cia + "' and i2.no_cia = ar.no_cia and i2.no_cia = b.no_cia and i2.no_cia = ap.no_cia and ar.no_cia = c.no_cia and b.centro = '" + pCentro + "' and i2.centro = '" + pCentro + "' and ART_TIPO = 'ART' AND ART_ESTADO = 1 AND i2.INV_COD_ARTICULO = ART_INDICE AND ALM_ID = i2.INV_COD_ALMACEN AND i2.INV_PRESENTACION = ARPRE_INDICE and art_categoria = cat_indice ";

                if (!almacen.Equals(""))
                    sql += " AND i2.INV_COD_ALMACEN = '" + almacen + "' ";
                else if (!MostrarPromocion)
                    sql += " AND i2.INV_COD_ALMACEN <> 'PROM' ";

                if (!codigo.Equals(""))
                    sql += " AND regexp_like(ART_CODIGO,'" + codigo + "','i') ";
                if (!descripcion.Equals(""))
                    sql += " AND regexp_like(ART_DESC_BREVE,'" + descripcion + "','i')";

                sql += " ORDER BY art_desc_breve, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

            }
            else
            {
                sql = "SELECT DISTINCT ART_INDICE INV_COD_ARTICULO, ART_CODIGO ,'' ART_EMBALAJE, ART_DESC_BREVE ART_NOMBRE, ART_PROVEEDOR INV_COD_PROVEEDOR, '' INV_COD_ALMACEN, 0 INV_IMPUESTO_VENTAS, 1 INV_EXISTENCIA, 1 inv_total, '' INV_MON_COMPRA, 0 INV_PRECIO_COMPRA, '' INV_MON_VENTA, 0 INV_PRECIO_VENTA, 0 INV_INDICE, '' ALM_DESCRIPCION, 0 ARPRE_INDICE, null Imagen, '' INV_IVI, Ind_maneja_inv FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  ART_TIPO = 'SER' AND ART_ESTADO = 1 ";

                if (!codigo.Equals(""))
                    sql += " AND regexp_like(ART_INDICE,'" + codigo + "','i')";
                if (!descripcion.Equals(""))
                    sql += " AND regexp_like(ART_DESC_BREVE,'" + descripcion + "','i')";

                sql += " ORDER BY art_desc_breve";
            }
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultaCodigo(String almacen, string codigo, string tipo, Boolean MostrarPromocion, String pNo_cia, String pCentro)
        {
            String sql = "";
            if (tipo.Equals("ART"))
            {
                sql = "SELECT INV_COD_ARTICULO,ART_CODIGO, ART_DESC_BREVE ART_NOMBRE, case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end ART_EMBALAJE, (INV_CANTIDAD-INV_CANTIDAD_TRANSITO) AS INV_EXISTENCIA, (SELECT SUM(i1.INV_CANTIDAD) fROM TBL_INVENTARIO_MC i1 WHERE i2.INV_COD_ARTICULO = i1.INV_COD_ARTICULO AND i2.INV_COD_ALMACEN    =i1.INV_COD_ALMACEN AND i2.INV_PRESENTACION   =i1.INV_PRESENTACION ) inv_total, INV_MON_COMPRA, INV_PRECIO_COMPRA, ARPRE_INDICE, INV_COD_PROVEEDOR, INV_COD_ALMACEN, INV_IMPUESTO_VENTAS, INV_MON_VENTA, CASE WHEN INV_MON_VENTA='COL' THEN  (TO_CHAR(INV_PRECIO_VENTA,'999,999,999.99') ||' ¢')  ELSE  (TO_CHAR(INV_PRECIO_VENTA,'999,999,999.99') ||' $') END INV_PRECIO_VENTA, INV_INDICE, ALM_DESCRIPCION, INV_IVI, Ind_maneja_inv FROM TBL_INVENTARIO_MC i2, tbl_servicios ar, TBL_BODEGA_MC b, TBL_ARTICULO_PRESENTACION_MC ap WHERE i2.no_cia = '" + pNo_cia + "' and i2.no_cia = ar.no_cia and i2.no_cia = b.no_cia and i2.no_cia = ap.no_cia and b.centro = '" + pCentro + "' and i2.centro = '" + pCentro + "' and " +
                    "ART_TIPO = 'ART' AND ART_ESTADO = 1 AND i2.INV_COD_ARTICULO = ART_INDICE AND ALM_ID =i2.INV_COD_ALMACEN AND i2.INV_PRESENTACION =ARPRE_INDICE ";

                //-------------------------------------------------------------------------------------------//
                // parte para traer la ultima factura y que tambien este en cantidad 0
                sql += " AND i2.INV_INDICE = (SELECT distinct case when ((select count(i1.INV_INDICE) FROM TBL_INVENTARIO_MC i1 WHERE i1.INV_COD_ARTICULO = i2.INV_COD_ARTICULO AND i1.INV_COD_ALMACEN = i2.INV_COD_ALMACEN AND i1.INV_PRESENTACION = i2.INV_PRESENTACION)>1) then case when ((select max(i1.inv_cantidad) FROM TBL_INVENTARIO_MC i1 WHERE i1.INV_COD_ARTICULO = i2.INV_COD_ARTICULO AND i1.INV_COD_ALMACEN = i2.INV_COD_ALMACEN AND i1.INV_PRESENTACION = i2.INV_PRESENTACION)=0) then ( select max(i1.INV_INDICE) FROM TBL_INVENTARIO_MC i1 WHERE i1.INV_COD_ARTICULO = i2.INV_COD_ARTICULO AND i1.INV_COD_ALMACEN = i2.INV_COD_ALMACEN AND i1.INV_PRESENTACION = i2.INV_PRESENTACION)  else  (select MIN(i1.INV_INDICE) FROM TBL_INVENTARIO_MC i1 WHERE i1.INV_COD_ARTICULO = i2.INV_COD_ARTICULO AND i1.INV_COD_ALMACEN = i2.INV_COD_ALMACEN AND i1.INV_PRESENTACION = i2.INV_PRESENTACION and i1.inv_cantidad>0) end else ( select MIN(i1.INV_INDICE) FROM TBL_INVENTARIO_MC i1 WHERE i1.INV_COD_ARTICULO = i2.INV_COD_ARTICULO AND i1.INV_COD_ALMACEN = i2.INV_COD_ALMACEN AND i1.INV_PRESENTACION = i2.INV_PRESENTACION) end FROM TBL_INVENTARIO_MC i1 WHERE i1.INV_COD_ARTICULO = i2.INV_COD_ARTICULO AND i1.INV_COD_ALMACEN = i2.INV_COD_ALMACEN AND i1.INV_PRESENTACION = i2.INV_PRESENTACION) ";
                //sql += " AND (i2.INV_CANTIDAD+i2.INV_CANTIDAD_TRANSITO)>0 ";
                //-------------------------------------------------------------------------------------------//
                if (!almacen.Equals(""))
                    sql += " and i2.INV_COD_ALMACEN = '" + almacen + "' ";
                else if (!MostrarPromocion)
                    sql += " AND i2.INV_COD_ALMACEN <> 'PROM' ";

                if (!codigo.Equals(""))
                    sql += " AND ART_CODIGO = '" + codigo + "' ";


                sql += " ORDER BY art_desc_breve,ARPRE_CANTIDAD,ARPRE_EMBALAJE";
            }
            else
            {
                sql = "SELECT DISTINCT ART_INDICE INV_COD_ARTICULO, ART_CODIGO ,'' ART_EMBALAJE, ART_DESC_BREVE ART_NOMBRE, ART_PROVEEDOR INV_COD_PROVEEDOR, '' INV_COD_ALMACEN, 0 INV_IMPUESTO_VENTAS, 1 INV_EXISTENCIA, 1 inv_total, '' INV_MON_COMPRA, 0 INV_PRECIO_COMPRA, '' INV_MON_VENTA, 0 INV_PRECIO_VENTA, 0 INV_INDICE, '' ALM_DESCRIPCION, 0 ARPRE_INDICE, '' INV_IVI, '' cat_descripcion FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  ART_TIPO = 'SER' AND ART_ESTADO = 1 ";

                if (!codigo.Equals(""))
                    sql += " AND ART_CODIGO = '" + codigo + "'";

                sql += " ORDER BY art_desc_breve";
            }
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarSinInventario(String almacen, string codigo, string descripcion, String pNo_cia, String pCentro)
        {
            String sql = "";

            sql = "SELECT case when ARPRE_EMBALAJE='talla' then ARPRE_CANTIDAD||' '||ARPRE_EMBALAJE else ARPRE_EMBALAJE end ARPRE_EMBALAJE,ARPRE_INDICE,ART_INDICE, ART_CODIGO, ART_PROVEEDOR,'' ARTALM_ALMACEN, ART_DESC_BREVE ART_NOMBRE, '' ALM_DESCRIPCION, 0 inv_total , cat_descripcion";

            //sql = " (SELECT INV_CANTIDAD FROM TBL_INVENTARIO_MC i where i.no_cia = '" + pNo_cia + "' and INV_COD_ARTICULO=ART_INDICE and INV_COD_ALMACEN=ARTALM_ALMACEN and INV_COD_PROVEEDOR=ART_PROVEEDOR and INV_PRESENTACION=ARPRE_INDICE  AND inv_fecha = (SELECT MIN(inv_fecha) FROM TBL_INVENTARIO_MC i WHERE i.no_cia = '" + pNo_cia + "' and INV_COD_ARTICULO = ART_INDICE  AND INV_COD_PROVEEDOR = ART_PROVEEDOR AND ALM_ID=INV_COD_ALMACEN)) inv_total";

            //sql += " FROM tbl_servicios ar, TBL_BODEGA_MC b, TBL_ARTICULO_PRESENTACION_MC ap, TBL_ARTICULO_BODEGA_MC aa WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = b.no_cia and ar.no_cia = ap.no_cia and ar.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and ART_TIPO = 'ART' AND ART_ESTADO = 1 AND ARPRE_ARTICULO = ART_INDICE AND ARTALM_CODIGO =ART_INDICE AND ARTALM_PROVEEDOR=ART_PROVEEDOR AND ALM_ID =ARTALM_ALMACEN   ";

            sql += " FROM tbl_servicios ar, TBL_ARTICULO_PRESENTACION_MC ap, TBL_CATEGORIA_MC c WHERE ar.no_cia = '" + pNo_cia + "' and ar.no_cia = ap.no_cia and ar.no_cia = c.no_cia and ART_TIPO = 'ART' AND ART_ESTADO = 1 AND ARPRE_ARTICULO = ART_INDICE and art_categoria = cat_indice";

            //if (!almacen.Equals(""))
            //    sql += "and ARTALM_ALMACEN=INV_COD_ALMACEN and INV_COD_ALMACEN='" + almacen + "' ";

            //sql += " ORDER BY art_desc_breve, ARTALM_ALMACEN, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

            if (!codigo.Equals(""))
                sql += " AND regexp_like(ART_CODIGO,'" + codigo + "')";
            if (!descripcion.Equals(""))
                sql += " AND regexp_like(ART_DESC_BREVE,'" + descripcion + "')";

            sql += " ORDER BY art_desc_breve, ARPRE_CANTIDAD, ARPRE_EMBALAJE";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarXAlmacen(String cod, String pNo_cia)
        {
            String sql = "SELECT ART_INDICE ART_CODIGO, ART_DESC_BREVE,ART_DESC_BREVE ART_NOMBRE, ART_PROVEEDOR, ART_MINIMO, ART_MAXIMO, ART_CATEGORIA, ART_ALMACEN, ART_IMPUESTOS, ART_INVENTARIO, ART_ESTADO FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  art_almacen = '" + cod + "' and art_estado=1 order by art_desc_breve";
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

        public DataSet ConsultarXLinea(String linea, String pNo_cia)
        {
            String sql = "Select ART_INDICE as cod, ART_DESC_BREVE as descripcion FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  art_estado = 1 and ART_FABRICANTE= '" + linea + "' order by art_desc_breve";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarXLinea(int tipo, String palabra, String linea, String pNo_cia)
        {
            String sql = "Select ART_INDICE as cod, ART_DESC_BREVE as descripcion FROM tbl_servicios ar WHERE ar.no_cia = '" + pNo_cia + "' and  art_estado = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(ART_INDICE,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(ART_DESC_BREVE,'" + palabra + "','i')";
            sql += " and ART_FABRICANTE= '" + linea + "' order by art_desc_breve";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
    }
}