using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ENTIDADES;
using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class ImpuestosDAO
    {
        //public Boolean Agregar(Embalaje oEmbalaje)
        //{
        //    OracleCommand oCommand = new OracleCommand();

        //    oCommand.CommandText = "PCKEMBALAJE_MC.paGuardar";
        //    oCommand.CommandType = CommandType.StoredProcedure;
        //    oCommand.Parameters.Add("codigo", OracleType.NVarChar);
        //    oCommand.Parameters[0].Value = oEmbalaje.Codigo;
        //    oCommand.Parameters.Add("nombre", OracleType.NVarChar);
        //    oCommand.Parameters[1].Value = oEmbalaje.Descripcion;
        //    oCommand.Parameters.Add("estado", OracleType.NVarChar);
        //    oCommand.Parameters[2].Value = oEmbalaje.Estado;
        //    oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
        //    oCommand.Parameters[3].Value = oEmbalaje.No_cia;

        //    OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
        //    return !OracleDAO.getInstance().ErrorSQL;
        //}

        public DataSet consultar(String pNo_cia)
        {

            String sql = "SELECT clave , descripcion, emb_estado FROM tbl_impuestos em WHERE em.no_cia = '" + pNo_cia + "' ORDER BY clave, descripcion";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT clave , descripcion, emb_estado FROM tbl_impuestos em WHERE em.no_cia = '" + pNo_cia + "' and ";
            if (tipo == 1)
                sql += " regexp_like(clave,'" + palabra + "','i') ORDER BY clave, descripcion";
            if (tipo == 2)
                sql += " regexp_like(descripcion,'" + palabra + "','i') ORDER BY clave, descripcion";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta(String pNo_cia)
        {

            String sql = "SELECT clave as cod, descripcion as des FROM tbl_impuestos em WHERE em.no_cia = '" + pNo_cia + "' ORDER BY descripcion";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultar2(String pNo_cia)
        {

            String sql = "SELECT clave, descripcion FROM tbl_impuestos em WHERE em.no_cia = '" + pNo_cia + "' ORDER BY porcentaje";
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
