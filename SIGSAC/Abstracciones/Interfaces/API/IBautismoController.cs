using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface  IBautismoController
    {
        Task<IActionResult> Obtener();

        Task<IActionResult> Obtener(int Id);

        Task<IActionResult> Agregar(BautismoRequest bautismo);

        Task<IActionResult> Editar(int Id, BautismoRequest bautismo);

        Task<IActionResult> Eliminar(int Id);

    }
}
