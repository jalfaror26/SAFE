using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ENTIDADES;
using System.Data.OracleClient;


namespace PROYECTO_DAO
{
    public class GuiaPrepagoProveedorDAO
    {
        public int Agregar(GuiaPrepagoProveedor oGuiaPrepagoProveedor)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();
            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "indice";
            oParametro.Value = 0;

            oCommand.CommandText = "PCKPREPAGOPROVEEDOR.paCrear";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oGuiaPrepagoProveedor.Proveedor;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oGuiaPrepagoProveedor.Moneda;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oGuiaPrepagoProveedor.No_cia;

            oCommand.Parameters.Add(oParametro);

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return int.Parse(oParametro.Value.ToString());
        }

        public Boolean Modificar(GuiaPrepagoProveedor oGuiaPrepagoProveedor)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPREPAGOPROVEEDOR.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("preid", OracleType.Number);
            oCommand.Parameters[0].Value = oGuiaPrepagoProveedor.Id;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[1].Value = oGuiaPrepagoProveedor.Monto;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oGuiaPrepagoProveedor.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Cerrar(GuiaPrepagoProveedor oGuiaPrepagoProveedor)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKPREPAGOPROVEEDOR.paCerrar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("preid", OracleType.Number);
            oCommand.Parameters[0].Value = oGuiaPrepagoProveedor.Id;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oGuiaPrepagoProveedor.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String pNo_cia)
        {

            String sql = "SELECT PROV_ID, PROV_NOMBRE, PROV_TELEFONO, PROV_FAX, PROV_CONTACTO, PROV_TEL_CONTACTO, PROV_UBICACION, PROV_DESCRIPCION, PROV_DIAS, PROV_CATEGORIA FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_ESTADO=1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ConsultarExistente(string moneda, string proveedor, String pNo_cia)
        {

            String sql = "SELECT PRE_ID, Pre_Monto_Total FROM TBL_PREPAGOS_PROVEEDORES PPP where ppp.no_cia = '" + pNo_cia + "' and pre_estado ='GP' and pre_moneda ='" + moneda + "' and upper(pre_proveedor)=upper('" + proveedor + "')";
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
