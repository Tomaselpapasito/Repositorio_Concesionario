
using lib_presentaciones.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace lib_presentaciones.Implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        private readonly IHttpContextAccessor IHttpContextAccessor;

        public Comunicaciones(IHttpContextAccessor IHttpContextAccessor)
        {
            this.IHttpContextAccessor = IHttpContextAccessor;
        }

        public async Task<T> Ejecutar<T>(string url, object entidad)
        {
            url = "http://localhost:5146/" + url;

            var body = new StringContent(
                JsonConvert.SerializeObject(entidad),
                Encoding.UTF8,
                "application/json"
            );

            using var cliente_http = new HttpClient();

            cliente_http.Timeout = new TimeSpan(0, 4, 0);

            var token = this.IHttpContextAccessor.HttpContext?
                .Session.GetString("Token");

            if (!string.IsNullOrWhiteSpace(token))
            {
                cliente_http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            var message = await cliente_http.PostAsync(url, body);

            var respuesta = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode)
                throw new Exception(
                    $"Error de comunicación: {(int)message.StatusCode} - {respuesta}"
                );

            return JsonConvert.DeserializeObject<T>(respuesta)!;
        }
    }
}
