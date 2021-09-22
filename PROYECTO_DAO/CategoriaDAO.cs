using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using ENTIDADES;

namespace PROYECTO_DAO
{
    public class CategoriaDAO
    {
        public Boolean Agregar(Categoria oCategoria_MC)
        {

            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCATEGORIA_MC.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oCategoria_MC.Descripcion;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCategoria_MC.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(Categoria oCategoria_MC)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCATEGORIA_MC.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oCategoria_MC.Descripcion;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[1].Value = oCategoria_MC.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oCategoria_MC.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Categoria oCategoria_MC)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKCATEGORIA_MC.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCategoria_MC.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCategoria_MC.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String pNo_cia)
        {
            String sql = "SELECT CAT_INDICE cod, CAT_DESCRIPCION descripcion FROM TBL_CATEGORIA_MC c where c.no_cia = '" + pNo_cia + "' and CAT_ESTADO = 1 ORDER BY CAT_DESCRIPCION";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta(String pNo_cia)
        {
            String sql = "SELECT CAT_INDICE, CAT_DESCRIPCION FROM TBL_CATEGORIA_MC c where c.no_cia = '" + pNo_cia + "' and CAT_ESTADO = 1 ORDER BY CAT_DESCRIPCION";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT CAT_INDICE cod, CAT_DESCRIPCION descripcion FROM TBL_CATEGORIA_MC c where c.no_cia = '" + pNo_cia + "' and CAT_ESTADO = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(CAT_INDICE,'" + palabra + "','i') ";
            if (tipo == 2)
                sql += " regexp_like(CAT_DESCRIPCION,'" + palabra + "','i') ";
            sql += "ORDER BY CAT_DESCRIPCION";
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

        public DataSet Listar_Filtrado(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT CAT_INDICE, CAT_DESCRIPCION FROM TBL_CATEGORIA_MC c where c.no_cia = '" + pNo_cia + "' and CAT_ESTADO = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(CAT_INDICE,'" + palabra + "','i') order by CAT_INDICE";
            if (tipo == 2)
                sql += " regexp_like(CAT_DESCRIPCION,'" + palabra + "','i') order by CAT_DESCRIPCION";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

    }
}
