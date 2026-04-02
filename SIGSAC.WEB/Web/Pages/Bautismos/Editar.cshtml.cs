using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Bautismos
{
    public class EditarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public BautismoResponse bautismo { get; set; } = new BautismoResponse();

        public List<PersonaResponse> Personas { get; set; } = new();

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        // GET
        public async Task<IActionResult> OnGet(int id)
        {
            // 1. Cargar bautismo
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerBautismo");

            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(string.Format(endpoint, id));
            respuesta.EnsureSuccessStatusCode();

            var json = await respuesta.Content.ReadAsStringAsync();

            bautismo = JsonSerializer.Deserialize<BautismoResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // 2. Cargar personas (dropdowns)
            string endpointPersonas = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPersonas");

            var respPersonas = await cliente.GetAsync(endpointPersonas);

            if (respPersonas.StatusCode == HttpStatusCode.OK)
            {
                var jsonPersonas = await respPersonas.Content.ReadAsStringAsync();

                Personas = JsonSerializer.Deserialize<List<PersonaResponse>>(jsonPersonas,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return Page();
        }

        // POST
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                await OnGet(bautismo.Id); // recargar combos
                return Page();
            }

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarBautismo");

            var cliente = new HttpClient();

            var respuesta = await cliente.PutAsJsonAsync(
                string.Format(endpoint, bautismo.Id),
                new BautismoRequest
                {
                    BautizandoId = bautismo.BautizandoId,
                    PadreId = bautismo.PadreId,
                    MadreId = bautismo.MadreId,
                    TipoUnionPadres = bautismo.TipoUnionPadres,
                    FechaMatrimonioPadres = bautismo.FechaMatrimonioPadres,
                    AbueloPaternoId = bautismo.AbueloPaternoId,
                    AbuelaPaternaId = bautismo.AbuelaPaternaId,
                    AbueloMaternoId = bautismo.AbueloMaternoId,
                    AbuelaMaternaId = bautismo.AbuelaMaternaId,
                    PadrinoId = bautismo.PadrinoId,
                    MadrinaId = bautismo.MadrinaId,
                    DeclaranteId = bautismo.DeclaranteId
                });

            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}