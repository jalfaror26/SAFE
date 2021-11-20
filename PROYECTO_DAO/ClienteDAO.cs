using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;

using ENTIDADES;
using System.Data;
using System.Data.Common;

namespace PROYECTO_DAO
{
    public class ClienteDAO
    {

        public Boolean Agregar(Cliente oCliente, out int plinea)
        {

            OracleParameter oParametro = new OracleParameter();
            oParametro.Direction = ParameterDirection.Output;
            oParametro.OracleType = OracleType.Number;
            oParametro.ParameterName = "linea";
            oParametro.Value = 0;


            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCLIENTE.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("cliid", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oCliente.Id;
            oCommand.Parameters.Add("tipoId", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCliente.TipoId;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oCliente.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oCliente.Telefono;
            oCommand.Parameters.Add("fax", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCliente.Fax;
            oCommand.Parameters.Add("contacto", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oCliente.Contacto;
            oCommand.Parameters.Add("correo", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oCliente.Correo;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oCliente.Ubicacion;
            oCommand.Parameters.Add("dias", OracleType.Number);
            oCommand.Parameters[8].Value = oCliente.Dias;
            oCommand.Parameters.Add("almacen", OracleType.Number);
            oCommand.Parameters[9].Value = oCliente.Almacen;
            oCommand.Parameters.Add("descAlmacen", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oCliente.DescAlmacen;
            oCommand.Parameters.Add("INDICE", OracleType.Number);
            oCommand.Parameters[11].Value = oCliente.Indice;
            oCommand.Parameters.Add("identificacion", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oCliente.Identificacion;
            oCommand.Parameters.Add("LC_moneda", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oCliente.Lc_moneda;
            oCommand.Parameters.Add("LC_limite", OracleType.Number);
            oCommand.Parameters[14].Value = oCliente.Lc_limite;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oCliente.No_cia;

            oCommand.Parameters.Add("pPAIS", OracleType.NVarChar);
            oCommand.Parameters[16].Value = "1";
            oCommand.Parameters.Add("pPROVINCIA", OracleType.NVarChar);
            oCommand.Parameters[17].Value = oCliente.Provincia;
            oCommand.Parameters.Add("pCANTON", OracleType.NVarChar);
            oCommand.Parameters[18].Value = oCliente.Canton;
            oCommand.Parameters.Add("pDISTRITO", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oCliente.Distrito;
            oCommand.Parameters.Add("pBARRIO", OracleType.NVarChar);
            oCommand.Parameters[20].Value = oCliente.Barrio;

            oCommand.Parameters.Add(oParametro);

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            plinea = int.Parse(oParametro.Value.ToString());


            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(Cliente oCliente)
        {

            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKCLIENTE.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.Add("cliid", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oCliente.Id;
            oCommand.Parameters.Add("tipoId", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCliente.TipoId;
            oCommand.Parameters.Add("nombre", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oCliente.Nombre;
            oCommand.Parameters.Add("telefono", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oCliente.Telefono;
            oCommand.Parameters.Add("fax", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oCliente.Fax;
            oCommand.Parameters.Add("contacto", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oCliente.Contacto;
            oCommand.Parameters.Add("correo", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oCliente.Correo;
            oCommand.Parameters.Add("ubicacion", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oCliente.Ubicacion;
            oCommand.Parameters.Add("dias", OracleType.Number);
            oCommand.Parameters[8].Value = oCliente.Dias;
            oCommand.Parameters.Add("almacen", OracleType.Number);
            oCommand.Parameters[9].Value = oCliente.Almacen;
            oCommand.Parameters.Add("descAlmacen", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oCliente.DescAlmacen;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[11].Value = oCliente.Indice;
            oCommand.Parameters.Add("identificacion", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oCliente.Identificacion;
            oCommand.Parameters.Add("lc_moneda", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oCliente.Lc_moneda;
            oCommand.Parameters.Add("lc_limite", OracleType.Number);
            oCommand.Parameters[14].Value = oCliente.Lc_limite;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[15].Value = oCliente.No_cia;

            oCommand.Parameters.Add("pPAIS", OracleType.NVarChar);
            oCommand.Parameters[16].Value = "1";
            oCommand.Parameters.Add("pPROVINCIA", OracleType.NVarChar);
            oCommand.Parameters[17].Value = oCliente.Provincia;
            oCommand.Parameters.Add("pCANTON", OracleType.NVarChar);
            oCommand.Parameters[18].Value = oCliente.Canton;
            oCommand.Parameters.Add("pDISTRITO", OracleType.NVarChar);
            oCommand.Parameters[19].Value = oCliente.Distrito;
            oCommand.Parameters.Add("pBARRIO", OracleType.NVarChar);
            oCommand.Parameters[20].Value = oCliente.Barrio;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(Cliente oCliente)
        {
            OracleCommand oCommand = new OracleCommand();
            oCommand.CommandText = "PCKCLIENTE.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("INDICE", OracleType.Number);
            oCommand.Parameters[0].Value = oCliente.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oCliente.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public DataSet Consultar( String pNo_cia)
        {
            String sql = "SELECT Cli_Linea, Cli_Id, Cli_Tipo_ID, Cli_Nombre, Cli_Telefono, Cli_Fax, Cli_Contacto, Cli_Correo, Cli_Ubicacion, CLI_DIAS,cli_identificacion, CLI_LC_MONEDA,CLI_LC_LIMITE, PROVINCIA, CANTON, DISTRITO, BARRIO from TBL_CLIENTES c WHERE c.no_cia = '" + pNo_cia + "' and  CLI_ESTADO = 1 and Cli_Linea > 0";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
        
        public DataSet ConsultarSaldos(String pNo_cia)
        {
            String sql = "SELECT Cli_Linea, Cli_Nombre, cli_identificacion, facp_moneda,  sum(facp_saldo) saldo from TBL_CLIENTES c, tbl_facturas_pendientes_cta f WHERE c.no_cia = '" + pNo_cia + "' and  CLI_ESTADO = 1 and Cli_Linea > 0 and f.no_cia = c.no_cia and f.facp_cliente = c.cli_linea and f.facp_estado = 1 and f.facp_estatus in ('PE', 'FT') group by Cli_Linea, Cli_Nombre, cli_identificacion,facp_moneda order by cli_identificacion, Cli_Nombre";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
        
        public DataSet consultarReporte( String pNo_cia)
        {
            String sql = "SELECT cli_linea as cod, cli_nombre as descripcion FROM TBL_CLIENTES c WHERE c.no_cia = '" + pNo_cia + "' and  cli_ESTADO = 1 and Cli_Linea > 0";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultarReporte2( String pNo_cia)
        {
            String sql = "SELECT cli_linea as cod, cli_identificacion cli_cedula, cli_nombre as descripcion FROM TBL_CLIENTES c WHERE c.no_cia = '"+ pNo_cia + "' and  cli_ESTADO = 1 and Cli_Linea > 0";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT Cli_Linea, Cli_Id, Cli_Tipo_ID, Cli_Nombre, Cli_Telefono, Cli_Fax, Cli_Contacto, Cli_Correo, Cli_Ubicacion, CLI_DIAS,cli_identificacion, CLI_LC_MONEDA,CLI_LC_LIMITE, PROVINCIA, CANTON, DISTRITO, BARRIO FROM TBL_CLIENTES c WHERE c.no_cia = '" + pNo_cia + "' and  CLI_ESTADO = 1 and ";
            if (tipo == 1)
                sql += " regexp_like(cli_identificacion,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(Cli_Nombre,'" + palabra + "','i')";
            sql += " and Cli_Linea > 0";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarSaldos(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT Cli_Linea, Cli_Nombre, cli_identificacion, facp_moneda,  sum(facp_saldo) saldo FROM  TBL_CLIENTES c, tbl_facturas_pendientes_cta f WHERE c.no_cia = '" + pNo_cia + "' and  CLI_ESTADO = 1 and Cli_Linea > 0 and f.no_cia = c.no_cia and f.facp_cliente = c.cli_linea and f.facp_estado = 1 and f.facp_estatus in ('PE', 'FT') and ";
            if (tipo == 1)
                sql += " regexp_like(cli_identificacion,'" + palabra + "','i')";
            if (tipo == 2)
                sql += " regexp_like(Cli_Nombre,'" + palabra + "','i')";
            sql += " group by Cli_Linea, Cli_Nombre, cli_identificacion, facp_moneda order by cli_identificacion, Cli_Nombre";
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

        public DataSet Listar_Filtrado(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT cli_linea as cod, cli_nombre as descripcion FROM TBL_CLIENTES c WHERE c.no_cia = '"+ pNo_cia + "' and  cli_ESTADO = 1 and Cli_Linea > 0 and ";
            if (tipo == 1)
                sql += " regexp_like(CLi_linea,'" + palabra + "','i') order by CLi_linea";
            if (tipo == 2)
                sql += " regexp_like(cli_nombre,'" + palabra + "','i') order by CLi_linea";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar_Filtrado2(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT cli_linea as cod, CLI_IDENTIFICACION cli_cedula, cli_nombre as descripcion FROM TBL_CLIENTES c WHERE c.no_cia = '"+ pNo_cia + "' and  cli_ESTADO = 1 and Cli_Linea > 0 and ";
            if (tipo == 1)
                sql += " regexp_like(CLi_linea,'" + palabra + "','i') order by CLi_linea";
            if (tipo == 2)
                sql += " regexp_like(cli_nombre,'" + palabra + "','i') order by CLi_linea";
            if (tipo == 3)
                sql += " regexp_like(CLI_IDENTIFICACION,'" + palabra + "','i') order by CLi_linea";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet Listar3(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT cli_linea as cod, cli_nombre as descripcion FROM TBL_CLIENTES c WHERE c.no_cia = '"+ pNo_cia + "' and  cli_ESTADO = 1 and Cli_Linea > 0 and ";
            if (tipo == 1)
                sql += " regexp_like(CLi_linea,'" + palabra + "','i') or cli_id='PE' order by CLi_linea";
            if (tipo == 2)
                sql += " regexp_like(cli_nombre,'" + palabra + "','i') or cli_id='PE' order by CLi_linea";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet ListarReporte(int tipo, String palabra, String pNo_cia)
        {
            String sql = "SELECT cli_linea as cod, cli_nombre as descripcion from TBL_CLIENTES c WHERE c.no_cia = '"+ pNo_cia + "' and  cli_ESTADO = 1 and Cli_Linea > 0 and ";
            if (tipo == 1)
                sql += " regexp_like(CLi_linea,'" + palabra + "','i') order by CLi_linea";
            if (tipo == 2)
                sql += " regexp_like(cli_nombre,'" + palabra + "','i') order by CLi_linea";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public string Codigo(string p, String pNo_cia)
        {
            String sql = "SELECT cli_identificacion from TBL_CLIENTES c WHERE c.no_cia = '"+ pNo_cia + "' and  cli_linea = '" + p + "'";

            string oDataSet = OracleDAO.getInstance().EjecutarSQLScalarString(sql);
            return oDataSet;
        }

        public DataSet FacturasxCliente(String pNo_cia, String pCliente)
        {
            String sql = "select f.facp_cliente, f.facp_numero_factura, trunc(f.facp_fecha_factura) facp_fecha_factura, trunc(f.facp_fecha_vence) facp_fecha_vence, f.facp_moneda, f.facp_monto, f.facp_saldo from TBL_FACTURAS_PENDIENTES_CTA f WHERE f.no_cia = '" + pNo_cia + "' and f.facp_cliente = '" + pCliente + "' and f.facp_estado = 1 and f.facp_estatus in ('PE', 'FT') order by facp_fecha_factura, facp_numero_factura ";
           
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet DetalleFacturasxCliente(String pNo_cia, String pCliente, String pFactura)
        {
            String sql = "select detfac_cantidad, (SELECT case when ARPRE_EMBALAJE = 'talla' then ARPRE_CANTIDAD || ' ' || ARPRE_EMBALAJE else ARPRE_EMBALAJE end FROM TBL_ARTICULO_PRESENTACION ap WHERE ap.no_cia = '" + pNo_cia + "' and DETFAC_PRESENTACION = ARPRE_INDICE) ARPRE_EMBALAJE, detfac_descripcion, DETFAC_PRECIO_TOTAL detfac_total from tbl_factura f, tbl_factura_detalle fd, tbl_servicios ar where f.no_cia = '" + pNo_cia + "' and f.fac_numero = '" + pFactura + "' and f.Fac_Cliente = '" + pCliente + "' and f.no_cia = fd.no_cia and f.fac_linea = fd.detfac_indicefactura and f.no_cia = ar.no_cia and SER_INDICE = detfac_codigo ORDER BY detfac_numerolinea desc ";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
    }
}
