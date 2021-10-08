using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using ENTIDADES;
using System.Data;


namespace PROYECTO_DAO
{
    public class GastoDAO
    {
        public Boolean Guardar(Gasto oGasto)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKGASTOS.paGuardar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oGasto.Indice;
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oGasto.Codigo;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oGasto.Nombre;
            oCommand.Parameters.Add("tipo", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oGasto.Tipo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oGasto.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Serviciosado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Gasto oGasto)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKGASTOS.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oGasto.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oGasto.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Serviciosado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String pNo_cia)
        {

            String sql = "SELECT gas_Indice, GAS_Codigo, Gas_NOMBRE, gas_tipo FROM TBL_GASTOS g where g.no_cia = '" + pNo_cia + "' and Gas_ESTADO = 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT gas_Indice , GAS_Codigo, Gas_NOMBRE, gas_tipo FROM TBL_GASTOS g where g.no_cia = '" + pNo_cia + "' and Gas_ESTADO = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(GAS_CODIGO,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(GAS_NOMBRE,'" + palabra + "','i')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Consultar2(String pNo_cia)
        {

            String sql = "SELECT GAS_Codigo cod, Gas_NOMBRE descripcion FROM TBL_GASTOS g where g.no_cia = '" + pNo_cia + "' and Gas_ESTADO = 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar2(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT GAS_Codigo cod, Gas_NOMBRE descripcion FROM TBL_GASTOS g where g.no_cia = '" + pNo_cia + "' and Gas_ESTADO = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(GAS_CODIGO,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(GAS_NOMBRE,'" + palabra + "','i')";
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
