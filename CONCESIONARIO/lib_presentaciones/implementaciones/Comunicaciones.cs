
using lib_presentaciones.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace lib_presentaciones.Implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
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