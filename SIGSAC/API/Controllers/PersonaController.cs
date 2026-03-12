using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase, IPersonaController
    {
        private IPersonaFlujo _personaFlujo;
        private ILogger<PersonaController> _logger;

        public PersonaController(
            IPersonaFlujo personaFlujo,
            ILogger<PersonaController> logger)
        {
            _personaFlujo = personaFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpPost]
        public async Task<IActionResult> Agregar(PersonaRequest persona)
        {
            var resultado = await _personaFlujo.Agregar(persona);

            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(int Id, PersonaRequest persona)
        {
            if (!await VerificarPersonaExiste(Id))
                return NotFound("La persona no existe");

            var resultado = await _personaFlujo.Editar(Id, persona);

            return Ok(resultado);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            if (!await VerificarPersonaExiste(Id))
                return NotFound("La persona no existe");

            var resultado = await _personaFlujo.Eliminar(Id);

            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _personaFlujo.Obtener();

            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var resultado = await _personaFlujo.Obtener(Id);

            if (resultado == null)
                return NotFound("La persona no existe");

            return Ok(resultado);
        }

        #endregion


        #region Helpers

        private async Task<bool> VerificarPersonaExiste(int Id)
        {
            var resultadoValidacion = false;

            var resultadoPersonaExiste = await _personaFlujo.Obtener(Id);

            if (resultadoPersonaExiste != null)
                resultadoValidacion = true;

            return resultadoValidacion;
        }

        #endregion
    }
}