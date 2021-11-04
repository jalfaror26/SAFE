using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Cotizacion
    {
        private int indice;

        private DateTime fechaCotizacion;

        private Double tipocambio, subTotal, impuesto, descuento, total, saldo, porDescuento;
        private int tarjeta, cotizacion;
        private String cliente, nombre, telefono, ubicacion, moneda, estado, observacion, comentario;
        private Double indiceDocumento;
        private String tipo, tipoDocumento;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
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

        public DateTime FechaCotizacion
        {
            get { return fechaCotizacion; }
            set { fechaCotizacion = value; }
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

        public int NumCotizacion
        {
            get { return cotizacion; }
            set { cotizacion = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

    }
}
