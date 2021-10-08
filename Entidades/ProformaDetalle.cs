using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class ProformaDetalle
    {


        private String medida, codArticulo,  descripcion, usuario;
        private Double precioUnitario, subTotal, monto_IV, precioTotal, descuento, cantidad;
        private int indice,  tipoPrecio, indiceProforma;
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
        
        public int TipoPrecio
        {
            get { return tipoPrecio; }
            set { tipoPrecio = value; }
        }
        
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String CodArticulo
        {
            get { return codArticulo; }
            set { codArticulo = value; }
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

        public Double Monto_IV
        {
            get { return monto_IV; }
            set { monto_IV = value; }
        }

        public Double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public Double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public Double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int IndiceProforma
        {
            get { return indiceProforma; }
            set { indiceProforma = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public string IVI { get => ivi; set => ivi = value; }
    }
}
