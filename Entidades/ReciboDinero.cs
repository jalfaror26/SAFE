using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class ReciboDinero
    {
        private int cliente, indice;
        private Double tipoCambio, monto, saldo;
        private String formaPago, moneda, estatus, tipodoc, detalle, usuario, nombreCliente, tipoIngreso;
        private DateTime fechaDoc, fechaRegistro;
        private Double numero;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public String TipoIngreso
        {
            get { return tipoIngreso; }
            set { tipoIngreso = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public int Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        
        public Double Numero
        {
            get { return numero; }
            set { numero = value; }
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

        public Double TipoCambio
        {
            get { return tipoCambio; }
            set { tipoCambio = value; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public String Tipodoc
        {
            get { return tipodoc; }
            set { tipodoc = value; }
        }

        public String Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public String Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public String FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        public String NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public DateTime FechaDoc
        {
            get { return fechaDoc; }
            set { fechaDoc = value; }
        }
    }
}
