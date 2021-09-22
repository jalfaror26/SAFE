using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data;
using System.Data.OracleClient;


namespace PROYECTO_DAO
{
    public class Servicio_BodegaDAO
    {
        public Boolean Agregar(Servicio_Bodega oServicio_Bodega)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKARTICULOBODEGA_MC.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oServicio_Bodega.Tipo;
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oServicio_Bodega.Articulo;
            oCommand.Parameters.Add("proveedor", OracleType.Number);
            oCommand.Parameters[2].Value = oServicio_Bodega.Proveedor;
            oCommand.Parameters.Add("almacen", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oServicio_Bodega.Bodega;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oServicio_Bodega.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Servicio_Bodega oServicio_Bodega)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKARTICULOBODEGA_MC.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oServicio_Bodega.Tipo;
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oServicio_Bodega.Articulo;
            oCommand.Parameters.Add("proveedor", OracleType.Number);
            oCommand.Parameters[2].Value = oServicio_Bodega.Proveedor;
            oCommand.Parameters.Add("almacen", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oServicio_Bodega.Bodega;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oServicio_Bodega.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String pNo_cia)
        {
            String sql = "Select ARTALM_CODIGO as cod, ARTALM_DESC_BREVE as descripcion FROM TBL_ARTICULO_BODEGA aa where aa.no_cia = '" + pNo_cia + "' and ARTALM_ESTADO = 1 ORDER BY ARTALM_TIPO, ARTALM_CODIGO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarTodo(String tipoFiltro, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ARTALM_INDICE, ARTALM_TIPO, ARTALM_CODIGO, ARTALM_PROVEEDOR, ARTALM_DESC_BREVE, ARTALM_MINIMO, ARTALM_MAXIMO, ARTALM_CATEGORIA, ARTALM_ALMACEN, ";
            sql += "('Fil: '||TO_CHAR(UBI_FILA,'00000')||' - Est: '||TO_CHAR(UBI_ESTANTE,'00000')||' - Niv: '||TO_CHAR(UBI_NIVEL,'00000')) AS UBICACION, ARTALM_IMPUESTOS, ";
            sql += "ARTALM_INVENTARIO, ARTALM_ESTADO, ARTALM_FABRICANTE, ARTALM_FOTO, ARTALM_UBICACION, ARTALM_ORIGINAL, ARTALM_CONDICION, PROV_NOMBRE, FAB_NOMBRE, ALM_DESCRIPCION  ";
            sql += "FROM TBL_ARTICULO_BODEGA aa, TBL_PROVEEDOR_MC p, TBL_FABRICANTE_MC f, TBL_BODEGA_MC b, TBL_UBICACION u ";
            sql += "WHERE aa.no_cia = '" + pNo_cia + "' and aa.no_cia = p.no_cia and aa.no_cia = f.no_cia and aa.no_cia = b.no_cia and aa.no_cia = u.no_cia and b.centro = '" + pCentro + "' and ARTALM_ESTADO = 1 AND ARTALM_PROVEEDOR  = PROV_LINEA AND ARTALM_FABRICANTE = FAB_INDICE ";
            sql += "AND ARTALM_ALMACEN = ALM_ID AND UBI_INDICE = ARTALM_UBICACION ";
            if (tipoFiltro.Length > 0)
            {
                if (tipoFiltro == "ART")
                    sql += "AND ARTALM_TIPO = 'ART' ";
                if (tipoFiltro == "SER")
                    sql += "AND ARTALM_TIPO = 'SER' ";
            }
            sql += "ORDER BY ARTALM_TIPO, ARTALM_CODIGO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataTable ConsultarEspecificoIndice(String codIndice, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ARTALM_INDICE, ARTALM_TIPO, ARTALM_CODIGO, ARTALM_PROVEEDOR, ARTALM_DESC_BREVE, ARTALM_MINIMO, ARTALM_MAXIMO, ARTALM_CATEGORIA, ARTALM_ALMACEN, ";
            sql += "('Fil: '||TO_CHAR(UBI_FILA,'00000')||' - Est: '||TO_CHAR(UBI_ESTANTE,'00000')||' - Niv: '||TO_CHAR(UBI_NIVEL,'00000')) AS UBICACION, ARTALM_IMPUESTOS, ";
            sql += "ARTALM_INVENTARIO, ARTALM_ESTADO, ARTALM_FABRICANTE, ARTALM_FOTO, ARTALM_UBICACION, ARTALM_ORIGINAL, ARTALM_CONDICION, PROV_NOMBRE, FAB_NOMBRE, ALM_DESCRIPCION  ";
            sql += "FROM TBL_ARTICULO_BODEGA aa, TBL_PROVEEDOR_MC p, TBL_FABRICANTE_MC f, TBL_BODEGA_MC b, TBL_UBICACION u ";
            sql += "WHERE aa.no_cia = '" + pNo_cia + "' and aa.no_cia = p.no_cia and aa.no_cia = f.no_cia and aa.no_cia = b.no_cia and aa.no_cia = u.no_cia and b.centro = '" + pCentro + "' and ARTALM_ESTADO = 1 AND ARTALM_PROVEEDOR  = PROV_LINEA AND ARTALM_FABRICANTE = FAB_INDICE ";
            sql += "AND ARTALM_ALMACEN = ALM_ID AND UBI_INDICE = ARTALM_UBICACION ";
            sql += "AND ARTALM_INDICE = '" + codIndice + "' ";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataTable ConsultarEspecificoCodigo(String codigo, string tipo, int proveedor, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ARTALM_ALMACEN, ALM_DESCRIPCIOn FROM TBL_ARTICULO_BODEGA aa, TBL_BODEGA_MC b WHERE aa.no_cia = '" + pNo_cia + "' and aa.no_cia = b.no_cia and b.centro = '" + pCentro + "' and ARTALM_PROVEEDOR  = '" + proveedor + "' AND ARTALM_ALMACEN = ALM_ID AND ARTALM_CODIGO='" + codigo + "' AND ARTALM_TIPO='" + tipo + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
        }

        public DataSet Busqueda_Consulta( String pNo_cia)
        {
            String sql = "Select ARTALM_CODIGO as cod, ARTALM_DESC_BREVE as descripcion, ARTALM_INDICE dato1, ARTALM_PROVEEDOR dato2, PROV_NOMBRE dato3 FROM TBL_ARTICULO_BODEGA aa, TBL_PROVEEDOR_MC p WHERE aa.no_cia = '" + pNo_cia + "' and aa.no_cia = p.no_cia and ARTALM_TIPO = 'ART' AND ARTALM_ESTADO = 1 AND ARTALM_PROVEEDOR = PROV_LINEA ORDER BY ARTALM_CODIGO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
        
        public DataSet Listar(String tipoFiltro, int tipo, String palabra, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ARTALM_INDICE, ARTALM_TIPO, ARTALM_CODIGO, ARTALM_PROVEEDOR, ARTALM_DESC_BREVE, ARTALM_MINIMO, ARTALM_MAXIMO, ARTALM_CATEGORIA, ARTALM_ALMACEN, ARTALM_IMPUESTOS, ARTALM_INVENTARIO, ARTALM_ESTADO, ARTALM_FABRICANTE, ARTALM_FOTO, ARTALM_UBICACION, ARTALM_MC, ARTALM_MV, ARTALM_ORIGINAL, ARTALM_CONDICION, PROV_NOMBRE, FAB_NOMBRE, ALM_DESCRIPCION ";
            sql += "FROM TBL_ARTICULO_BODEGA aa, TBL_PROVEEDOR_MC p, TBL_FABRICANTE_MC f, TBL_BODEGA_MC b WHERE aa.no_cia = '" + pNo_cia + "' and aa.no_cia = p.no_Cia and aa.no_cia = f.no_cia and aa.no_cia = b.no_Cia and b.centro = '" + pCentro + "' and ARTALM_ESTADO = 1 AND ARTALM_PROVEEDOR  = PROV_LINEA AND ARTALM_FABRICANTE = FAB_INDICE AND ARTALM_ALMACEN = ALM_ID ";
            if (tipoFiltro.Length > 0)
            {
                if (tipoFiltro == "ART")
                    sql += "AND ARTALM_TIPO = 'ART' ";
                if (tipoFiltro == "SER")
                    sql += "AND ARTALM_TIPO = 'SER' ";
            }
            if (palabra.Length > 0)
            {
                if (tipo == 1)
                    sql += "AND regexp_like(ARTALM_CODIGO,'" + palabra + "','i') ";
                if (tipo == 2)
                    sql += "AND regexp_like(ARTALM_DESC_BREVE,'" + palabra + "','i') ";
                //if (tipo == 3)
                //    sql += "AND regexp_like(ARTALM_NOMBRE,'" + palabra + "','i') ";
                if (tipo == 4)
                    sql += "AND regexp_like(PROV_NOMBRE,'" + palabra + "','i') ";
            }
            sql += "ORDER BY ARTALM_TIPO, ARTALM_CODIGO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar_Filtrado(int tipo, String palabra, String pNo_cia)
        {
            String sql = "Select ARTALM_CODIGO as cod, ARTALM_DESC_BREVE as descripcion, ARTALM_INDICE dato1, ARTALM_PROVEEDOR dato2, PROV_NOMBRE dato3 FROM TBL_ARTICULO_BODEGA aa, TBL_PROVEEDOR_MC p WHERE aa.no_cia = '" + pNo_cia + "' and aa.no_cia = p.no_Cia and ARTALM_TIPO = 'ART' AND ARTALM_ESTADO = 1 AND ARTALM_PROVEEDOR = PROV_LINEA ";
            if (tipo == 1)
                sql += "AND regexp_like(ARTALM_CODIGO,'" + palabra + "','i')";
            if (tipo == 2)
                sql += "AND regexp_like(ARTALM_DESC_BREVE,'" + palabra + "','i')";
            sql += "ORDER BY ARTALM_CODIGO, ARTALM_DESC_BREVE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarInv(int tipo, String pNo_cia, String pCentro)
        {
            String sql = "select INV_COD_ARTICULO as codigo, ARTALM_desc_breve as descripcion, sum(inv_cantidad) as existencia, INV_COD_ALMACEN as codAlmacen, alm_descripcion as descAlmacen, ARTALM_NOMBRE as descLarga from TBL_INVENTARIO_LOTES i, TBL_BODEGA_MC b, TBL_ARTICULO_BODEGA aa where i.no_cia = '" + pNo_cia + "' and i.no_cia = b.no_cia and i.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and INV_COD_ARTICULO = ARTALM_codigo and alm_id = INV_COD_ALMACEN and ARTALM_estado = 1 ";
            if (tipo == 0)
                sql += " and INV_COD_ALMACEN not like 'C-%'";
            else if (tipo == 1)
                sql += " and INV_COD_ALMACEN like 'C-%'";
            else
                sql += " ";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarInv(int tipo, String palabra, String pNo_cia, String pCentro)
        {
            String sql = "select INV_COD_ARTICULO as codigo, ARTALM_desc_breve as descripcion, sum(inv_cantidad) as existencia, INV_COD_ALMACEN as codAlmacen, alm_descripcion as descAlmacen, ARTALM_NOMBRE as descLarga from TBL_INVENTARIO_LOTES i, TBL_BODEGA_MC b, TBL_ARTICULO_BODEGA aa where i.no_cia = '" + pNo_cia + "' and i.no_cia = b.no_cia and i.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and INV_COD_ARTICULO = ARTALM_codigo and alm_id = INV_COD_ALMACEN and ARTALM_estado = 1 ";
            if (tipo == 0)
                sql += " and INV_COD_ALMACEN not like 'C-%' and ARTALM_CATEGORIA = '" + palabra + "'";
            else if (tipo == 1)
                sql += " and INV_COD_ALMACEN like 'C-%' and ARTALM_CATEGORIA = '" + palabra + "'";
            else
                sql += " and ARTALM_CATEGORIA = '" + palabra + "'";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarInv(int tipo, int filtro, String palabra, String tipoArticulo, String pNo_cia, String pCentro)
        {
            String sql = "select INV_COD_ARTICULO as codigo, ARTALM_desc_breve as descripcion, sum(inv_cantidad) as existencia, INV_COD_ALMACEN as codAlmacen, alm_descripcion as descAlmacen, ARTALM_NOMBRE as descLarga from tbl_inventario_lotes i, TBL_BODEGA_MC b, TBL_ARTICULO_BODEGA aa where i.no_cia = '" + pNo_cia + "' and i.no_cia = b.no_cia and i.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and INV_COD_ARTICULO = ARTALM_codigo and alm_id = INV_COD_ALMACEN and ARTALM_estado = 1 ";
            if (tipo == 0)
                sql += " and INV_COD_ALMACEN not like 'C-%' and ARTALM_CATEGORIA = '" + tipoArticulo + "' ";
            else if (tipo == 1)
                sql += " and INV_COD_ALMACEN not like 'C-%' and ARTALM_CATEGORIA = '" + tipoArticulo + "' ";
            else
                sql += " and ARTALM_CATEGORIA = '" + tipoArticulo + "' ";
            if (filtro == 1)
                sql += " and regexp_like(INV_COD_ARTICULO,'" + palabra + "','i')";
            if (filtro == 2)
                sql += " and regexp_like(ARTALM_desc_breve,'" + palabra + "','i')";
            if (filtro == 4)
                sql += " and regexp_like(alm_descripcion,'" + palabra + "','i')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarInventario(String pNo_cia, String pCentro)
        {
            String sql = "select distinct INV_COD_ARTICULO as codigo, ARTALM_desc_breve as descripcion, inv_cantidad as existencia, INV_COD_ALMACEN as codAlmacen, alm_descripcion as descAlmacen, ARTALM_NOMBRE as descLarga,INV_LOTE  from tbl_inventario_lotes i, TBL_BODEGA_MC b, TBL_ARTICULO_BODEGA aa where i.no_cia = '" + pNo_cia + "' and i.no_cia = b.no_cia and i.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and INV_COD_ARTICULO = ARTALM_codigo and alm_id = INV_COD_ALMACEN and ARTALM_estado = 1 and INV_COD_ALMACEN not like 'C-%'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarInventarioBodega(String bodega, String pNo_cia, String pCentro)
        {
            String sql = "SELECT DISTINCT INV_COD_ARTICULO, INV_COD_PROVEEDOR, INV_COD_ALMACEN, INV_IMPUESTO_VENTAS, ARTALM_NOMBRE, ";
            sql += "INV_CLASE, (INV_CANTIDAD-INV_CANTIDAD_TRANSITO) AS INV_EXISTENCIA, ARTALM_ORIGINAL, ";
            sql += "INV_MON_VENTA, INV_PRECIO_VENTA, MAR_NOMBRE, MOD_DESCRIPCION, MOD_AÑOINICIO ||' - ' ||MOD_AÑOFIN AÑOS ";
            sql += "FROM TBL_INVENTARIO_MC i, TBL_ARTICULO_BODEGA aa, TBL_MARCA_MC m, TBL_ARTICULO_MARCA_MC am, TBL_MODELO mo ";
            sql += "WHERE i.no_cia = '" + pNo_cia + "' and i.no_cia = aa.no_cia and i.no_cia = m.no_cia and i.no_cia = am.no_cia and i.no_cia = mo.no_cia and INV_COD_ALMACEN = '" + bodega + "' AND ARTALM_TIPO = 'ART' AND ARTALM_ESTADO = 1  ";
            sql += "AND INV_COD_ARTICULO = ARTALM_CODIGO AND INV_COD_PROVEEDOR = ARTALM_PROVEEDOR ";
            sql += "AND ARTMAR_ARTICULO = INV_COD_ARTICULO AND ARTMAR_MARCA = MAR_INDICE ";
            sql += "AND MOD_MARCA = MAR_INDICE ";
            sql += "ORDER BY INV_COD_ARTICULO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarInventario(String almacen, string codigo, string descripcion, string marca, string modelo, string G, String pNo_cia, String pCentro)
        {
            String sql = "SELECT DISTINCT INV_COD_ARTICULO AS codigo, ARTALM_desc_breve AS descripcion, inv_cantidad-inv_cantidad_transito AS existencia, INV_COD_ALMACEN AS codAlmacen, alm_descripcion AS descAlmacen, ARTALM_NOMBRE aS descLarga, CASE WHEN INV_MON_VENTA ='COL' THEN '¢ ' || INV_PRECIO_VENTA  WHEN INV_MON_VENTA ='USD' THEN '$ ' || INV_PRECIO_VENTA ELSE '€ ' || INV_PRECIO_VENTA END ARTALM_PRECIOVENTA, MAR_NOMBRE, MOD_DESCRIPCION, MOD_AÑOINICIO ||' - ' ||MOD_AÑOFIN AÑOS, ARTALM_ORIGINAL , ARTALM_PROVEEDOR, INV_CLASE FROM TBL_INVENTARIO_MC i, TBL_BODEGA_MC b, TBL_ARTICULO_BODEGA aa, TBL_MARCA_MC m, TBL_MODELO mo WHERE i.no_cia = '" + pNo_cia + "' and i.no_cia = b.no_cia and i.no_cia = aa.no_cia and i.no_cia = m.no_cia and i.no_cia = mo.no_cia and b.centro = '" + pCentro + "' and AMM_ARTICULO =INV_COD_ARTICULO AND MOD_MARCA =MAR_INDICE AND MOD_DESCRIPCION =MOD_INDICE AND INV_COD_ARTICULO = ARTALM_CODIGO AND INV_COD_PROVEEDOR = ARTALM_PROVEEDOR AND ARTALM_TIPO = 'ART' AND INV_COD_ALMACEN = ALM_ID AND ARTALM_estado = 1 AND INV_COD_ALMACEN = '" + almacen + "' ";

            if (!codigo.Equals(""))
                sql += " and regexp_like(INV_COD_ARTICULO,'" + codigo + "','i')";
            if (!descripcion.Equals(""))
                sql += " and regexp_like(ARTALM_desc_breve,'" + descripcion + "','i')";
            if (!marca.Equals(""))
                sql += " and regexp_like(MAR_NOMBRE,'" + marca + "','i')";
            if (!modelo.Equals(""))
                sql += " and regexp_like(MOD_DESCRIPCION,'" + modelo + "','i')";
            if (!G.Equals(""))
                sql += " and regexp_like(ARTALM_ORIGINAL,'" + G + "','i')";

            sql += " order by INV_COD_ARTICULO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarInventarioConsigancion(String almacen, string codigo, string descripcion, string marca, string modelo, string G, String pNo_cia)
        {
            String sql = "SELECT DISTINCT INV_COD_ARTICULO, INV_COD_PROVEEDOR, INV_COD_ALMACEN, INV_IMPUESTO_VENTAS, ARTALM_NOMBRE, ";
            sql += "INV_CLASE, (INV_CANTIDAD-INV_CANTIDAD_TRANSITO) AS INV_EXISTENCIA, ARTALM_ORIGINAL, ";
            sql += "INV_MON_VENTA, INV_PRECIO_VENTA, MAR_NOMBRE, MOD_DESCRIPCION, MOD_AÑOINICIO ||' - ' ||MOD_AÑOFIN AÑOS ";
            sql += "FROM TBL_INVENTARIO_MC i, TBL_ARTICULO_BODEGA aa, TBL_MARCA_MC m, TBL_ARTICULO_MARCA_MC am, TBL_MODELO mo ";
            sql += "WHERE i.no_cia = '" + pNo_cia + "' and i.no_cia = aa.no_cia and i.no_cia = m.no_cia and i.no_cia = am.no_cia and i.no_cia = mo.no_cia and INV_COD_ALMACEN = '" + almacen + "' AND ARTALM_TIPO = 'ART' AND ARTALM_ESTADO = 1  ";
            sql += "AND INV_COD_ARTICULO = ARTALM_CODIGO AND INV_COD_PROVEEDOR = ARTALM_PROVEEDOR ";
            sql += "AND ARTMAR_ARTICULO = INV_COD_ARTICULO AND ARTMAR_MARCA = MAR_INDICE ";
            sql += "AND MOD_MARCA = MAR_INDICE ";
            if (!codigo.Equals(""))
                sql += " AND regexp_like(INV_COD_ARTICULO,'" + codigo + "','i')";
            if (!descripcion.Equals(""))
                sql += " AND regexp_like(ARTALM_NOMBRE,'" + descripcion + "','i')";
            if (!marca.Equals(""))
                sql += " AND regexp_like(MAR_NOMBRE,'" + marca + "','i')";
            if (!modelo.Equals(""))
                sql += " AND regexp_like(MOD_DESCRIPCION,'" + modelo + "','i')";
            if (!G.Equals(""))
                sql += " AND regexp_like(ARTALM_ORIGINAL,'" + G + "','i')";

            sql += " ORDER BY INV_COD_ARTICULO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarXAlmacen(String cod, String pNo_cia)
        {
            String sql = "SELECT ARTALM_CODIGO, ARTALM_DESC_BREVE, ARTALM_NOMBRE, ARTALM_PROVEEDOR, ARTALM_MINIMO, ARTALM_MAXIMO, ARTALM_CATEGORIA, ARTALM_ALMACEN, ARTALM_IMPUESTOS, ARTALM_INVENTARIO, ARTALM_ESTADO FROM TBL_ARTICULO_BODEGA aa where aa.no_cia = '" + pNo_cia + "' and ARTALM_almacen = '" + cod + "' and ARTALM_estado=1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public Boolean ExisteEninventario(String codArticulo, String almacen)
        {
            String sql = "select INV_COD_ARTICULO, sum(inv_cantidad), INV_COD_ALMACEN from tbl_inventario_lotes where INV_COD_ARTICULO = '" + codArticulo + "' and INV_COD_ALMACEN = '" + almacen + "' group by INV_COD_ARTICULO, INV_COD_ALMACEN ";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            if (oDataSet.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataSet ConsultaInventario(String codArticulo, String almacen)
        {
            String sql = "select INV_COD_ARTICULO, sum(inv_cantidad) inv_cantidad, INV_COD_ALMACEN from tbl_inventario_lotes where INV_COD_ARTICULO = '" + codArticulo + "' and INV_COD_ALMACEN = '" + almacen + "' group by INV_COD_ARTICULO, INV_COD_ALMACEN ";
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
            String sql = "Select ARTALM_CODIGO as cod, ARTALM_DESC_BREVE as descripcion FROM TBL_ARTICULO_BODEGA aa where aa.no_cia = '" + pNo_cia + "' and ARTALM_estado = 1 and ARTALM_MARCA= '" + linea + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarXLinea(int tipo, String palabra, String linea, String pNo_cia)
        {
            String sql = "Select ARTALM_CODIGO as cod, ARTALM_DESC_BREVE as descripcion FROM TBL_ARTICULO_BODEGA aa where aa.no_cia = '" + pNo_cia + "' and ARTALM_estado = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(ARTALM_CODIGO,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(ARTALM_DESC_BREVE,'" + palabra + "','i')";
            sql += " and ARTALM_MARCA= '" + linea + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarInventarioAreaTrabajo(String almacen, string codigo, string descripcion, string marca, string modelo, string clase, String pNo_cia)
        {
            String sql = "SELECT DISTINCT INV_COD_ARTICULO, INV_COD_PROVEEDOR, INV_COD_ALMACEN, INV_IMPUESTO_VENTAS, ARTALM_NOMBRE, ";
            sql += "INV_CLASE, (INV_CANTIDAD-INV_CANTIDAD_TRANSITO) AS INV_EXISTENCIA, ARTALM_ORIGINAL, ";
            sql += "INV_MON_COMPRA, INV_PRECIO_COMPRA, ";
            sql += "CASE WHEN INV_MON_COMPRA = 'COL' THEN '¢' WHEN INV_MON_VENTA ='USD' THEN '$' ELSE '€' END SIMB_COMPRA,  ";
            sql += "CASE WHEN INV_MON_VENTA = 'COL' THEN '¢' WHEN INV_MON_VENTA ='USD' THEN '$' ELSE '€' END SIMB_VTA,  ";
            sql += "INV_MON_VENTA, INV_PRECIO_VENTA, MAR_NOMBRE, MOD_DESCRIPCION, MOD_AÑOINICIO ||' - ' ||MOD_AÑOFIN AÑOS ";
            sql += "FROM TBL_INVENTARIO_MC i, TBL_ARTICULO_BODEGA aa, TBL_MARCA_MC m, TBL_ARTICULO_MARCA_MC am, TBL_MODELO mo ";
            sql += "WHERE i.no_cia = '" + pNo_cia + "' and i.no_cia = aa.no_cia and i.no_cia = m.no_cia and i.no_cia = am.no_cia and i.no_cia = mo.no_cia and INV_COD_ALMACEN = '" + almacen + "' AND ARTALM_TIPO = 'ART' AND ARTALM_ESTADO = 1  ";
            sql += "AND INV_COD_ARTICULO = ARTALM_CODIGO AND INV_COD_PROVEEDOR = ARTALM_PROVEEDOR ";
            sql += "AND ARTMAR_ARTICULO = INV_COD_ARTICULO AND ARTMAR_MARCA = MAR_INDICE ";
            sql += "AND MOD_MARCA = MAR_INDICE ";
            if (!codigo.Equals(""))
                sql += "AND regexp_like(INV_COD_ARTICULO,'" + codigo + "','i') ";
            if (!descripcion.Equals(""))
                sql += "AND regexp_like(ARTALM_NOMBRE,'" + descripcion + "','i') ";
            if (!marca.Equals(""))
                sql += "AND regexp_like(MAR_NOMBRE,'" + marca + "','i') ";
            if (!modelo.Equals(""))
                sql += "AND regexp_like(MOD_DESCRIPCION,'" + modelo + "','i') ";
            if (!clase.Equals(""))
                sql += "AND regexp_like(INV_CLASE,'" + clase + "','i') ";
            sql += "ORDER BY INV_COD_ARTICULO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarInventarioAreaTrabajo(String almacen, String pNo_cia)
        {
            String sql = "SELECT DISTINCT INV_COD_ARTICULO, INV_COD_PROVEEDOR, INV_COD_ALMACEN, INV_IMPUESTO_VENTAS, ARTALM_NOMBRE, ";
            sql += "INV_CLASE, (INV_CANTIDAD-INV_CANTIDAD_TRANSITO) AS INV_EXISTENCIA, ARTALM_ORIGINAL, ";
            sql += "INV_MON_COMPRA, INV_PRECIO_COMPRA, ";
            sql += "CASE WHEN INV_MON_COMPRA = 'COL' THEN '¢' WHEN INV_MON_VENTA ='USD' THEN '$' ELSE '€' END SIMB_COMPRA,  ";
            sql += "CASE WHEN INV_MON_VENTA = 'COL' THEN '¢' WHEN INV_MON_VENTA ='USD' THEN '$' ELSE '€' END SIMB_VTA,  ";
            sql += "INV_MON_VENTA, INV_PRECIO_VENTA, MAR_NOMBRE, MOD_DESCRIPCION, MOD_AÑOINICIO ||' - ' ||MOD_AÑOFIN AÑOS ";
            sql += "FROM TBL_INVENTARIO_MC i, TBL_ARTICULO_BODEGA aa, TBL_MARCA_MC m, TBL_ARTICULO_MARCA_MC am, TBL_MODELO mo ";
            sql += "WHERE i.no_cia = '" + pNo_cia + "' and i.no_cia = aa.no_cia and i.no_cia = m.no_cia and i.no_cia = am.no_cia and i.no_cia = mo.no_cia and INV_COD_ALMACEN = '" + almacen + "' AND ARTALM_TIPO = 'ART' AND ARTALM_ESTADO = 1  ";
            sql += "AND INV_COD_ARTICULO = ARTALM_CODIGO AND INV_COD_PROVEEDOR = ARTALM_PROVEEDOR ";
            sql += "AND ARTMAR_ARTICULO = INV_COD_ARTICULO AND ARTMAR_MARCA = MAR_INDICE ";
            sql += "AND MOD_MARCA = MAR_INDICE ";
            sql += "ORDER BY INV_COD_ARTICULO";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
    }
}