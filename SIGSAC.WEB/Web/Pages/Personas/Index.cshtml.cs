using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Personas
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;

        public IList<PersonaResponse> personas { get; set; } = new List<PersonaResponse>();

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPersonas");

            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                personas = JsonSerializer.Deserialize<List<PersonaResponse>>(resultado, opciones);
            }
        }
    }
}