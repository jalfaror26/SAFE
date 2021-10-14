using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

namespace PROYECTO_DAO
{

    /// <summary>
    /// Controlar y Manipular la Conexión y Sentencias SQL 
    /// con una Base de Datos Oracle 8i/9i/10g
    /// </summary> 
    public class OracleDAO : BaseDAO
    {

        #region Propiedades Privadas para un motor de Base de Datos Oracle

        /// <summary>
        /// objeto de Instancia de Conexión para un Oracle 8i/9i/10g
        /// </summary>
        private OracleConnection oConexion;

        /// <summary>
        /// Código de Usuario para la conexión hacia la base de datos
        /// </summary>
        private static String codigoUsuario = "";

        /// <summary>
        /// Contraseña del Usuario para la conexión hacia la base de datos
        /// </summary>
        private static String claveUsuario = "";

        /// <summary>
        /// Nombre del servidor de Base de datos
        /// </summary>
        private static String servidorBaseDatos = "";

        /// <summary>
        /// Variable de Instancia para implementar el Singlenton 
        /// para la conexión con la Base de Datos Oracle 8i/9i/10g
        /// </summary>
        private static OracleDAO Instance = null;

        #endregion

        #region Contructores y Destructores

        /// <summary>
        /// Crear un objeto OracleDAO para un servidor de Base de Datos Oracle 8i/9i/10g
        /// Implementa instancia única - Patrón Singlenton
        /// </summary>
        /// <param name="pServidorBD">Nombre del Servidor de Base de Datos</param>
        /// <param name="pUsuario">Código de Usuario de Conexión</param>
        /// <param name="pClaveUsuario">Clave del Usuario</param>
        private OracleDAO(String pServidorBD,
                           String pUsuario,
                           String pClaveUsuario)
        {

            codigoUsuario = pUsuario;
            claveUsuario = pClaveUsuario;
            servidorBaseDatos = pServidorBD;
        }//OracleDAO con argumentos

        //private OracleDAO()
        //{
        //    codigoUsuario = "";
        //    claveUsuario = "";
        //    servidorBaseDatos = "";
        //}//OracleDAO sin argumentos

        /// <summary>
        /// Destructor del objeto OracleDAO
        /// </summary>
        ~OracleDAO()
        {

            try
            {
                ErrorSQL = false;
                oConexion.Close();
            }

            catch (OracleException errorConexion)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error al cerrar la conexión con la Base de Datos:\n\n";
                DescripcionErrorSQL += errorConexion.Message;
            }

            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error al cerrar la conexión con la Base de Datos:\n\n";
                DescripcionErrorSQL += Error.Message;
            }
        }//~OracleDAO

        /// <summary>
        /// Leer la instanca del objeto OracleDAO - Patrón Singlenton
        /// </summary>
        /// <param name="pUsuario">Código del usuario</param>
        /// <param name="pClaveUsuario">Clave o contraseña del usuario</param>
        /// <param name="pServidorBaseDatos">Servidor de instancia de Base de Datos</param>
        public static OracleDAO getInstance(String pServidorBaseDatos,
                                             String pUsuario,
                                             String pClaveUsuario)
        {
            //Verificar si la instancia no ha sido credada
            if (Instance == null)
            {
                Instance = new OracleDAO(pServidorBaseDatos,
                                          pUsuario,
                                          pClaveUsuario);
            }
            return Instance;
        }

        public void QuitarInstance()
        {
            Instance = null;
        }

        /// <summary>
        /// Leer la instanca del objeto OracleDAO - Patrón Singlenton
        /// </summary>
        /// <returns></returns>
        public static OracleDAO getInstance()
        {
            //Verificar si la instancia no ha sido credada
            if (Instance == null)
            {
                Instance = new OracleDAO(servidorBaseDatos,
                                         codigoUsuario,
                                         claveUsuario);
            }
            return Instance;
        }

        #endregion

        #region Set's and Get's

        /// <summary>
        /// Código de Usuario para la conexión con la Base de Datos
        /// </summary>
        public String CodigoUsuario
        {
            get { return codigoUsuario; }
            set { codigoUsuario = value; }
        }

        /// <summary>
        /// Clave del Usuario para la conexión con la Base de Datos
        /// </summary>
        public String ClaveUsuario
        {
            get { return claveUsuario; }
            set { claveUsuario = value; }
        }

        /// <summary>
        /// Nombre del Servidor de Base de Datos
        /// </summary>
        public String ServidorBaseDatos
        {
            get { return servidorBaseDatos; }
            set { servidorBaseDatos = value; }
        }

        #endregion

        #region Sobrescritura de contratos con la clase base - BaseDAO

        /// <summary>
        /// Establecer la conexión con la Base de Datos Oracle 8i/9i/10g
        /// </summary>
        /// <returns>True: Si la conexión es exitosa con la Base de Datos
        /// False: Si la conexión no es exitosa con la Base de Datos</returns>
        public override Boolean AbrirConexion()
        {

            //Definir objeto SqlConnectionStringBuilder para el String de conexión
            OracleConnectionStringBuilder oAyudante = new OracleConnectionStringBuilder();

            //Variable del Resultado de abrir la conexión con la Base de Datos
            Boolean vResultado = false;

            ErrorSQL = false;

            //Asignar los valores para el string de conexión
            oAyudante.UserID = codigoUsuario;
            oAyudante.Password = claveUsuario;
            oAyudante.DataSource = servidorBaseDatos;

            // Verificar si el objeto ya está conectado
            if (Instance.oConexion != null)
            {
                if (Instance.EstadoConexion())
                {
                    ErrorSQL = true;
                    DescripcionErrorSQL = "Ya hay una conexión Activa con un Servidor de Base de Datos Oracle 8i/9i/10g";
                    return false;
                }
            }
            //Definir lo parámetros de la conexión
            oConexion = new OracleConnection(oAyudante.ToString());

            try
            {
                //Abrir la conexión con la base de datos
                oConexion.Close();
                oConexion.Open();
                vResultado = true;
            }

            catch (OracleException errorConexion)
            {

                ErrorSQL = true;
                DescripcionErrorSQL = "Error al conectarse con la Base de Datos Oracle 8i/9i/10g:\n";
                DescripcionErrorSQL += errorConexion.Message;
            }
            catch (Exception Error)
            {

                ErrorSQL = true;
                DescripcionErrorSQL = "Error al conectarse con la Base de Datos Oracle 8i/9i/10g:\n";
                DescripcionErrorSQL += Error.Message;
            }

            oAyudante = null;

            //Retornar el resultado de Abrir la conexión
            return vResultado;

        }//override AbrirConexion


        public Boolean CerrarConexion()
        {

            try
            {
                ErrorSQL = false;

                if (Instance.oConexion != null)
                {
                    if (Instance.EstadoConexion())
                    {
                        oConexion.Close();
                        oConexion = null;
                    }
                }
                //     Instance = null;

            }

            catch (OracleException errorConexion)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error al cerrar la conexión con la Base de Datos:\n\n";
                DescripcionErrorSQL += errorConexion.Message;
            }

            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error al cerrar la conexión con la Base de Datos:\n\n";
                DescripcionErrorSQL += Error.Message;
            }
            return ErrorSQL;
        }

        /// <summary>
        /// Indica el estado de la persistencia
        /// </summary>
        /// <returns>True si el estado está correcto</returns>
        public override Boolean EstadoConexion()
        {
            String mensaje = "";

            //switch del Estado de la Conexión con la Base de Datos
            switch (oConexion.State)
            {
                case ConnectionState.Broken:
                    mensaje = "Conexión Quebrada";
                    break;
                case ConnectionState.Closed:
                    mensaje = "Conexión Cerrada";
                    break;
                case ConnectionState.Connecting:
                    mensaje = "Conectandose";
                    break;
                case ConnectionState.Executing:
                    mensaje = "Ejecutando sentencia SQL";
                    break;
                case ConnectionState.Fetching:
                    mensaje = "Extrayendo tuplas";
                    break;
                case ConnectionState.Open:
                    mensaje = "Conexión Abierta";
                    break;
            }
            //Cambiar la descripción del Estado de la Conexión con la base de datos
            DescripcionEstadoConexion = mensaje;

            if ((oConexion.State == ConnectionState.Open) ||
                  (oConexion.State == ConnectionState.Executing) ||
                  (oConexion.State == ConnectionState.Fetching))
                return true;
            else
                return false;
        }//EstadoConexion

        #region EjecutarSQL

        /// <summary>
        /// Ejecutar sentencias SQL tipo: INSERT, UPDATE, DELETE hacia la instancia 
        /// de la Base de Datos Oracle 8i/9i/10g
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Cantidad de Registros afectas en la sentencia SQL</returns>
        public override Int32 EjecutarSQL(string pSql)
        {

            //Declaración de variable para cantidad de registros afectados
            Int32 vRegistrosAfectados = 0;

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Ejecutar la sentencia SQL y obtener la 
                //cantidad de registros afectados en la sentencia SQL
                vRegistrosAfectados = oCommand.ExecuteNonQuery();

            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQL:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQL:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar la cantidad de registros afectados
            return vRegistrosAfectados;
        }

        /// <summary>
        /// Ejecutar sentencias SQL tipo: INSERT, UPDATE, DELETE hacia la instancia
        /// de la Base de Datos concreta
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar o sub Tipo del mismo</param>
        /// <returns>Cantidad de Registros afectas en la sentencia SQL</returns>
        public override Int32 EjecutarSQL(DbCommand oCommand)
        {
            //Declaración de variable para cantidad de registros afectados
            Int32 vRegistrosAfectados = 0;

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Ejecutar la sentencia SQL y obtener la 
                //cantidad de registros afectados en la sentencia SQL
                vRegistrosAfectados = oCommand.ExecuteNonQuery();

            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQL:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQL:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar la cantidad de registros afectados
            return vRegistrosAfectados;
        }

        #endregion EjecutarSQL

        #region EjecutarOracleDataReader

        /// <summary>
        /// Ejecutar Sentencias SELECT y devolver resultado en un objeto 
        /// DbDataReader o SubTipo del mismo
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Resultado del Select en un objeto DbDataReader o sub tipo de la clase</returns>
        public override DbDataReader EjecutarSQLDataReader(String pSql)
        {

            //Creación del nuevo objeto OracleDataReader especifico para un Oracle 8i/9i/10g
            //Por el principio de sustitución de Liskov un OracleDataReader hereda del DbDataReader
            OracleDataReader oOracleDataReader = null;

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text; ;

                //Asignar el objeto OracleDataReader el resultado de ejecutar
                //la sentencia SQL del objeto Command
                oOracleDataReader = oCommand.ExecuteReader();
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarOracleDataReader:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarOracleDataReader:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el objeto OracleDataReader
            return oOracleDataReader;
        }

        /// <summary>
        /// Ejecutar Sentencias SELECT y devolver resultado en un objeto 
        /// DbDataReader o SubTipo del mismo
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar o sub Tipo del mismo</param>
        /// <returns>Resultado del Select en un objeto DbDataReader o sub tipo de la clase</returns>
        public override DbDataReader EjecutarSQLDataReader(DbCommand oCommand)
        {

            //Creación del nuevo objeto OracleDataReader especifico para un Oracle 8i/9i/10g
            //Por el principio de sustitución de Liskov un OracleDataReader hereda del DbDataReader
            OracleDataReader oOracleDataReader = null;

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Asignar el objeto OracleDataReader el resultado de ejecutar
                //la sentencia SQL del objeto Command
                //
                //Nota:
                //     Por el principio de sustitución de Liskov se hace el respectivo
                //     casting del objeto OracleDataReader
                oOracleDataReader = (OracleDataReader)oCommand.ExecuteReader();
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarOracleDataReader:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarOracleDataReader:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el objeto OracleDataReader
            return oOracleDataReader;
        }

        #endregion EjecutarOracleDataReader

        #region EjecutarSQLDataTable

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable        
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Resultado del Select</returns>
        public override DataTable EjecutarSQLDataTable(String pSql)
        {

            //Creación del nuevo objeto DataAdapter y DataTable
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();
            DataTable oDataTable = new DataTable();

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                oOracleDataAdapter.SelectCommand = oCommand;
                oOracleDataAdapter.Fill(oDataTable);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el objeto DataTable
            return oDataTable;
        }

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable 
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar o sub Tipo del mismo</param>
        /// <returns>Resultado del Select</returns>
        public override DataTable EjecutarSQLDataTable(DbCommand oCommand)
        {

            //Creación del nuevo objeto DataAdapter y DataTable
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();
            DataTable oDataTable = new DataTable();

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                //
                //Nota:
                //     Por el principio de sustitución de Liskov se hace el respectivo
                //     casting del objeto OracleDataReader
                oOracleDataAdapter.SelectCommand = (OracleCommand)oCommand;
                oOracleDataAdapter.Fill(oDataTable);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el objeto DataTable
            return oDataTable;
        }
        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <param name="oDataTable">Objeto DataTable por referencia a cargar con el resultado del Select</param>
        public override void EjecutarSQLDataTable(string pSql, DataTable oDataTable)
        {

            //Creación del nuevo objeto DataAdapter
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                oOracleDataAdapter.SelectCommand = oCommand;
                oOracleDataAdapter.Fill(oDataTable);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += Error.Message;
            }
        }

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataTable
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar o sub Tipo del mismo</param>
        /// <param name="oDataTable">Objeto DataTable por referencia a cargar con el resultado del Select</param>
        public override void EjecutarSQLDataTable(DbCommand oCommand, DataTable oDataTable)
        {
            //Creación del nuevo objeto DataAdapter
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                //
                //Nota:
                //     Por el principio de sustitución de Liskov se hace el respectivo
                //     casting del objeto OracleDataReader
                oOracleDataAdapter.SelectCommand = (OracleCommand)oCommand;
                oOracleDataAdapter.Fill(oDataTable);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataTable:\n";
                DescripcionErrorSQL += Error.Message;
            }
        }

        #endregion EjecutarSQLDataTable

        #region EjecutarSQLDataSet

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <returns>Resultado del Select</returns>
        public override DataSet EjecutarSQLDataSet(String pSql)
        {

            //Creación del nuevo objeto DataAdapter y DataTable
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();
            DataSet oDataSet = new DataSet();

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                oOracleDataAdapter.SelectCommand = oCommand;
                oOracleDataAdapter.Fill(oDataSet);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el objeto DataSet
            return oDataSet;
        }

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar o sub Tipo del mismo</param>
        /// <returns>Resultado del Select</returns>
        public override DataSet EjecutarSQLDataSet(DbCommand oCommand)
        {
            //Creación del nuevo objeto DataAdapter y DataTable
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();
            DataSet oDataSet = new DataSet();

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                //
                //Nota:
                //     Por el principio de sustitución de Liskov se hace el respectivo
                //     casting del objeto OracleDataReader
                oOracleDataAdapter.SelectCommand = (OracleCommand)oCommand;
                oOracleDataAdapter.Fill(oDataSet);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el objeto DataSet
            return oDataSet;
        }

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="pSql">String SQL a ejecutar</param>
        /// <param name="oDataSet">Objeto DataSet a cargar con el resultado del select</param>
        /// <param name="pNombreTabla">Nombre de la Tabla a Cargar en el DataSet, si no se especifica no carga los datos al objeto DataSet</param>
        /// <returns>Resultado del Select</returns>
        public override void EjecutarSQLDataSet(String pSql, DataSet pDataSet, String pNombreTabla)
        {

            //Creación del nuevo objeto DataAdapter y DataTable
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                oOracleDataAdapter.SelectCommand = oCommand;
                oOracleDataAdapter.Fill(pDataSet, pNombreTabla);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += Error.Message;
            }
        }

        /// <summary>
        /// Ejecutar sentencias SELECT y devolver el resultado en un objeto DataSet
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con sentencia SQL a ejecutar o sub Tipo del mismo</param>
        /// <param name="oDataSet">Objeto DataSet a cargar con el resultado del select</param>
        /// <param name="pNombreTabla">Nombre de la Tabla a Cargar en el DataSet, si no se especifica no carga los datos al objeto DataSet</param>
        public override void EjecutarSQLDataSet(DbCommand oCommand, DataSet oDataSet, string pNombreTabla)
        {
            //Creación del nuevo objeto DataAdapter y DataTable
            OracleDataAdapter oOracleDataAdapter = new OracleDataAdapter();

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Asignar el objeto OracleDataAdapter el objeto command y 
                //Mandar a ejecutar la sentencia dentro del objeto OracleDataAdapter
                //
                //Nota:
                //     Por el principio de sustitución de Liskov se hace el respectivo
                //     casting del objeto OracleDataReader
                oOracleDataAdapter.SelectCommand = (OracleCommand)oCommand;
                oOracleDataAdapter.Fill(oDataSet, pNombreTabla);
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLDataSet:\n";
                DescripcionErrorSQL += Error.Message;
            }
        }

        #endregion EjecutarSQLDataSet

        #region EjecutarSQLStoreProcedure

        /// <summary>
        /// Ejecutar un Procedimiento Almacenado de Base de Datos
        /// </summary>
        /// <param name="oCommand">Objeto DbCommand con el StoreProcedure a Ejecutar</param>
        public override void EjecutarSQLStoreProcedure(DbCommand oCommand)
        {

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión y tipo de OracleCommand
                oCommand.Connection = oConexion;
                oCommand.CommandType = CommandType.StoredProcedure;

                //Ejecutar la sentencia
                oCommand.ExecuteNonQuery();
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLStoreProcedure:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLStoreProcedure:\n";
                DescripcionErrorSQL += Error.Message;
            }
        }

        public override void EjecutarSQLComando(String pSql)
        {

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión y tipo de OracleCommand
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Ejecutar la sentencia
                oCommand.ExecuteNonQuery();
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLComando:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLComando:\n";
                DescripcionErrorSQL += Error.Message;
            }
        }

        #endregion EjecutarSQLStoreProcedure

        #region EjecutarSQLScalar y TraerFechaHoraBaseDatos

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX, etc
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="pSql">String SQL a Ejecutar</param>
        /// <returns>Resultado del SqlScalar</returns>
        public override String EjecutarSQLScalarString(String pSql)
        {

            //Declaración de variable para resultado del SqlScalar            
            String vResultadoScalar = "";

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Ejecutar el SQL Escalar y retornar el valor 
                vResultadoScalar = oCommand.ExecuteScalar().ToString();
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el resultado del SqlScalar
            return vResultadoScalar;
        }

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX, etc
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="pSql">String SQL a Ejecutar</param>
        /// <returns>Resultado DateTime del SqlScalar</returns>
        public override DateTime EjecutarSQLScalarDateTime(String pSql)
        {

            //Declaración de variable para resultado del SqlScalar            
            DateTime vResultadoScalar = new DateTime();

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Ejecutar el SQL Escalar y retornar el valor 
                vResultadoScalar = Convert.ToDateTime(oCommand.ExecuteScalar());
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el resultado del SqlScalar
            return vResultadoScalar;
        }

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX, etc
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="pSql">String SQL a Ejecutar</param>
        /// <returns>Resultado Double del SqlScalar</returns>
        public override Double EjecutarSQLScalarDouble(String pSql)
        {

            //Declaración de variable para resultado del SqlScalar            
            Double vResultadoScalar = 0;

            try
            {
                ErrorSQL = false;

                // Creación del nuevo objeto tipo Command
                OracleCommand oCommand = new OracleCommand();

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;
                oCommand.CommandText = pSql;
                oCommand.CommandType = CommandType.Text;

                //Ejecutar el SQL Escalar y retornar el valor 
                vResultadoScalar = Convert.ToDouble(oCommand.ExecuteScalar());
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el resultado del SqlScalar
            return vResultadoScalar;
        }

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX, etc
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="oCommand">Objeto DBCommand con el SQL a Ejecutar</param>
        /// <returns>Resultado del SqlScalar</returns>
        public override String EjecutarSQLScalarString(DbCommand oCommand)
        {

            //Declaración de variable para resultado del SqlScalar            
            String vResultadoScalar = "";

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Ejecutar el SQL Escalar y retornar el valor 
                vResultadoScalar = oCommand.ExecuteScalar().ToString();
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el resultado del SqlScalar
            return vResultadoScalar;
        }

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX, etc
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="oCommand">Objeto DBCommand con el SQL a Ejecutar</param>
        /// <returns>Resultado DateTime del SqlScalar</returns>
        public override DateTime EjecutarSQLScalarDateTime(DbCommand oCommand)
        {

            //Declaración de variable para resultado del SqlScalar            
            DateTime vResultadoScalar = new DateTime();

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión
                oCommand.Connection = oConexion;

                //Ejecutar el SQL Escalar y retornar el valor 
                vResultadoScalar = Convert.ToDateTime(oCommand.ExecuteScalar());
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el resultado del SqlScalar
            return vResultadoScalar;
        }

        /// <summary>
        /// Ejecutar sentencias SQL Escalares --> SUM, AVG, MIN, MAX, etc
        /// O consultas SQL que retornen un solo campo
        /// </summary>
        /// <param name="oCommand">Objeto DBCommand con el SQL a Ejecutar</param>
        /// <returns>Resultado Double del SqlScalar</returns>
        public override Double EjecutarSQLScalarDouble(DbCommand oCommand)
        {

            //Declaración de variable para resultado del SqlScalar            
            Double vResultadoScalar = 0.00;

            try
            {
                ErrorSQL = false;

                //Asignación del objeto conexión, String SQL y tipo Command
                oCommand.Connection = oConexion;

                //Ejecutar el SQL Escalar y retornar el valor 
                vResultadoScalar = Convert.ToDouble(oCommand.ExecuteScalar());
            }
            catch (OracleException errorSQL)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += errorSQL.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en EjecutarSQLScalar:\n";
                DescripcionErrorSQL += Error.Message;
            }

            //Retornar el resultado del SqlScalar
            return vResultadoScalar;
        }

        /// <summary>
        /// Leer la fecha y hora del servidor de Base de Datos
        /// </summary>
        /// <returns>Fecha Hora del servidor de Base de Datos</returns>
        public override DateTime TraerFechaHoraBaseDatos()
        {

            //Declaración de Variables locales
            DateTime oFecha = DateTime.Now;
            OracleCommand oCommand = new OracleCommand();

            try
            {
                oCommand.Connection = oConexion;
                oCommand.CommandText = "select GetDate()";
                oCommand.CommandType = CommandType.Text;

                ErrorSQL = false;
                oFecha = (DateTime)oCommand.ExecuteScalar();
            }

            catch (OracleException errorSql)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error de SQL en TraerFechaHoraBaseDatos:\n";
                DescripcionErrorSQL += errorSql.Message;
            }
            catch (Exception Error)
            {
                ErrorSQL = true;
                DescripcionErrorSQL = "Error General en TraerFechaHoraBaseDatos:\n";
                DescripcionErrorSQL += Error.Message;
            }

            return oFecha;
        }

        #endregion EjecutarSQLScalar y TraerFechaHoraBaseDatos

        #endregion
    }
}
