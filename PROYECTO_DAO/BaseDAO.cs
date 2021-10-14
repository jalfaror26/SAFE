using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace PROYECTO_DAO
{

    /// <summary>
    /// Clase Base DAO para cualquier implementación de un
    /// Motor de Base de Datos Relacional. Se establecen todas
    /// las generalidades y métodos que todo Motor de Base de Datos
    /// debe implementar en la clases concretas
    /// </summary>
    public abstract class BaseDAO
    {

        #region Propiedades privadas comunes para cualquier motor de Base de Datos relacional

        /// <summary>
        /// Indicador si en la última sentencia SQL hacia
        /// la instancia de la Base de Datos ocurrió un Error
        /// </summary>
        private Boolean errorSQL = false;

        /// <summary>
        /// Descripción del Error de la última sentencia SQL ejecutada
        /// hacia la instancia de la Base de Datos
        /// </summary>
        private String descripcionErrorSQL;

        /// <summary>
        /// Descripción del estado actual con la conexión hacia la
        /// instancia de la Base de Datos
        /// </summary>        
        private String descripcionEstadoConexion;

        #endregion

        #region Set's and Get's públicos comunes para cualquier implementación de un motor de Base de Datos relacional

        /// <summary>
        /// Indicador si en la última sentencia SQL hacia
        /// la instancia de la Base de Datos ocurrió un Error
        /// </summary>
        public Boolean ErrorSQL
        {
            get { return errorSQL; }
            set { errorSQL = value; }
        }

        /// <summary>
        /// Descripción del Error de la última sentencia SQL ejecutada
        /// hacia la instancia de la Base de Datos
        /// </summary>
        public String DescripcionErrorSQL
        {
            get { return descripcionErrorSQL; }
            set { descripcionErrorSQL = value; }
        }

        /// <summary>
        /// Descripción del estado actual con la conexión hacia la
        /// instancia de la Base de Datos
        /// </summary>
        public String DescripcionEstadoConexion
        {
            get { return descripcionEstadoConexion; }
            set { descripcionEstadoConexion = value; }
        }

        #endregion

        #region Contratos que clases concretas hijas deben implementar

        /// <summary>
        /// Establecer la conexión con el motor de Base de Datos concreto
        /// </summary>
        /// <returns>True: Si la conexión con la Base de Datos es exitosa
        /// False: Si NO se puede establecer la conexión conexión con la Base de Datos</returns>
        public abstract Boolean AbrirConexion();

        /// <summary>
        /// Obtener el estado de la conexión con la Base de Datos concreta
        /// </summary>
        /// <returns></returns>
        public abstract Boolean EstadoConexion();

        #region EjecutarSQL

        /// <summary>
        /// Ejecutar sentencias SQL tipo: INSERT, UPDATE, DELETE hacia la instancia
        /// de la Base de Datos concreta
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Cantidad de Registros afectas en la sentencia SQL</returns>
        public abstract Int32 EjecutarSQL(String pSql);

        /// <summary>
        /// Ejecutar sentencias SQL tipo: INSERT, UPDATE, DELETE hacia la instancia
        /// de la Base de Datos concreta
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar, la clase hija debe sobreescribir al DbCommand de acuerdo al tipo especifico del motor de Base de Datos</param>
        /// <returns>Cantidad de Registros afectas en la sentencia SQL</returns>
        public abstract Int32 EjecutarSQL(DbCommand oCommand);

        #endregion EjecutarSQL

        #region EjecutarSQLDataReader

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver resultado en un objeto 
        /// DbDataReader o SubTipo del mismo
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Resultado del Select en un objeto DbDataReader o sub tipo de la clase</returns>
        public abstract DbDataReader EjecutarSQLDataReader(String pSql);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver resultado en un objeto 
        /// DbDataReader o SubTipo del mismo
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar, la clase hija debe sobreescribir al DbCommand de acuerdo al tipo especifico del motor de Base de Datos</param>
        /// <returns></returns>
        public abstract DbDataReader EjecutarSQLDataReader(DbCommand oCommand);

        #endregion EjecutarSQLDataReader

        #region EjecutarSQLDataTable

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Resultado del Select</returns>
        public abstract DataTable EjecutarSQLDataTable(String pSql);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar, la clase hija debe sobreescribir al DbCommand de acuerdo al tipo especifico del motor de Base de Datos</param>
        /// <returns>Resultado del Select</returns>
        public abstract DataTable EjecutarSQLDataTable(DbCommand oCommand);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <param name="oDataTable">Objeto DataTable por referencia a cargar con el resultado del Select</param>
        public abstract void EjecutarSQLDataTable(String pSql, DataTable oDataTable);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable
        /// </summary>        
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar, la clase hija debe sobreescribir al DbCommand de acuerdo al tipo especifico del motor de Base de Datos</param>
        /// <param name="oDataTable">Objeto DataTable por referencia a cargar con el resultado del Select</param>
        public abstract void EjecutarSQLDataTable(DbCommand oCommand, DataTable oDataTable);

        #endregion EjecutarSQLDataTable

        #region EjecutarSQLDataSet

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Resultado del Select</returns>
        public abstract DataSet EjecutarSQLDataSet(String pSql);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar, la clase hija debe sobreescribir al DbCommand de acuerdo al tipo especifico del motor de Base de Datos</param>
        /// <returns>Resultado del Select</returns>
        public abstract DataSet EjecutarSQLDataSet(DbCommand oCommand);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <param name="oDataSet">Objeto DataSet a cargar con el resultado del select</param>
        /// <param name="pNombreTabla">Nombre de la Tabla a Cargar en el DataSet, si no se especifica no carga los datos al objeto DataSet</param>
        /// <returns>Resultado del Select</returns>
        public abstract void EjecutarSQLDataSet(String pSql, DataSet oDataSet, String pNombreTabla);

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar, la clase hija debe sobreescribir al DbCommand de acuerdo al tipo especifico del motor de Base de Datos</param>
        /// <param name="oDataSet">Objeto DataSet a cargar con el resultado del select</param>
        /// <param name="pNombreTabla">Nombre de la Tabla a Cargar en el DataSet, si no se especifica no carga los datos al objeto DataSet</param>
        public abstract void EjecutarSQLDataSet(DbCommand oCommand, DataSet oDataSet, String pNombreTabla);

        #endregion EjecutarSQLDataSet

        #region EjecutarSQLStoreProcedure

        /// <summary>
        /// Ejecutar un Procedimiento Almacenado de Base de Datos
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con el StoreProcedure a Ejecutar</param>
        public abstract void EjecutarSQLStoreProcedure(DbCommand oCommand);

        #endregion EjecutarSQLStoreProcedure

        #region EjecutarSQLScalar y TraerFechaHoraBaseDatos

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX,
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="pSql">String SQL a Ejecutar</param>
        /// <returns>Resultado String del SqlScalar</returns>
        public abstract String EjecutarSQLScalarString(String pSql);

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX,
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="pSql">String SQL a Ejecutar</param>
        /// <returns>Resultado DateTime del SqlScalar</returns>
        public abstract DateTime EjecutarSQLScalarDateTime(String pSql);

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX,
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="pSql">String SQL a Ejecutar</param>
        /// <returns>Resultado Double del SqlScalar</returns>
        public abstract Double EjecutarSQLScalarDouble(String pSql);
        
        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX,
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="oCommand">Objeto DBCommand con el SQL a Ejecutar</param>
        /// <returns>Resultado String del SqlScalar</returns>
        public abstract String EjecutarSQLScalarString(DbCommand oCommand);

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX,
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="oCommand">Objeto DBCommand con el SQL a Ejecutar</param>
        /// <returns>Resultado DateTime del SqlScalar</returns>
        public abstract DateTime EjecutarSQLScalarDateTime(DbCommand oCommand);

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX,
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="oCommand">Objeto DBCommand con el SQL a Ejecutar</param>
        /// <returns>Resultado Double del SqlScalar</returns>
        public abstract Double EjecutarSQLScalarDouble(DbCommand oCommand);
        
        /// <summary>
        /// Leer la fecha y hora del servidor de Base de Datos
        /// </summary>
        /// <returns>Fecha Hora del servidor de Base de Datos</returns>
        public abstract DateTime TraerFechaHoraBaseDatos();

        #endregion
        public abstract void EjecutarSQLComando(String pSql);
        

        #endregion
    }
}
