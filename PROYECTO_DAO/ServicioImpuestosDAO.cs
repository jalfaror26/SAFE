using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data;
using System.Data.OracleClient;


namespace PROYECTO_DAO
{
    public class ServicioImpuestosDAO
    {
        public Boolean Agregar(ServicioImpuestos oServicioImpuestos)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKSERVICIO_IMPUESTOS.paGuardar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("pclave", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oServicioImpuestos.Clave;
            oCommand.Parameters.Add("pcodigoServicio", OracleType.Number);
            oCommand.Parameters[1].Value = oServicioImpuestos.IndiceServicio;
            oCommand.Parameters.Add("pafectaVenta", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oServicioImpuestos.AfectaVenta;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oServicioImpuestos.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(ServicioImpuestos oServicioImpuestos)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKSERVICIO_IMPUESTOS.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("pclave", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oServicioImpuestos.Clave;
            oCommand.Parameters.Add("pcodigoServicio", OracleType.Number);
            oCommand.Parameters[1].Value = oServicioImpuestos.IndiceServicio;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oServicioImpuestos.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataTable ConsultarEspecificoCodigo(String codigo, String pNo_cia)
        {
            String sql = "SELECT i.clave, i.descripcion fROM tbl_impuestos i, tbl_servicio_impuestos si WHERE i.no_cia = '" + pNo_cia + "' and i.no_cia = si.no_cia and i.clave = si.clave and si.codigo_servicio ='" + codigo + "'";
            DataTable oDataTable = OracleDAO.getInstance().EjecutarSQLDataTable(sql);
            return oDataTable;
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