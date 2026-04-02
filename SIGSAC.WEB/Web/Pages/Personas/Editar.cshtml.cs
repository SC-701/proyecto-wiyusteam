using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Personas
{
    public class EditarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public PersonaResponse persona { get; set; } = new PersonaResponse();

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        // GET
        public async Task<IActionResult> OnGet(int id)
        {
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

            return Page();
        }

        // POST
        public async Task<IActionResult> OnPost()
        {
            if (persona.Id == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarPersona");

            var cliente = new HttpClient();

            var respuesta = await cliente.PutAsJsonAsync(
                string.Format(endpoint, persona.Id),
                new PersonaRequest
                {
                    Nombre = persona.Nombre,
                    PrimerApellido = persona.PrimerApellido,
                    SegundoApellido = persona.SegundoApellido,
                    Cedula = persona.Cedula,
                    Pasaporte = persona.Pasaporte,
                    Sexo = persona.Sexo,
                    FechaNacimiento = persona.FechaNacimiento,
                    HoraNacimiento = persona.HoraNacimiento,
                    LugarNacimiento = persona.LugarNacimiento,
                    Nacionalidad = persona.Nacionalidad,
                    EstadoCivil = persona.EstadoCivil,
                    Profesion = persona.Profesion,
                    Religion = persona.Religion,
                    Direccion = persona.Direccion
                });

            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}