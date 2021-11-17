using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PROYECTO
{
    public class Root
    {
        public string total { get; set; }
        public int pagina { get; set; }
        public int paginas { get; set; }
        public int totalPorPagina { get; set; }
        public List<Producto> productos { get; set; }


        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public CResultado cResultado { get; set; }

        //public List<CResultado> cListResultado { get; set; }

    }

    public class Producto
    {
        // Generico
        public int id { get; set; }

        // Clientes
        public string cedula { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string correoElectronico { get; set; }
        public int codigoPais { get; set; }
        public int telefono { get; set; }
        public int provincia { get; set; }
        public int canton { get; set; }
        public int distrito { get; set; }
        public string otrasSenas { get; set; }
        public string nombreComercial { get; set; }

        // Servicios
        public string codigo { get; set; }
        public String codigoComercial { get; set; }
        public String descripcionGeneral { get; set; }
        public string unidad { get; set; }
        public double precio { get; set; }
        public double cantidad { get; set; }
        public string detalle { get; set; }
        public String codigo_barra { get; set; }
    }



    public class CResultado
    {
        public string AVISO { get; set; }
        public string Show_Window { get; set; }
        public string vMod { get; set; }
        public string ID_OPCION { get; set; }
        public string NOMBRE_AUTORIZA { get; set; }
        public string AUTORIZADOR { get; set; }
        public string VersionApp { get; set; }
        public string RutaDescargaApp { get; set; }
        public Otros otros { get; set; }
        public List<Resultado> Resultados { get; set; }

    }

    public class Otros
    {
        public double redondeo { get; set; }
        public double cuotaBalanceada { get; set; }
        public double cuotaInteres { get; set; }
        public DateTime sysdate { get; set; }
        public string indextrag { get; set; }
        public int cont_lineas { get; set; }
        public int cantidad_series { get; set; }
        public double total_extrag { get; set; }
    }

    public class Resultado
    {
        public string NO_TRANSA_MOV { get; set; }
        public string SOLICITUD_ID_WF { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string DESC_TIPO_FACTURA { get; set; }
        public string SIMBOLO { get; set; }
        public double TOTAL { get; set; }
        public string DESC_ESTADO_ANALISTA_CRE { get; set; }
        public string IND_PASA_CREDITO { get; set; }
        public string IND_APROBADA { get; set; }
        public string COD_USUARIO { get; set; }
        public string CEDULA { get; set; }
        public string IND_VENTA_CONTADO { get; set; }
        public string BODEGA { get; set; }
        public string DESC_BODEGA { get; set; }
        public string DESC_ESTADO_COND { get; set; }

    }

}