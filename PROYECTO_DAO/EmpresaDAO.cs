using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;

using ENTIDADES;
using System.Data;
using System.Data.Common;

namespace PROYECTO_DAO
{
    public class EmpresaDAO
    {
        public Boolean Agregar(Empresa oEmpresa, byte[] bLogo)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            if (oEmpresa.NombreLogo.Equals(""))
            {
                oCommand.CommandText = "PCKEMPRESA.paInsertarSinLogo";
                oCommand.CommandType = CommandType.StoredProcedure;

                oCommand.Parameters.Add("TIPO_ID", OracleType.NVarChar);
                oCommand.Parameters[0].Value = oEmpresa.TipoId;
                oCommand.Parameters.Add("IDENTIFICACION", OracleType.NVarChar);
                oCommand.Parameters[1].Value = oEmpresa.Identificacion;
                oCommand.Parameters.Add("NOMBRE", OracleType.NVarChar);
                oCommand.Parameters[2].Value = oEmpresa.Nombre;
                oCommand.Parameters.Add("DIRECCION", OracleType.NVarChar);
                oCommand.Parameters[3].Value = oEmpresa.Ubicacion;
                oCommand.Parameters.Add("TELEFONO", OracleType.NVarChar);
                oCommand.Parameters[4].Value = oEmpresa.Telefono;
                oCommand.Parameters.Add("CORREO", OracleType.NVarChar);
                oCommand.Parameters[5].Value = oEmpresa.Correo;
                oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
                oCommand.Parameters[6].Value = oEmpresa.No_cia;
                oCommand.Parameters.Add("pPAIS", OracleType.NVarChar);
                oCommand.Parameters[7].Value = "1";
                oCommand.Parameters.Add("pPROVINCIA", OracleType.NVarChar);
                oCommand.Parameters[8].Value = oEmpresa.Provincia;
                oCommand.Parameters.Add("pCANTON", OracleType.NVarChar);
                oCommand.Parameters[9].Value = oEmpresa.Canton;
                oCommand.Parameters.Add("pDISTRITO", OracleType.NVarChar);
                oCommand.Parameters[10].Value = oEmpresa.Distrito;
                oCommand.Parameters.Add("pBARRIO", OracleType.NVarChar);
                oCommand.Parameters[11].Value = oEmpresa.Barrio;

                oCommand.Parameters.Add("Fe_Api_Token", OracleType.NVarChar);
                oCommand.Parameters[12].Value = oEmpresa.Fe_Api_Token;
                oCommand.Parameters.Add("Fe_Access_Token", OracleType.NVarChar);
                oCommand.Parameters[13].Value = oEmpresa.Fe_Access_Token;
                oCommand.Parameters.Add("Fe_ActividadComercial", OracleType.NVarChar);
                oCommand.Parameters[14].Value = oEmpresa.Fe_ActividadComercial;
                oCommand.Parameters.Add("Fe_Sucursal", OracleType.NVarChar);
                oCommand.Parameters[15].Value = oEmpresa.Fe_Sucursal;
                oCommand.Parameters.Add("Fe_Caja", OracleType.NVarChar);
                oCommand.Parameters[16].Value = oEmpresa.Fe_Caja;
                oCommand.Parameters.Add("Fe_Ind_Fact_Elect", OracleType.NVarChar);
                oCommand.Parameters[17].Value = oEmpresa.Fe_Ind_Fact_Elect;

            }
            else
            {
                oCommand.CommandText = "PCKEMPRESA.paInsertar";
                oCommand.CommandType = CommandType.StoredProcedure;

                oCommand.Parameters.Add("TIPO_ID", OracleType.NVarChar);
                oCommand.Parameters[0].Value = oEmpresa.TipoId;
                oCommand.Parameters.Add("IDENTIFICACION", OracleType.NVarChar);
                oCommand.Parameters[1].Value = oEmpresa.Identificacion;
                oCommand.Parameters.Add("NOMBRE", OracleType.NVarChar);
                oCommand.Parameters[2].Value = oEmpresa.Nombre;
                oCommand.Parameters.Add("DIRECCION", OracleType.NVarChar);
                oCommand.Parameters[3].Value = oEmpresa.Ubicacion;
                oCommand.Parameters.Add("TELEFONO", OracleType.NVarChar);
                oCommand.Parameters[4].Value = oEmpresa.Telefono;
                oCommand.Parameters.Add("CORREO", OracleType.NVarChar);
                oCommand.Parameters[5].Value = oEmpresa.Correo;
                oCommand.Parameters.Add("imagen", OracleType.Blob, bLogo.Length);
                oCommand.Parameters[6].Value = bLogo;
                oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
                oCommand.Parameters[7].Value = oEmpresa.No_cia;

                oCommand.Parameters.Add("pPAIS", OracleType.NVarChar);
                oCommand.Parameters[8].Value = "1";
                oCommand.Parameters.Add("pPROVINCIA", OracleType.NVarChar);
                oCommand.Parameters[9].Value = oEmpresa.Provincia;
                oCommand.Parameters.Add("pCANTON", OracleType.NVarChar);
                oCommand.Parameters[10].Value = oEmpresa.Canton;
                oCommand.Parameters.Add("pDISTRITO", OracleType.NVarChar);
                oCommand.Parameters[11].Value = oEmpresa.Distrito;
                oCommand.Parameters.Add("pBARRIO", OracleType.NVarChar);
                oCommand.Parameters[12].Value = oEmpresa.Barrio;

                oCommand.Parameters.Add("Fe_Api_Token", OracleType.NVarChar);
                oCommand.Parameters[13].Value = oEmpresa.Fe_Api_Token;
                oCommand.Parameters.Add("Fe_Access_Token", OracleType.NVarChar);
                oCommand.Parameters[14].Value = oEmpresa.Fe_Access_Token;
                oCommand.Parameters.Add("Fe_ActividadComercial", OracleType.NVarChar);
                oCommand.Parameters[15].Value = oEmpresa.Fe_ActividadComercial;
                oCommand.Parameters.Add("Fe_Sucursal", OracleType.NVarChar);
                oCommand.Parameters[16].Value = oEmpresa.Fe_Sucursal;
                oCommand.Parameters.Add("Fe_Caja", OracleType.NVarChar);
                oCommand.Parameters[17].Value = oEmpresa.Fe_Caja;
                oCommand.Parameters.Add("Fe_Ind_Fact_Elect", OracleType.NVarChar);
                oCommand.Parameters[18].Value = oEmpresa.Fe_Ind_Fact_Elect;
            }

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }


        public Boolean ActualizaParametro(String pNo_cia, String pParametro, String pValor)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();


            oCommand.CommandText = "PCKEMPRESA.paActualizaParametro";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[0].Value = pNo_cia;
            oCommand.Parameters.Add("pParametro", OracleType.NVarChar);
            oCommand.Parameters[1].Value = pParametro;
            oCommand.Parameters.Add("pValor", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pValor;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet consultar(String pNo_cia)
        {
            String sql = "SELECT EMPR_TIPO_ID, EMPR_IDENTIFICACION, EMPR_NOMBRE, EMPR_DIRECCION, EMPR_TELEFONO, EMPR_CORREO, EMPR_LOGO, PROVINCIA, CANTON, DISTRITO, BARRIO, ind_facturasabiertas, IND_FACT_ELECT, API_TOKEN_WS_FE, ACCESS_TOKEN_WS_FE, CODIGO_ACTIVIDAD, SUCURSAL, CAJA FROM TBL_EMPRESA em where no_cia = '" + pNo_cia + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta()
        {
            String sql = "SELECT NO_CIA, EMPR_NOMBRE FROM TBL_EMPRESA em ORDER BY NO_CIA";
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
