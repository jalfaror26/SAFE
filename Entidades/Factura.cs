using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Factura
    {
        private int indice, diasCredito;

        private DateTime fechaFactura;

        private Double tipocambio, subTotal, impuesto, descuento, total, saldo, adelanto, porDescuento;
        private int tarjeta, factura;
        private String cliente, nombre, telefono, ubicacion, moneda, estado, observacion, comentario, comprobante, tipopago;
        private Double indiceDocumento;
        private String formaPago, tipo, tipoDocumento;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }
        
        public String Tipopago
        {
            get { return tipopago; }
            set { tipopago = value; }
        }

        public String Comprobante
        {
            get { return comprobante; }
            set { comprobante = value; }
        }

        public String Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }
        public int Tarjeta
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }
        
        public Double PorDescuento
        {
            get { return porDescuento; }
            set { porDescuento = value; }
        }

        public String FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        
        public String TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

        public Double IndiceDocumento
        {
            get { return indiceDocumento; }
            set { indiceDocumento = value; }
        }

        public Double Adelanto
        {
            get { return adelanto; }
            set { adelanto = value; }
        }
        
        public String Observacion
        {
            get { return observacion; }
            set { observacion = value; }
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
        
        public String Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime FechaFactura
        {
            get { return fechaFactura; }
            set { fechaFactura = value; }
        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public Double Total
        {
            get { return total; }
            set { total = value; }
        }

        public Double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public Double Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }

        public Double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }
        
        public Double Tipocambio
        {
            get { return tipocambio; }
            set { tipocambio = value; }
        }

        public int NumFactura
        {
            get { return factura; }
            set { factura = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public int DiasCredito
        {
            get { return diasCredito; }
            set { diasCredito = value; }
        }
    }
}
