using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace PROYECTO_DAO
{
    public class ConexionDAO
    {
        private String codigoUsuario = "";
        private String claveUsuario = "";
        private String servidorBaseDatos = "";

        public ConexionDAO(String codUsuario, String servidor, String clave)
        {
            codigoUsuario = codUsuario;
            claveUsuario = clave;
            servidorBaseDatos = servidor;
        }

        public Boolean abrirConexion()
        {
            if (OracleDAO.getInstance(servidorBaseDatos, codigoUsuario, claveUsuario).AbrirConexion())
                return true;
            else
                return false;
        }


        public void QuitarInstance()
        {
            OracleDAO.getInstance().QuitarInstance();
        }

        public Boolean cerrarConexion()
        {
            if (OracleDAO.getInstance().CerrarConexion() == false)
                return true;
            else
                return false;
        }

        public Boolean existeUsuario(String usuario, String clave, String pNo_cia)
        {
            Boolean existe = false;
            try
            {
                String sql = "Select usuario from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and usuario = '" + usuario + "' and (contrasenna = '" + clave + "' or CODIGO_BARRAS = '" + clave + "')";

                DataSet oDataSet = null;
                oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);

                if (oDataSet.Tables[0].Rows.Count > 0)
                    existe = true;
            }
            catch { }
            return existe;
        }
        
        public Boolean existeUsuarioAdministrador(String usuario, String clave, String pNo_cia)
        {
            Boolean existe = false;
            try
            {
                String sql = "Select usuario from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and usuario = '" + usuario + "' and contrasenna = '" + clave + "' and ROL='ADMINISTRADOR'";
                DataSet oDataSet = null;
                oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);

                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    existe = true;
                }
            }
            catch { }
            return existe;
        }


        public Boolean existeUsuarioAdministrador2(String codigoBarras, out String usuario, String pNo_cia)
        {
            Boolean existe = false;
            usuario = "";
            try
            {
                String sql = "Select usuario from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and codigo_barras = '" + codigoBarras + "' and ROL='ADMINISTRADOR'";
                DataSet oDataSet = null;
                oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);

                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    usuario = oDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                    existe = true;
                }
            }
            catch { }
            return existe;
        }

        public Boolean EsUsuarioAdministrador(String usuario, out String codigoBarras, String pNo_cia)
        {
            Boolean existe = false;
            codigoBarras = "";
            try
            {
                String sql = "Select codigo_barras from TBUSUARIO u where u.no_Cia = '" + pNo_cia + "' and usuario = '" + usuario + "' and ROL='ADMINISTRADOR'";
                DataSet oDataSet = null;
                oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);

                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    codigoBarras = oDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                    existe = true;
                }
            }
            catch { }
            return existe;
        }

        public Boolean estadoConexion()
        {
            return OracleDAO.getInstance().EstadoConexion();
        }

        public void insertar(String usuario, String clave, String pNo_cia)
        {
            String sql = "insert into TBUSUARIO u (usuario, contrasenna, fecha,no_cia) values ('" + usuario + "','" + clave + "', sysdate, '" + pNo_cia + "');";
        }

        public DateTime fecha()
        {
            String sql = "select sysdate from dual";
            DateTime fecha = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return fecha;
        }

        public void coomit()
        {
            String sql = "commit";
            OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public void rollback()
        {
            String sql = "rollback";
            OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public DataTable EjecutaSentencia(String sql)
        {
            DataTable otabla = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return otabla;
        }

        public Int32 EjecutaSentencia2(String sql)
        {
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public String DescError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Boolean Error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }

        public DataTable EjecutaSQLDataTable(string sql)
        {
            return OracleDAO.getInstance().EjecutarSQLDataTable(sql);
        }

        public DataTable TraerTipoCambio(String pNo_cia)
        {
            String sql = "SELECT FECHA_REGISTRO, CAMBIO_DOLAR, CAMBIOEURO FROM TBL_TIPOS_CAMBIO tc where tc.no_cia = '" + pNo_cia + "' and  to_char(FECHA_REGISTRO,'dd/mm/yyy') = to_char(sysdate,'dd/mm/yyy')";
            DataTable otabla = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return otabla;
        }

    }
}
