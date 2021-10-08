using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.OracleClient;
using Entidades;

namespace PROYECTO_DAO
{
    public class UsuarioDAO
    {
        public Boolean Agregar(Usuario oUsuario, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oUsuario.CodUsuario;
            oCommand.Parameters.Add("pass", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oUsuario.Contrasenna;
            oCommand.Parameters.Add("rol", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oUsuario.Rol;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = pNo_cia;

            oCommand.Parameters.Add("pNombre", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oUsuario.Nombre;
            oCommand.Parameters.Add("pApellido1", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oUsuario.Apellido1;
            oCommand.Parameters.Add("pApellido2", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oUsuario.Apellido2;
            oCommand.Parameters.Add("pCedula", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oUsuario.Cedula;
            oCommand.Parameters.Add("pEmail", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oUsuario.Email;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean GuardarImagen(Usuario oUsuario, byte[] imagen, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paGuardarImagen";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oUsuario.CodUsuario;
            oCommand.Parameters.Add("usimagen", OracleType.Blob);
            oCommand.Parameters[1].Value = imagen;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean CambiarContraseņa(Usuario oUsuario, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paCambiarContraseņa";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oUsuario.CodUsuario;
            oCommand.Parameters.Add("contraseņa", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oUsuario.Contrasenna;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }
        
        public Boolean Eliminar(Usuario oUsuario, string pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKUSUARIO.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("nomUsuario", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oUsuario.CodUsuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }
        
        public DataSet consultaUsuarios(String pNo_cia)
        {
            String sql = "select usuario, rol, cedula, nombre, apellido1, apellido2, email from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and estado = 1";
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
