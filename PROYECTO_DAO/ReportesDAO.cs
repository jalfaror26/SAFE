using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Collections;

namespace PROYECTO_DAO
{
    public class ReportesDAO
    {
        public DataSet ConsultaSaldosFacturasPendientes(String sql)
        {
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultaRecibosDineroCliente(String sql)
        {
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet EjecutaSentencia(String sql)
        {
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        
    }
}
