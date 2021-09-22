using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{
    public class Cliente
    {
        #region Propiedades privadas

        private String id;
        private Int32 indice;
        private Char tipoId;
        private String nombre;
        private String telefono;
        private String fax;
        private String contacto;
        private String correo;
        private String ubicacion;
        private String credito;
        private Int32 dias;
        private Int32 almacen;
        private String descAlmacen;
        private String identificacion;
        private double lc_limite;
        private String lc_moneda;

        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        #endregion

        #region Set's and Get's

        public String Lc_moneda
        {
            get { return lc_moneda; }
            set { lc_moneda = value; }
        }


        public double Lc_limite
        {
            get { return lc_limite; }
            set { lc_limite = value; }
        }

        public String Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public Int32 Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public Int32 Dias
        {
            get { return dias; }
            set { dias = value; }
        }

        public Char TipoId
        {
            get { return tipoId; }
            set { tipoId = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public String Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public String Credito
        {
            get { return credito; }
            set { credito = value; }
        }

        public Int32 Almacen
        {
            get { return almacen; }
            set { almacen = value; }
        }


        public String DescAlmacen
        {
            get { return descAlmacen; }
            set { descAlmacen = value; }
        }

        #endregion
    }
}
