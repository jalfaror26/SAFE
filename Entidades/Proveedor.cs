using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES
{

    public class Proveedor
    {
        #region Propiedades privadas

        private String id, tipoID, nombre, telefono, fax, contacto, telContacto, ubicacion, descripcion, categoria, refBancaria;
        private Double dias, indice;
        private String no_cia;

        public String No_cia
        {
            get { return no_cia; }
            set { no_cia = value; }
        }

        #endregion

        #region Set's and Get's
        public Double Indice
        {
            get { return indice; }
            set { indice = value; }
        }
        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public String TipoID
        {
            get { return tipoID; }
            set { tipoID = value; }
        }
        public String RefBancaria
        {
            get { return refBancaria; }
            set { refBancaria = value; }
        }

        public String Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public Double Dias
        {
            get { return dias; }
            set { dias = value; }
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

        public String TelContacto
        {
            get { return telContacto; }
            set { telContacto = value; }
        }

        public String Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
       
        #endregion
    }
}