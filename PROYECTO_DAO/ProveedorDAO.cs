using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data.OracleClient;
using System.Data;


namespace PROYECTO_DAO
{
    public class ProveedorDAO
    {
        public Boolean Agregar(Proveedor oProveedor)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROVEEDOR.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProveedor.Indice;
            oCommand.Parameters.Add("provTipoID", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oProveedor.TipoID;
            oCommand.Parameters.Add("provId", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oProveedor.Id;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProveedor.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProveedor.Telefono;
            oCommand.Parameters.Add("fax", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oProveedor.Fax;
            oCommand.Parameters.Add("contacto", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oProveedor.Contacto;
            oCommand.Parameters.Add("telcontacto", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oProveedor.TelContacto;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oProveedor.Ubicacion;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oProveedor.Descripcion;
            oCommand.Parameters.Add("dias", OracleType.Number);
            oCommand.Parameters[10].Value = oProveedor.Dias;
            oCommand.Parameters.Add("categoria", OracleType.NVarChar);
            oCommand.Parameters[11].Value = oProveedor.Categoria;
            oCommand.Parameters.Add("refbancaria", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oProveedor.RefBancaria;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oProveedor.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(Proveedor oProveedor)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKPROVEEDOR.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProveedor.Indice;
            oCommand.Parameters.Add("provTipoID", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oProveedor.TipoID;
            oCommand.Parameters.Add("provId", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oProveedor.Id;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oProveedor.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oProveedor.Telefono;
            oCommand.Parameters.Add("fax", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oProveedor.Fax;
            oCommand.Parameters.Add("contacto", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oProveedor.Contacto;
            oCommand.Parameters.Add("telcontacto", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oProveedor.TelContacto;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oProveedor.Ubicacion;
            oCommand.Parameters.Add("descripcion", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oProveedor.Descripcion;
            oCommand.Parameters.Add("dias", OracleType.Number);
            oCommand.Parameters[10].Value = oProveedor.Dias;
            oCommand.Parameters.Add("categoria", OracleType.NVarChar);
            oCommand.Parameters[11].Value = oProveedor.Categoria;
            oCommand.Parameters.Add("refbancaria", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oProveedor.RefBancaria;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oProveedor.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Proveedor oProveedor)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKPROVEEDOR.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oProveedor.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oProveedor.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(String pNo_cia)
        {
            String sql = "SELECT PROV_LINEA, PROV_ID, PROV_TIPO_ID, PROV_NOMBRE, PROV_TELEFONO, PROV_FAX, PROV_CONTACTO, PROV_TEL_CONTACTO, PROV_UBICACION, PROV_DESCRIPCION, PROV_DIAS, PROV_CATEGORIA, prov_refBancaria FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_ESTADO = 1 and prov_linea > 0";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Consultar(String codigo, String pNo_cia)
        {
            String sql = "SELECT PROV_LINEA, PROV_ID, PROV_TIPO_ID, PROV_NOMBRE, PROV_TELEFONO, PROV_FAX, PROV_CONTACTO, PROV_TEL_CONTACTO, PROV_UBICACION, PROV_DESCRIPCION, PROV_DIAS, PROV_CATEGORIA, prov_refBancaria FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_ESTADO = 1 and PROV_LINEA = '" + codigo + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta(String pNo_cia)
        {
            String sql = "SELECT PROV_LINEA as cod, PROV_NOMBRE as descripcion FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_ESTADO = 1 and prov_linea > 0 ORDER BY PROV_NOMBRE";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public String ConsultarNombre(String cod, String pNo_cia)
        {
            String sql = "SELECT PROV_NOMBRE FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_LINEA = '" + cod + "' and PROV_ESTADO = 1";
            String oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT PROV_LINEA, PROV_ID, PROV_TIPO_ID, PROV_NOMBRE, PROV_TELEFONO, PROV_FAX, PROV_CONTACTO, PROV_TEL_CONTACTO, PROV_UBICACION, PROV_DESCRIPCION, PROV_DIAS, PROV_CATEGORIA, prov_refBancaria FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_ESTADO=1 and prov_linea > 0 and ";
            if (tipo == 1)
                sql += " regexp_like(PROV_LINEA,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(PROV_NOMBRE,'" + palabra + "','i')";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar_Filtrado(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT PROV_LINEA as cod, PROV_NOMBRE as descripcion FROM TBL_PROVEEDOR p where p.no_cia = '" + pNo_cia + "' and  PROV_ESTADO = 1 and prov_linea > 0 and ";
            if (tipo == 1)
                sql += " regexp_like(PROV_LINEA,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(PROV_NOMBRE,'" + palabra + "','i')";
            sql += " ORDER BY PROV_NOMBRE";
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
