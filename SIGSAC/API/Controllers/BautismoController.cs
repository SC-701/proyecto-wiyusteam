using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BautismoController : ControllerBase, IBautismoController
    {
        private IBautismoFlujo _bautismoFlujo;
        private ILogger<BautismoController> _logger;

        public BautismoController(
            IBautismoFlujo bautismoFlujo,
            ILogger<BautismoController> logger)
        {
            _bautismoFlujo = bautismoFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpPost]
        public async Task<IActionResult> Agregar(BautismoRequest bautismo)
        {
            var resultado = await _bautismoFlujo.Agregar(bautismo);

            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(int Id, BautismoRequest bautismo)
        {
            if (!await VerificarBautismoExiste(Id))
                return NotFound("El bautismo no existe");

            var resultado = await _bautismoFlujo.Editar(Id, bautismo);

            return Ok(resultado);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            if (!await VerificarBautismoExiste(Id))
                return NotFound("El bautismo no existe");

            var resultado = await _bautismoFlujo.Eliminar(Id);

            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _bautismoFlujo.Obtener();

            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var resultado = await _bautismoFlujo.Obtener(Id);

            if (resultado == null)
                return NotFound("El bautismo no existe");

            return Ok(resultado);
        }

        #endregion

        #region Helpers

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
