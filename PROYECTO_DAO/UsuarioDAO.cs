using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.OracleClient;

namespace PROYECTO_DAO
{
    public class UsuarioDAO
    {
        public Boolean Agregar(String nomusuario, String contraseña, String rol, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = nomusuario;
            oCommand.Parameters.Add("pass", OracleType.NVarChar);
            oCommand.Parameters[1].Value = contraseña;
            oCommand.Parameters.Add("rol", OracleType.NVarChar);
            oCommand.Parameters[2].Value = rol;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean GuardarImagen(String nomusuario, byte[] imagen, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paGuardarImagen";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = nomusuario;
            oCommand.Parameters.Add("usimagen", OracleType.Blob);
            oCommand.Parameters[1].Value = imagen;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean CambiarContraseña(String nomusuario, string Contraseña, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paCambiarContraseña";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = nomusuario;
            oCommand.Parameters.Add("contraseña", OracleType.NVarChar);
            oCommand.Parameters[1].Value = Contraseña;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }
        
        public Boolean Eliminar(String nomusuario, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = nomusuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }
        
        public DataSet consultaUsuarios(String pNo_cia)
        {
            String sql = "select usuario, rol from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and estado = 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultaUsuarioCentros(String pUsuario, String pNo_cia)
        {
            String sql = "select cen_codigo cod, cen_nombre descripcion, acceso accesoCentro from tbl_usuario_centro_mc uc, tbl_centro_mc c where uc.usuario = '" + pUsuario + "' and uc.no_Cia = '" + pNo_cia + "' and uc.no_Cia = c.no_cia and uc.centro = c.cen_codigo and c.cen_estado = 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }


        public DataTable consultaImagen(String nomusuario, String pNo_cia)
        {
            String sql = "select IMAGEN from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and estado = 1 and usuario='" + nomusuario + "'";
            DataTable oDataSet = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
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
