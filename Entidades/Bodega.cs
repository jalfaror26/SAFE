using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Bodega
    {
        private string id;        
        private int indice, cliente;
        private string descripcion, tipo, centro;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        public int Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Centro { get => centro; set => centro = value; }
    }
}
