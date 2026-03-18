/* Resumencito de este código: 
        
        Define un contrato del API
        Usa IActionResult porque es HTTP
        Usa Task porque es async
        Usa PersonaRequest para entrada
        Define CRUD completo

IPersonaController es una interfaz ubicada en la capa de abstracciones que define el contrato 
que debe implementar el controller de Persona. Contiene los métodos CRUD (obtener, 
agregar, editar y eliminar), devuelve IActionResult porque maneja respuestas HTTP, 
y usa Task para soportar operaciones asíncronas dentro de la arquitectura limpia.

OJO: CAPA API RETORNA IActionResult
*/

using Abstracciones.Modelos; // Importa los modelos (PersonaRequest, etc.) que se usan como parámetros
using Microsoft.AspNetCore.Mvc; // Importa IActionResult para manejar respuestas HTTP del API

namespace Abstracciones.Interfaces.API // Define el namespace dentro de la capa de Abstracciones (CORE)
{
    // Interfaz (contrato) que define lo que debe implementar el Controller de Persona
    public interface IPersonaController
    {
        // Método para obtener TODAS las personas
        // Task = ejecución asíncrona (no bloquea el hilo)
        // IActionResult = respuesta HTTP (200, 204, etc.)
        Task<IActionResult> Obtener();

        // Método para obtener UNA persona por su Id
        // Recibe el Id como parámetro
        // Devuelve IActionResult (200 OK o 404 NotFound)
        Task<IActionResult> Obtener(int Id);

        // Método para agregar una nueva persona
        // Recibe un objeto PersonaRequest (datos enviados desde el cliente)
        // Devuelve IActionResult (normalmente 201 Created)
        Task<IActionResult> Agregar(PersonaRequest persona);

        // Método para editar una persona existente
        // Recibe:
        // - Id: identifica qué persona editar
        // - persona: nuevos datos
        // Devuelve IActionResult (200 OK o 404 si no existe)
        Task<IActionResult> Editar(int Id, PersonaRequest persona);

        // Método para eliminar una persona
        // Recibe el Id de la persona a eliminar
        // Devuelve IActionResult (normalmente 204 NoContent)
        Task<IActionResult> Eliminar(int Id);
    }
}