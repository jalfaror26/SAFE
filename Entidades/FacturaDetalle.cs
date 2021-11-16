using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class FacturaDetalle
    {


        private String medida, codServicio, descripcion;
        private Double precioUnitario, montoIV, subtotal, precioTotal, descuento, cantidad;
        private int indice, indiceFactura;

        private String no_cia;

        private String ivi;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public Double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
                        
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Medida
        {
            get { return medida; }
            set { medida = value; }
        }

        public Double PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }

        public Double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public Double MontoIV
        {
            get { return montoIV; }
            set { montoIV = value; }
        }

        public Double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int IndiceFactura
        {
            get { return indiceFactura; }
            set { indiceFactura = value; }
        }

        public int Indice { get { return indice; } set { indice = value; } }

        public string IVI { get => ivi; set => ivi = value; }
        public string CodServicio { get => codServicio; set => codServicio = value; }
    }
}
