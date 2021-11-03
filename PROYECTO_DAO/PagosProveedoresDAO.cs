using System;
using System.Collections.Generic;
using System.Text;
using ENTIDADES;

using System.Data.OracleClient;
using System.Data;

namespace PROYECTO_DAO
{
    public class PagosProveedoresDAO
    {
        public Boolean Insertar(PagosProveedores oPagosProveedores, string guia, string numFactura, double saldo)
        {
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "PCKPAGOSPROVEEDORES.paInsertar";

            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oPagosProveedores.Proveedor;

            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[1].Value = guia;

            oCommand.Parameters.Add("numFactura", OracleType.NVarChar);
            oCommand.Parameters[2].Value = numFactura;
            oCommand.Parameters.Add("saldoFactura", OracleType.Number);
            oCommand.Parameters[3].Value = saldo;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[4].Value = oPagosProveedores.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }

        public Boolean InsertarPago(PagosProveedores oPagosProveedores,  int guia)
        {
            OracleCommand oCommand = new OracleCommand();
          
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "PCKPAGOSPROVEEDORES.paInsertarPago";

            oCommand.Parameters.Add("proveedor", OracleType.NVarChar);
            oCommand.Parameters[0].Value = oPagosProveedores.Proveedor;
            oCommand.Parameters.Add("tipoPago", OracleType.NVarChar);
            oCommand.Parameters[1].Value = oPagosProveedores.TipoPago;
         
            oCommand.Parameters.Add("flujo", OracleType.Number);
            oCommand.Parameters[2].Value = oPagosProveedores.Flujo;
            oCommand.Parameters.Add("documento", OracleType.Number);
            oCommand.Parameters[3].Value = oPagosProveedores.Documento;
            oCommand.Parameters.Add("monto", OracleType.Number);
            oCommand.Parameters[4].Value = oPagosProveedores.Monto;
            oCommand.Parameters.Add("detallePago", OracleType.NVarChar);
            oCommand.Parameters[5].Value = oPagosProveedores.DetallePago;
      
            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[6].Value = guia;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[7].Value = oPagosProveedores.No_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }


        public Boolean Error()
        {
            return OracleDAO.getInstance().ErrorSQL;
        }

        public String DescError()
        {
            return OracleDAO.getInstance().DescripcionErrorSQL;
        }

        public Double Saldo(string factura, String pNo_cia )
        {
            String sql = "select facpag_saldo from TBL_FACTURAS_PENDIENTE_PAGO FPP where fpp.no_cia = '" + pNo_cia + "' and upper(facpag_num_factura)=upper('" + factura + "')";
            double saldo = OracleDAO.getInstance().EjecutarSQLScalarDouble(sql);
            return saldo;
        }

        public string Banco(string cuenta, String pNo_cia)
        {
            String sql = "SELECT CTABAN_IDBANCO FROM TBL_CUENTAS_BANCARIAS cb WHERE cb.no_cia = '" + pNo_cia + "' and  CTABAN_CTA='" + cuenta + "'";
            return OracleDAO.getInstance().EjecutarSQLScalarString(sql);
        }

        public int Eliminar(int indice, String pNo_Cia)
        {
            String sql = "delete from TBL_PAGOS_PROVEEDORES PP where pp.no_cia = '" + pNo_Cia + "' and PAG_ID = '" + indice + "'";
            return OracleDAO.getInstance().EjecutarSQL(sql);
        }

        public Boolean Cancelar(int guia, String usuario, String pNo_cia)
        {
            //Declaración de objeto SqlCommand           
            OracleCommand oCommand = new OracleCommand();

            oCommand.CommandText = "PCKROLLBACKPAGOS.parollback";
            oCommand.CommandType = CommandType.StoredProcedure;

            //Crear los Parámetros del procedimiento y sus valores
            oCommand.Parameters.Add("guia", OracleType.Number);
            oCommand.Parameters[0].Value = guia;
            oCommand.Parameters.Add("usuario", OracleType.NVarChar);
            oCommand.Parameters[1].Value = usuario;
            oCommand.Parameters.Add("pNo_cia", OracleType.NVarChar);
            oCommand.Parameters[2].Value = pNo_cia;

            OracleDAO.getInstance().EjecutarSQLStoreProcedure(oCommand);

            return !OracleDAO.getInstance().ErrorSQL;
        }
    }
}
