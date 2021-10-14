using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class FacturasPendientes
    {
        private int numFactura, idCliente, aplicaRetencion, dias, indice;
        private String nombre, moneda, estatus, observacion, tipoDocumento, Anombrede, usuario;
        private Double tipocambio, subtotal, impuesto, monto, retencion, saldo, retencionReal,exento;
        private DateTime fechaActual, fechaEmision, fechaVence;

        public FacturasPendientes()
        {

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

        public DateTime FechaActual
        {
            get { return fechaActual; }
            set { fechaActual = value; }
        }

        public Double RetencionReal
        {
            get { return retencionReal; }
            set { retencionReal = value; }
        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public Double Retencion
        {
            get { return retencion; }
            set { retencion = value; }
        }

        public Double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public Double Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }

        public Double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public Double Tipocambio
        {
            get { return tipocambio; }
            set { tipocambio = value; }
        }

        public String Usuari
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Anombrede1
        {
            get { return Anombrede; }
            set { Anombrede = value; }
        }

        public String TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

        public String Observacion
        {
            get { return observacion; }
            set { observacion = value; }
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

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public int Dias
        {
            get { return dias; }
            set { dias = value; }
        }

        public int AplicaRetencion
        {
            get { return aplicaRetencion; }
            set { aplicaRetencion = value; }
        }

        public Double Exento
        {
            get { return exento; }
            set { exento = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public int NumFactura
        {
            get { return numFactura; }
            set { numFactura = value; }
        }
    }
}
