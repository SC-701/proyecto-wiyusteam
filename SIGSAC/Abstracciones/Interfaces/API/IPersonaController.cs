using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IPersonaController
    {
        Task<IActionResult> Obtener();

        Task<IActionResult> Obtener(int Id);

        Task<IActionResult> Agregar(PersonaRequest persona);

        Task<IActionResult> Editar(int Id, PersonaRequest persona);

        Task<IActionResult> Eliminar(int Id);
    }
}
