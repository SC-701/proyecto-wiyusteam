using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Personas
{
    public class DetalleModel : PageModel
    {
        private IConfiguracion _configuracion;

        public PersonaResponse persona { get; set; } = new PersonaResponse();

        public DetalleModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet(int? id)
        {
            if (id == null)
                return;

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPersona");

            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                persona = JsonSerializer.Deserialize<PersonaResponse>(resultado, opciones);
            }
        }
    }
}