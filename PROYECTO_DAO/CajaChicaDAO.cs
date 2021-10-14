using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data.OracleClient;
using System.Data;

namespace PROYECTO_DAO
{
    public class CajaChicaDAO
    {
        public Int64 Abrir(CajaChica oCajaChica, String pNo_cia)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCAJA_CHICA.paAbrir";
            oCommand.CommandType = CommandType.StoredProcedure;
            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "caja";
            oParametro.Value = 0;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[0].Value = oCajaChica.Monto;
            oCommand.Parameters.Add("documento", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCajaChica.Documento;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oCajaChica.Usuario;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[3].Value = oCajaChica.Saldo;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCajaChica.Moneda;         
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[5].Value = pNo_cia;

            oCommand.Parameters.Add(oParametro);

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            Int64 cadena = Int64.Parse(oParametro.Value.ToString());
            return cadena;
        }

        public Boolean ActualizarSaldo(CajaChica oCajaChica, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCAJA_CHICA.paActualizarSaldo";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCajaChica.Linea;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[1].Value = oCajaChica.Saldo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;


            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento LibroCuentassado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean ActualizarMonto(CajaChica oCajaChica, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCAJA_CHICA.paActualizarMonto";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCajaChica.Linea;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[1].Value = oCajaChica.Monto;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;


            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento LibroCuentassado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Cerrar(CajaChica oCajaChica, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCAJA_CHICA.paCerrar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oCajaChica.Linea;

            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCajaChica.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento LibroCuentassado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String usuario, String pNo_cia)
        {
            //    String sql = "SELECT CAJ_DOCUMENTO,CAJ_CTA_BANCO || '  **  '||BAN_SIGLAS || '  **  '||BAN_NOMBRE, CAJ_MONTO, CAJ_SALDO,CAJ_MONEDA, caj_linea fROM TBL_CAJA_CHICA, TBL_BANCOS, TBL_CUENTAS_BANCARIAS where CTABAN_CTA=CAJ_CTA_BANCO and upper(CTABAN_IDBANCO)=upper(BAN_SIGLAS) and CAJ_ESTADO=1 and CAJ_USUARIOABRE = '" + usuario + "'";

            String sql = "SELECT CAJ_DOCUMENTO,'', CAJ_MONTO, CAJ_SALDO,CAJ_MONEDA, caj_linea fROM TBL_CAJA_CHICA where CAJ_ESTADO=1 and CAJ_USUARIOABRE = '" + usuario + "' and no_cia = '" + pNo_cia + "'";

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

        public DateTime fecha()
        {
            String sql = "SELECT sysdate from dual";
            DateTime oDataSet = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return oDataSet;
        }
        
        public DateTime FechaAperturaCaja(string caja, String usuario, String pNo_cia)
        {
            String sql = "SELECT CAJ_FECHAAPERTURA FROM tbl_caja_chica where CAJ_LINEA =" + caja + " and CAJ_ESTADO =1 and CAJ_USUARIOABRE = '" + usuario + "' and no_cia = '" + pNo_cia + "'";
            DateTime oDateTime = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return oDateTime;
        }

        public DataSet Caja(String usuario, String pNo_cia)
        {
            String sql = "SELECT CAJ_LINEA,CAJ_SALDO FROM tbl_caja_chica where CAJ_ESTADO =1 and CAJ_USUARIOABRE = '" + usuario + "' and no_cia = '" + pNo_cia + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public double ultimoSaldo(String usuario, String pNo_cia)
        {
            String sql = "SELECT CAJ_SALDO FROM TBL_CAJA_CHICA where CAJ_LINEA=(SELECT max(CAJ_LINEA) FROM tbl_caja_chica) and CAJ_ESTADO=0 and CAJ_USUARIOABRE = '" + usuario + "' and no_cia = '" + pNo_cia + "'";
            Double oDataSet = OracleDAO.getInstance().EjecutarSQLScalarDouble(sql);
            return oDataSet;
        }

        public string ultimoMoneda(String usuario, String pNo_cia)
        {
            String sql = "SELECT CAJ_Moneda FROM TBL_CAJA_CHICA where CAJ_LINEA=(SELECT max(CAJ_LINEA) FROM tbl_caja_chica) and CAJ_ESTADO=0 and CAJ_USUARIOABRE = '" + usuario + "' and no_cia = '" + pNo_cia + "'";
            String oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
            return oDataSet;
        }

        public DataTable TipoCambio()
        {
            String sql = "SELECT CAMBIO_DOLAR  FROM TBL_TIPOS_CAMBIO where to_char(FECHA_REGISTRO)=to_char(sysdate)";
            DataTable oDataSet = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataSet;
        }
    }
}
