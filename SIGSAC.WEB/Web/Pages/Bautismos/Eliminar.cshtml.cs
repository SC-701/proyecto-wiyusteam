using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Bautismos
{
    public class EliminarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public BautismoDetalle bautismo { get; set; } = new BautismoDetalle();

        public EliminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        // GET
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerBautismo");

            var cliente = new HttpClient();
            var res = await cliente.GetAsync(string.Format(endpoint, id));

            res.EnsureSuccessStatusCode();

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var json = await res.Content.ReadAsStringAsync();

                bautismo = JsonSerializer.Deserialize<BautismoDetalle>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }

            return Page();
        }

        // POST (DELETE)
        public async Task<IActionResult> OnPost()
        {
            if (bautismo.Id == 0)
                return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarBautismo");

            var cliente = new HttpClient();

            var res = await cliente.DeleteAsync(string.Format(endpoint, bautismo.Id));

            res.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}