/* Resumencito de este código: 
 
        BautismoBase → datos + validaciones
        BautismoRequest → entrada
        BautismoResponse → salida + Id
        BautismoDetalle → más información (incluye nombres)
        DataAnnotations → validación automática
 
Se usa una clase base para centralizar propiedades comunes y aplicar herencia
Se usa para evitar repetir código

Es la capa API que recibe solicitudes HTTP, utiliza inyección de dependencias
para acceder al flujo, delega la lógica de negocio y retorna respuestas HTTP 
como 200, 201, 404 o 204 según el resultado.

*/
using Abstracciones.Interfaces.API; // Interfaz del controller (contrato)
using Abstracciones.Interfaces.Flujo; // Interfaz del flujo (intermediario)
using Abstracciones.Modelos; // Modelos (BautismoRequest, etc.)
using Flujo;
using Microsoft.AspNetCore.Mvc; // ControllerBase, IActionResult

namespace API.Controllers // Capa API (externa)
{
    [Route("api/[controller]")] // Ruta: api/bautismo
    [ApiController] // VALIDACIÓN AUTOMÁTICA + Model Binding
    public class BautismoController : ControllerBase, IBautismoController
    {
        /* NO USA DA DIRECTO, Usa Flujo
           El controller no accede directamente a la base de datos,
           delega al flujo */

        private IBautismoFlujo _bautismoFlujo; // Dependencia hacia Flujo
        private ILogger<BautismoController> _logger; // Logger

        /* INYECCIÓN DE DEPENDENCIAS
           .NET inyecta automáticamente las implementaciones
           Se usa para desacoplar el sistema */
        public BautismoController(
            IBautismoFlujo bautismoFlujo,
            ILogger<BautismoController> logger)
        {
            _bautismoFlujo = bautismoFlujo;
            _logger = logger;
        }

        #region Operaciones

        // POST api/bautismo
        [HttpPost]

        // MODEL BINDING → JSON → objeto BautismoRequest
        public async Task<IActionResult> Agregar([FromBody] BautismoRequest bautismo)
        {
            var resultado = await _bautismoFlujo.Agregar(bautismo);

            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null); // 201
        }

        // PUT api/bautismo/{Id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] int Id, [FromBody] BautismoRequest bautismo)
        {
            // Verifica existencia antes de editar
            if (!await VerificarBautismoExiste(Id))
                return NotFound("El bautismo no existe"); // 404

            var resultado = await _bautismoFlujo.Editar(Id, bautismo);

            return Ok(resultado); // 200
        }

        // DELETE api/bautismo/{Id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int Id)
        {
            // Verifica existencia antes de eliminar
            if (!await VerificarBautismoExiste(Id))
                return NotFound("El bautismo no existe"); // 404

            var resultado = await _bautismoFlujo.Eliminar(Id);

            return NoContent(); // 204
        }

        // GET api/bautismo
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _bautismoFlujo.Obtener();

            if (!resultado.Any())
                return NoContent(); // 204

            return Ok(resultado); // 200
        }

        // GET api/bautismo/{Id}
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] int Id)
        {
            var resultado = await _bautismoFlujo.Obtener(Id);

            if (resultado == null)
                return NotFound("El bautismo no existe"); // 404

            return Ok(resultado); // 200
        }

        #endregion

        #region Helpers

        // Método para verificar si existe un bautismo
        private async Task<bool> VerificarBautismoExiste(int Id)
        {
            var resultadoValidacion = false;

            var resultadoBautismoExiste = await _bautismoFlujo.Obtener(Id);

            if (resultadoBautismoExiste != null)
                resultadoValidacion = true;

            return resultadoValidacion;
        }

        #endregion
    }
}
