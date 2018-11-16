using InterfazUsuario.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterfazUsuario.Services
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        string urlBase = "https://cookitort.azurewebsites.net/api/";

        public async Task<Cliente> GetClienteASync(string correo, string pass)
        {
            try
            {
                string url = urlBase + "Clientes?correo={correo}&pass={pass}";
                var response = await client.GetStringAsync(url);
                var cliente = JsonConvert.DeserializeObject<Cliente>(response);
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
         * try
            {
                string url = urlBase + "Clientes?correo={correo}&pass={pass}";
                var uri = new Uri(string.Format(url, correo), string.Format(url, pass));
                var data = JsonConvert.SerializeObject(correo);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error 666.");
                }            }
            catch (Exception ex)
            {
                throw ex;
            }
    */
    }
}
