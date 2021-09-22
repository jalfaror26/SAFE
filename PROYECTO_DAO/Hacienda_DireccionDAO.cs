using PROYECTO_DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_DAO
{
    public class Hacienda_DireccionDAO
    {

        public DataSet consulta_Provincias()
        {
            String sql = "select provincia, descripcion from tbl_provincia e where e.pais = 1 order by 1, 2";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consulta_Cantones(String pProvincia)
        {
            String sql = "select canton, descripcion from tbl_canton e where e.pais = 1 and e.provincia = '" + pProvincia + "' order by 2, 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consulta_Distritos(String pProvincia, String pCanton)
        {
            String sql = "select distrito, descripcion from tbl_distrito e where e.pais = 1 and e.provincia = '" + pProvincia + "' and e.canton = '" + pCanton + "' order by 2, 1";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consulta_Barrios(String pProvincia, String pCanton, String pDistrito)
        {
            String sql = "select barrio, descripcion from tbl_barrio e where e.pais = 1 and e.provincia = '" + pProvincia + "' and e.canton = '" + pCanton + "' and e.distrito = '" + pDistrito + "' order by 2, 1";
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
