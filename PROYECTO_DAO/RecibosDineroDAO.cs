using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

using ENTIDADES;

namespace PROYECTO_DAO
{
    public class RecibosDineroDAO
    {

        public Boolean Agregar(ReciboDinero oRecibo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECIBODINERO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("cliente", OracleType.Number);
            oCommand.Parameters[0].Value = oRecibo.Cliente;
            oCommand.Parameters.Add("numRecibo", OracleType.Number);
            oCommand.Parameters[1].Value = oRecibo.Numero;
            oCommand.Parameters.Add("formaPago", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oRecibo.FormaPago;
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oRecibo.Moneda;
            oCommand.Parameters.Add("tipoCambio", OracleType.Number);
            oCommand.Parameters[4].Value = oRecibo.TipoCambio;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[5].Value = oRecibo.Monto;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[6].Value = oRecibo.Saldo;
            oCommand.Parameters.Add("fechaDoc", OracleType.DateTime);
            oCommand.Parameters[7].Value = oRecibo.FechaDoc;
            oCommand.Parameters.Add("estatus", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oRecibo.Estatus;
            oCommand.Parameters.Add("tipodoc", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oRecibo.Tipodoc;
            oCommand.Parameters.Add("detalle", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oRecibo.Detalle;
            oCommand.Parameters.Add("fechaRegistro", OracleType.DateTime);
            oCommand.Parameters[11].Value = oRecibo.FechaRegistro;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oRecibo.Usuario;
            oCommand.Parameters.Add("tipoIngreso", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oRecibo.TipoIngreso;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[14].Value = oRecibo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean AgregarSinLibro(ReciboDinero oRecibo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECIBODINERO.paInsertar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("cliente", OracleType.Number);
            oCommand.Parameters[0].Value = oRecibo.Cliente;
            oCommand.Parameters.Add("numRecibo", OracleType.Number);
            oCommand.Parameters[1].Value = oRecibo.Numero;
            oCommand.Parameters.Add("formaPago", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oRecibo.FormaPago;
        
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oRecibo.Moneda;
            oCommand.Parameters.Add("tipoCambio", OracleType.Number);
            oCommand.Parameters[4].Value = oRecibo.TipoCambio;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[5].Value = oRecibo.Monto;
            oCommand.Parameters.Add("saldo", OracleType.Number);
            oCommand.Parameters[6].Value = oRecibo.Saldo;
            oCommand.Parameters.Add("fechaDoc", OracleType.DateTime);
            oCommand.Parameters[7].Value = oRecibo.FechaDoc;
            oCommand.Parameters.Add("estatus", OracleType.NVarChar);
            oCommand.Parameters[8].Value = oRecibo.Estatus;
            oCommand.Parameters.Add("tipodoc", OracleType.NVarChar);
            oCommand.Parameters[9].Value = oRecibo.Tipodoc;
            oCommand.Parameters.Add("detalle", OracleType.NVarChar);
            oCommand.Parameters[10].Value = oRecibo.Detalle;
            oCommand.Parameters.Add("fechaRegistro", OracleType.DateTime);
            oCommand.Parameters[11].Value = oRecibo.FechaRegistro;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[12].Value = oRecibo.Usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[13].Value = oRecibo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Modificar(ReciboDinero oRecibo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECIBODINERO.paModificar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[0].Value = oRecibo.Indice;
            oCommand.Parameters.Add("numRecibo", OracleType.Number);
            oCommand.Parameters[1].Value = oRecibo.Numero;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[2].Value = oRecibo.Monto;
            oCommand.Parameters.Add("detalle", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oRecibo.Detalle;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oRecibo.Usuario;
            oCommand.Parameters.Add("formaPago", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oRecibo.FormaPago;            
            oCommand.Parameters.Add("moneda", OracleType.NVarChar);
            oCommand.Parameters[6].Value = oRecibo.Moneda;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oRecibo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Eliminar(ReciboDinero oRecibo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKRECIBODINERO.paEliminar";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("numRecibo", OracleType.Number);
            oCommand.Parameters[0].Value = oRecibo.Numero;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oRecibo.Usuario;
            oCommand.Parameters.Add("indice", OracleType.Number);
            oCommand.Parameters[2].Value = oRecibo.Indice;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[3].Value = oRecibo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            //Retornar el estado de la ejecución del procedimiento almacenado
            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean Cancelar(ReciboDinero oRecibo)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKROLLBACKRECIBO.parollback";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("recibo", OracleType.Number);
            oCommand.Parameters[0].Value = oRecibo.Numero;
            oCommand.Parameters.Add("cliente", OracleType.Number);
            oCommand.Parameters[1].Value = oRecibo.Cliente;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = oRecibo.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }



        public DataSet consultar(String cliente, int estado, String pNo_Cia)
        {
            String sql = "";
            if (estado == 0)
                sql = "select rec_numero, rec_monto, rec_Saldo,  rec_fechadoc, rec_forma_pago, rec_cliente, rec_moneda, rec_tipo_cambio, rec_estatus, rec_tipo_doc, rec_detalle, Cli_Nombre, rec_indice from TBL_RECIBOS_DINERO RD, TBL_CLIENTES cl where rd.no_Cia = '" + pNo_Cia + "' and rd.no_cia = cl.no_cia and Rec_estatus = 'SA' and Rec_saldo > 0 and Rec_Cliente = Cli_linea and Rec_estado = 1 and rec_cliente = '" + cliente + "'";
            else if (estado == 1)
                sql = "select rec_numero, rec_monto, rec_Saldo,  rec_fechadoc, rec_forma_pago, rec_cliente, rec_moneda, rec_tipo_cambio, rec_estatus, rec_tipo_doc, rec_detalle, Cli_Nombre, rec_indice from TBL_RECIBOS_DINERO RD, TBL_CLIENTES cl where rd.no_Cia = '" + pNo_Cia + "' and rd.no_cia = cl.no_cia and (Rec_estatus = 'FH' or Rec_estatus = 'AC') and Rec_Cliente = Cli_linea and Rec_estado = 1 and rec_cliente = '" + cliente + "'";
            else if (estado == 2)
                sql = "select rec_numero, rec_monto, rec_Saldo,  rec_fechadoc, rec_forma_pago, rec_cliente, rec_moneda, rec_tipo_cambio, rec_estatus, rec_tipo_doc, rec_detalle, Cli_Nombre, rec_indice from TBL_RECIBOS_DINERO RD, TBL_CLIENTES cl, TBL_RECIBOS_FACTURA RF where rd.no_Cia = '" + pNo_Cia + "' and rd.no_cia = cl.no_cia and rd.no_cia = rf.no_cia and (Rec_estatus = 'SA' or Rec_estatus = 'AC') and Rec_Cliente = Cli_linea and Rec_estado = 1 and rec_cliente = '" + cliente + "' and rec_indice=recfac_recibo and RECFAC_ESTADO='PE'";

            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }


        public DataSet consultar(String cliente, String moneda, String pNo_Cia)
        {
            String sql = "select REC_INDICE, REC_NUMERO,REC_MONEDA, rec_monto, rec_Saldo, 0 abono,rec_Saldo saldo_actual from TBL_RECIBOS_DINERO RD where rd.no_Cia = '" + pNo_Cia + "' and Rec_estatus = 'SA' and Rec_saldo > 0 and Rec_estado = 1 and REC_MONEDA='" + moneda + "' and rec_cliente = '" + cliente + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }
        
        public DataSet consultaSaldo(String cliente, String pNo_cia)
        {
            String sql = "select sum(rec_Saldo) from TBL_RECIBOS_DINERO RD where rd.no_Cia = '" + pNo_cia + "' and rec_estado = 1 and rec_cliente = '" + cliente + "'";
            DataSet oDataSet = OracleDAO.getInstance().EjecutarSQLDataSet(sql);
            return oDataSet;
        }

        public DataSet consultaInformacion(String recibo, String pNo_cia)
        {
            String sql = "select rec_cliente, cli_nombre, rec_moneda, rec_tipo_cambio from TBL_RECIBOS_DINERO RD, TBL_CLIENTES cl where rd.no_Cia = '" + pNo_cia + "' and rd.no_cia = cl.no_cia and rec_cliente = cli_linea and rec_estado = 1 and rec_numero = '" + recibo + "'";
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

        public DateTime Fecha()
        {
            String sql = "select sysdate from dual";
            DateTime oDataSet = OracleDAO.getInstance().EjecutarSQLScalarDateTime(sql);
            return oDataSet;
        }
    }
}
