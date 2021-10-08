using System;
using System.Data;
using System.Data.OracleClient;

namespace PROYECTO_DAO
{
	/// <summary>
    /// Clase que contiene metodos estaticos que son utilizados por las clases de acceso a datos
    /// </summary>
    /// <remarks>
    /// Sistema:                Administrativo
    /// Fecha de creacion:      29/06/2008
    /// Fecha de modificacion:  17/09/2009
    /// </remarks>
	public class Util
	{
		/// <summary>
        /// Crea parametros de tipo cursor por referencia utilizado para obtener los result set de las consultas
        /// </summary>
        /// <returns>Parametro creado</returns>
		public static object CrearCursor()
        {
            return new System.Data.OracleClient.OracleParameter("pSalida", System.Data.OracleClient.OracleType.Cursor, 0, ParameterDirection.Output, true, 0, 0, String.Empty, DataRowVersion.Current, Convert.DBNull);                
        }
		
		/// <summary>
        /// Crea parametro de tipo CLOB utilizado para insertar u obtener campos CLOBs de algunas tablas
        /// </summary>
        /// <param name="nombreParametro">Nombre que se le asigna al par?metros</param>
        /// <param name="valor">Valor asignado al par?metro</param>
        /// <returns>Parametro creado</returns>
        public static object CrearParametroCLOB(string nombreParametro, string valor)
        {
            OracleParameter parametroNuevo;

            parametroNuevo              = new System.Data.OracleClient.OracleParameter(nombreParametro, OracleType.Clob);
            parametroNuevo.Direction    = ParameterDirection.Input;            
            parametroNuevo.IsNullable   = true;
            parametroNuevo.DbType       = DbType.AnsiString;
            
            if (valor == null || valor == string.Empty)
                parametroNuevo.Value = System.Data.OracleClient.OracleLob.Null;
            else
                parametroNuevo.Value = valor;
            
            return parametroNuevo;
        }        
	}
}