using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class FacturasPago
    {

        private int flujo, indice, dias;
        private String numFactura, codProveedor, responsable, tipoGasto, moneda, estado, usuario;
        private Double tipocambio, monto, saldo;
        private DateTime fechaEmision, fechaVence;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public String TipoGasto
        {
            get { return tipoGasto; }
            set { tipoGasto = value; }
        }

        public String Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        public DateTime FechaVence
        {
            get { return fechaVence; }
            set { fechaVence = value; }
        }

        public DateTime FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public Double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public int Flujo
        {
            get { return flujo; }
            set { flujo = value; }
        }

        public int Dias
        {
            get { return dias; }
            set { dias = value; }
        }

        public Double Tipocambio
        {
            get { return tipocambio; }
            set { tipocambio = value; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public String CodProveedor
        {
            get { return codProveedor; }
            set { codProveedor = value; }
        }

        public String NumFactura
        {
            get { return numFactura; }
            set { numFactura = value; }
        }
    }
}
