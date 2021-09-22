using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;
using System.Data;
using System.Data.OracleClient;


namespace PROYECTO_DAO
{
    public class Articulo_LineaProductoDAO_MC
    {
        public Boolean Agregar(Servicio_LineaProducto oArticulo_Marcas_MC, String ruta)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKARTICULOMARCA_MC.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oArticulo_Marcas_MC.Articulo;
            oCommand.Parameters.Add("marca", OracleType.Number);
            oCommand.Parameters[1].Value = oArticulo_Marcas_MC.Marca;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oArticulo_Marcas_MC.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Articulo_Marcasado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Servicio_LineaProducto oArticulo_Marcas_MC)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKARTICULOMARCA_MC.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("codigo", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oArticulo_Marcas_MC.Articulo;
            oCommand.Parameters.Add("marca", OracleType.Number);
            oCommand.Parameters[1].Value = oArticulo_Marcas_MC.Marca;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oArticulo_Marcas_MC.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento Articulo_Marcasado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar(string codigo, String pNo_cia)
        {

            String sql = "SELECT ARTMAR_MARCA ,MAR_NOMBRE LINPRO_NOMBRE FROM TBL_ARTICULO_MARCA_MC am, TBL_MARCA_MC m where am.no_cia = '" + pNo_cia + "' and am.no_cia = m.no_cia and ARTMAR_MARCA=MAR_INDICE and ARTMAR_ARTICULO='" + codigo + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Busqueda_Consulta(String pNo_cia)
        {

            String sql = "Select ART_INDICE as cod, art_desc_breve as descripcion FROM TBL_ARTICULO_MARCA_MC am where am.no_cia = '" + pNo_cia + "' and art_estado = 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar_Filtrado(int tipo, String palabra, String pNo_cia)
        {
            String sql = "Select ART_INDICE as cod, art_desc_breve as descripcion FROM TBL_ARTICULO_MARCA_MC am where am.no_cia = '" + pNo_cia + "' and art_estado = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(ART_INDICE,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(art_desc_breve,'" + palabra + "','i')";
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