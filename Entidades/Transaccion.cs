using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Transaccion
    {
        private DateTime fechaRegistro;

        private Double monto, saldoAnterior, saldoActual;
        private String tipoTransaccion, moneda, texto, usuario, numfactura;
        private int numDocumento, idCliente;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }
        
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public String NumFactura
        {
            get { return numfactura; }
            set { numfactura = value; }
        }

        public int NumDocumento
        {
            get { return numDocumento; }
            set { numDocumento = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public Double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public Double SaldoAnterior
        {
            get { return saldoAnterior; }
            set { saldoAnterior = value; }
        }

        public Double SaldoActual
        {
            get { return saldoActual; }
            set { saldoActual = value; }
        }

        public String Tipotransaccion
        {
            get { return tipoTransaccion; }
            set { tipoTransaccion = value; }
        }

        public String Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public String Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
