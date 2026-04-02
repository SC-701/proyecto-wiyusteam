using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Personas
{
    public class AgregarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public PersonaRequest persona { get; set; } = new PersonaRequest();

        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarPersona");

            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync(endpoint, persona);

            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}