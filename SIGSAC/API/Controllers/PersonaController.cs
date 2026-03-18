/* Resumencito de este código: 
 
        PersonaBase → datos + validaciones
        PersonaRequest → entrada
        PersonaResponse → salida + Id
        PersonaDetalle → más información
        DataAnnotations → validación automática
 
Se usa una clase base para centralizar propiedades comunes y aplicar herencia
Se usa para evitar repetir código

Es la capa API que recibe solicitudes HTTP, utiliza inyección de dependencias
para acceder al flujo, delega la lógica de negocio y retorna respuestas HTTP 
como 200, 201, 404 o 204 según el resultado.

*/

using Abstracciones.Interfaces.API; // Importa la interfaz del controller (contrato)
using Abstracciones.Interfaces.Flujo; // Importa la interfaz del flujo (lógica/intermediario)
using Abstracciones.Modelos; // Importa los modelos (PersonaRequest, etc.)
using Microsoft.AspNetCore.Mvc; // Importa clases para construir APIs (ControllerBase, IActionResult)

namespace API.Controllers // Namespace de la capa API (capa externa)
{
    // Define la ruta base del controller: api/persona
    [Route("api/[controller]")]
    [ApiController] // Indica que es un API controller (activa validaciones automáticas, model binding, etc.) VALIDACIÓN AUTOMÁTICA!! Usa DataAnnotations
    public class PersonaController : ControllerBase, IPersonaController // Hereda de ControllerBase e implementa la interfaz
    {
        /*NO USA DA DIRECTO, Usa Flujo 
         El controller no accede directamente a 
        la base de datos, delega al flujo*/

        private IPersonaFlujo _personaFlujo; // Dependencia hacia la capa Flujo (NO usa DA directo)
        private ILogger<PersonaController> _logger; // Para registrar logs (errores, info, etc.)

        /*INYECCIÓN DE DEPENDENCIAS, 
         .NET le pasa la implementación 
        automáticamente
        la base de datos, delega al flujo
        
         Se utiliza DI para desacoplar dependencias”*/
        public PersonaController(
            IPersonaFlujo personaFlujo,
            ILogger<PersonaController> logger)
        {
            _personaFlujo = personaFlujo; // Se inyecta el flujo
            _logger = logger; // Se inyecta el logger
        }

        #region Operaciones

        // POST api/persona
        [HttpPost]

        // Aquí tenemos MODEL BINDING! 
        public async Task<IActionResult> Agregar(PersonaRequest persona) // ASP.NET convierte JSON → objeto automáticamente
        {
            // Llama al flujo para agregar la persona (no accede directo a BD)
            var resultado = await _personaFlujo.Agregar(persona);

            // Retorna 201 Created
            // CreatedAtAction genera la ubicación del nuevo recurso
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        // PUT api/persona/{Id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(int Id, PersonaRequest persona)
        {
            // Verifica si la persona existe antes de editar
            if (!await VerificarPersonaExiste(Id))
                return NotFound("La persona no existe"); // 404

            // Llama al flujo para editar
            var resultado = await _personaFlujo.Editar(Id, persona);

            return Ok(resultado); // 200 OK
        }

        // DELETE api/persona/{Id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            // Verifica existencia antes de eliminar
            if (!await VerificarPersonaExiste(Id))
                return NotFound("La persona no existe"); // 404

            // Llama al flujo para eliminar
            var resultado = await _personaFlujo.Eliminar(Id);

            return NoContent(); // 204 NoContent (eliminado correctamente)
        }

        // GET api/persona
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            // Obtiene todas las personas desde el flujo
            var resultado = await _personaFlujo.Obtener();

            // Si no hay datos → 204 NoContent
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado); // 200 OK con datos
        }

        // GET api/persona/{Id}
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            // Obtiene una persona por Id
            var resultado = await _personaFlujo.Obtener(Id);

            // Si no existe → 404
            if (resultado == null)
                return NotFound("La persona no existe");

            return Ok(resultado); // 200 OK
        }

        #endregion


        #region Helpers

        // Método auxiliar para verificar si una persona existe
        private async Task<bool> VerificarPersonaExiste(int Id)
        {
            var resultadoValidacion = false;

            // Consulta al flujo (no a DA directo)
            var resultadoPersonaExiste = await _personaFlujo.Obtener(Id);

            // Si existe → true
            if (resultadoPersonaExiste != null)
                resultadoValidacion = true;

            return resultadoValidacion;
        }

        #endregion
    }
}