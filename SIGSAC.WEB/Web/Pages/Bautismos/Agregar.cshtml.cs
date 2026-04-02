using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Bautismos
{
    public class AgregarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public BautismoRequest bautismo { get; set; } = new BautismoRequest();

        public List<PersonaResponse> Personas { get; set; } = new();

        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPersonas");

            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(endpoint);

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var json = await respuesta.Content.ReadAsStringAsync();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                Personas = JsonSerializer.Deserialize<List<PersonaResponse>>(json, opciones);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                await OnGet(); // recargar dropdowns
                return Page();
            }

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarBautismo");

            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync(endpoint, bautismo);

            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}