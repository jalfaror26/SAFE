using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace PROYECTO
{
    public class Ent_CW
    {
        //PRO: WS_ExperienciaCompra - https://servicios.grupogollo.com:9092/ServicioGeneralAPI/unicomer/general
        //DES: WS_ExperienciaCompraDes - http://10.14.226.87:9092/ServicioGeneralAPI/unicomer/general
        //DES_SV: WS_ExperienciaCompraDesSV - http://10.14.254.243:9099/ServicioGeneralAPI/unicomer/general

        String WS_Conectar = "DES";

        public string WS_Conectar1 { get => WS_Conectar; set => WS_Conectar = value; }

        //DESARROLLO
        //private readonly String urlAPIDes = "http://10.14.226.87:9092/ServicioGeneralAPI/unicomer/general";

        //DESARROLLO_SV
        private readonly String urlAPIDes = "https://dev.facturadorvirtual.com/api/2.0/";

        //PRODUCCION
        private readonly String urlAPIPro = "https://app.facturadorvirtual.com/api/2.0/";

        private String urlAPI;

        private String AsignaUrlAPI()
        {
            switch (WS_Conectar)
            {
                case "DES":
                    urlAPI = urlAPIDes;
                    break;
                case "PRO":
                    urlAPI = urlAPIPro;
                    break;
            }
            return urlAPI;
        }

        public string UrlAPI
        {
            get => AsignaUrlAPI(); set => urlAPI = value;
        }

        private String ObtieneJson(String pMetodo, String pPostURl, String postString, out Boolean pstatusCode, out Boolean pTimeOut)//HttpStatusCode pstatusCode)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(UrlAPI + pPostURl) as HttpWebRequest;
                request.Timeout = 20000;
                //request.Method = "POST";
                request.Method = pMetodo;
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Headers.Add("api-token", "ir57BZTJirNGIZny7lq5nCzlcCjHvbuahuiZ81AFVvpuz2hz");
                request.Headers.Add("access-token", "XrDy9i97pQeyGayRGGhGogJDEYMq4Hm7h1lPWXqfnhoPgev3M1Wp");

                string data = postString;
                if (pMetodo.Equals("POST"))
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                HttpWebResponse myWebResponse = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(myWebResponse.GetResponseStream());

                String retorno = reader.ReadToEnd();

                pstatusCode = true;// response.StatusCode;
                pTimeOut = false;

                myWebResponse.Close();
                reader.Close();

                return retorno;

            }
            catch (WebException e)
            {
                if (e.Message.Equals("The operation has timed out."))
                    pTimeOut = true;
                else
                    pTimeOut = false;

                pstatusCode = false;
                return @"{""responseCode"": ""404"",""responseDescription"": """ + e.Message + @"""}";
            }
        }

        public String TraerClientes(out Boolean /*HttpStatusCode*/ pstatusCode, out Boolean pTimeOut)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(new { General = oParametrosGeneralAPI });

                return ObtieneJson("GET", "clientes/repositorio", "", out pstatusCode, out pTimeOut);
            }
            catch (WebException e)
            {
                //  HttpWebResponse response = (HttpWebResponse)e.Response;
                pstatusCode = false;

                pTimeOut = false;
                return @"{""responseCode"": ""404"",""responseDescription"": """ + e.Message + @"""}";
            }
        }

        public String TraerServicios(out Boolean /*HttpStatusCode*/ pstatusCode, out Boolean pTimeOut)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(new { General = oParametrosGeneralAPI });

                return ObtieneJson("GET", "productos/repositorio", "", out pstatusCode, out pTimeOut);
            }
            catch (WebException e)
            {
                //  HttpWebResponse response = (HttpWebResponse)e.Response;
                pstatusCode = false;

                pTimeOut = false;
                return @"{""responseCode"": ""404"",""responseDescription"": """ + e.Message + @"""}";
            }
        }

        public String CrearFE(String json, out Boolean /*HttpStatusCode*/ pstatusCode, out Boolean pTimeOut)
        {
            try
            {
                return ObtieneJson("POST", "/documentos-electronicos/emision/factura", json, out pstatusCode, out pTimeOut);
            }
            catch (WebException e)
            {
                //  HttpWebResponse response = (HttpWebResponse)e.Response;
                pstatusCode = false;

                pTimeOut = false;
                return @"{""responseCode"": ""404"",""responseDescription"": """ + e.Message + @"""}";
            }
        }

        public String ComprobarFE(String pClave, out Boolean /*HttpStatusCode*/ pstatusCode, out Boolean pTimeOut)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(new { General = oParametrosGeneralAPI });

                return ObtieneJson("GET", "/documentos-electronicos/hacienda/comprobar/" + pClave, "", out pstatusCode, out pTimeOut);
            }
            catch (WebException e)
            {
                //  HttpWebResponse response = (HttpWebResponse)e.Response;
                pstatusCode = false;

                pTimeOut = false;
                return @"{""responseCode"": ""404"",""responseDescription"": """ + e.Message + @"""}";
            }
        }
    }
}