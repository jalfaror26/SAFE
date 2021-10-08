using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class PantallasPermisosDAO
    {

        public DataSet existePantalla(String id)
        {
            String sql = "select * from TBL_PANTALLAS p where pan_id = '" + id + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public Boolean crearPantalla(String codigo, String modulo, String Nombre, String pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPANTALLASPERMISOS.paInsertarPantalla";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("Id", OracleType.NVarChar);
            oCommand.Parameters[0].Value = codigo;
            oCommand.Parameters.Add("modulo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = modulo;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[2].Value = Nombre;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet tieneAcceso(String id, String usuario, String pNo_cia)
        {
            String sql = "select PER_ACCESO from TBL_PERMISOS p where p.no_cia = '" + pNo_cia + "' and per_estado = 1 and PER_ID_PANTALLA = '" + id + "' and PER_USUARIO = '" + usuario + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public Boolean crearAcceso(String usuario, String pantalla, Int32 acceso, String pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPANTALLASPERMISOS.paCrearAcceso";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = usuario;
            oCommand.Parameters.Add("pantalla", OracleType.NVarChar);
            oCommand.Parameters[1].Value = pantalla;
            oCommand.Parameters.Add("acceso", OracleType.Number);
            oCommand.Parameters[2].Value = acceso;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet consultaPantallas()
        {
            String sql = "select pan_id, pan_modulo, pan_nombre, 0 as acceso from TBL_PANTALLAS p order by pan_modulo, pan_id, pan_nombre";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultaPantallasPermisos(String usuario, String pNo_cia)
        {
            String sql = "select pan_id, pan_modulo, pan_nombre, per_acceso as acceso from TBL_PANTALLAS p, TBL_PERMISOS p2 where p2.no_cia = '" + pNo_cia + "' and pan_id = per_id_pantalla and per_usuario = '" + usuario + "' order by pan_modulo, pan_id, pan_nombre";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public String RutaImagen(string usuario, String pNo_cia)
        {
            String sql = "select fon_ruta from TBL_FONDO f where f.no_cia = '" + pNo_cia + "' and fon_usuario='" + usuario + "'";
            String oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
            return oDataSet;
        }

        public Boolean InsertarFondo(String ruta, String usuario, String pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKFONDO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("ruta", OracleType.NVarChar);
            oCommand.Parameters[0].Value = ruta;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
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
