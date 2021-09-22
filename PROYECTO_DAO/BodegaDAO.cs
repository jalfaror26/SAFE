using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data;

using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class BodegaDAO
    {
        public Boolean Agregar(Bodega oBodega)
        {

            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKBODEGA_MC.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("almId", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oBodega.Id;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oBodega.Descripcion;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[2].Value = oBodega.Indice;
            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oBodega.Tipo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oBodega.No_cia;
            oCommand.Parameters.Add("pCentro", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oBodega.Centro;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Bodega oBodega)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKBODEGA_MC.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("almId", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oBodega.Id;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[1].Value = oBodega.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oBodega.No_cia;
            oCommand.Parameters.Add("pCentro", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oBodega.Centro;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Int32 Modificar(Bodega oBodega, String actividad)
        {
            String sql = "Update TBL_BODEGA_MC b set alm_descripcion = '" + oBodega.Descripcion + "', alm_actividad = '" + actividad + "', alm_cliente = '" + oBodega.Cliente + "' where no_cia = '" + oBodega.No_cia + "' and b.centro = '" + oBodega.Centro + "' and alm_id = '" + oBodega.Id + "' and alm_indice = '" + oBodega.Indice + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public DataSet ConsultarTodos(Boolean mostrarPromocion, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID, ALM_DESCRIPCION, ALM_INDICE,alm_tipo FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and ";

            if (mostrarPromocion)
                sql += " ALM_ESTADO > 0";
            else
                sql += " ALM_ESTADO = 1 ";
            sql += " order by ALM_DESCRIPCION";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarTodos(int tipo, String palabra, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID, ALM_descripcion, alm_indice, alm_tipo FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and ALM_ESTADO = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(ALM_ID,'" + palabra + "','i') order by ALm_descripcion";
            if (tipo == 2)
                sql += " regexp_like(ALM_descripcion,'" + palabra + "','i') order by ALm_descripcion";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataTable ConsultarNombreTipo(String cod, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_DESCRIPCION, alm_tipo FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and ALM_ID = '" + cod + "' AND ALM_ESTADO=1";
            return OracleDAO.getInstance().EjecutarSQLDataTable(sql);
        }

        public DataSet ConsultaxTipo(string tipo, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID as cod, ALM_DESCRIPCION as descripcion FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and  ALM_ESTADO = 1 and ALM_TIPO='" + tipo + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultaxArticulo_Proveedor_Tipo(String articulo, string proveedor, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID as cod, ALM_DESCRIPCION as descripcion FROM TBL_BODEGA_MC b,TBL_ARTICULO_BODEGA_MC aa where b.no_cia = '" + pNo_cia + "' and b.no_cia = aa.no_Cia and b.centro = '" + pCentro + "' and ARTALM_CODIGO='" + articulo + "' and ARTALM_PROVEEDOR='" + proveedor + "' and ALM_ESTADO = 1 and ARTALM_ALMACEN=ALM_ID";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarTodosConsulta(String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID as cod, ALM_DESCRIPCION as descripcion FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and ALM_ESTADO IN (1,2) order by alm_cliente desc,ALM_DESCRIPCION";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarTodosConsulta(int tipo, String palabra, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID as cod, ALM_DESCRIPCION as descripcion FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and ALM_ESTADO IN (1,2) and ";
            if (tipo == 1)
                sql += " regexp_like(ALM_ID,'" + palabra + "','i') order by alm_cliente desc,ALm_descripcion";
            if (tipo == 2)
                sql += " regexp_like(ALM_descripcion,'" + palabra + "','i') order by alm_cliente desc,ALm_descripcion";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarxArticulo_Proveedor_Tipo(int tipo, String palabra, String articulo, string proveedor, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID as cod, ALM_DESCRIPCION as descripcion FROM TBL_BODEGA_MC b, TBL_ARTICULO_BODEGA_MC aa where b.no_cia = '" + pNo_cia + "' b.no_cia = aa.no_cia and b.centro = '" + pCentro + "' and ARTALM_CODIGO='" + articulo + "' and ARTALM_PROVEEDOR='" + proveedor + "' and ALM_ESTADO = 1 and ARTALM_ALMACEN=ALM_ID and ";
            if (tipo == 1)
                sql += " regexp_like(ALM_ID,'" + palabra + "','i') order by ALm_descripcion";
            if (tipo == 2)
                sql += " regexp_like(ALM_descripcion,'" + palabra + "','i') order by ALm_descripcion";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarxTipo(int tipo, String palabra, string tipoAlmacen, String pNo_cia, String pCentro)
        {
            String sql = "SELECT ALM_ID as cod, ALM_DESCRIPCION as descripcion FROM TBL_BODEGA_MC b where no_cia = '" + pNo_cia + "' and b.centro = '" + pCentro + "' and ALM_ESTADO = 1 and ALM_TIPO='" + tipoAlmacen + "' and";
            if (tipo == 1)
                sql += " regexp_like(ALM_ID,'" + palabra + "','i') order by ALm_descripcion";
            if (tipo == 2)
                sql += " regexp_like(ALM_descripcion,'" + palabra + "','i') order by ALm_descripcion";
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