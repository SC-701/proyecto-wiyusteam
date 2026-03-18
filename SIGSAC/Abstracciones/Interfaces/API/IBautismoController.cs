/* Resumencito de este código: 
        
        Define un contrato del API para Bautismo
        Usa IActionResult porque maneja respuestas HTTP
        Usa Task porque todas las operaciones son async
        Usa BautismoRequest para entrada de datos
        Define CRUD completo

IBautismoController es una interfaz ubicada en la capa de abstracciones que define el contrato 
que debe implementar el controller de Bautismo. Contiene los métodos CRUD (obtener, 
agregar, editar y eliminar), devuelve IActionResult porque maneja respuestas HTTP, 
y usa Task para soportar operaciones asíncronas dentro de la arquitectura limpia.

OJO: CAPA API RETORNA IActionResult
*/
using Abstracciones.Modelos; // Importa los modelos (BautismoRequest, etc.)
using Microsoft.AspNetCore.Mvc; // Importa IActionResult para respuestas HTTP

namespace Abstracciones.Interfaces.API // Namespace de la capa de Abstracciones (CORE)
{
    // Interfaz (contrato) que define lo que debe implementar el Controller de Bautismo
    public interface IBautismoController
    {
        // Método para obtener TODOS los registros de bautismo
        // Task = ejecución asíncrona
        // IActionResult = respuesta HTTP (200, 204, etc.)
        Task<IActionResult> Obtener();

        // Método para obtener UN registro de bautismo por Id
        // Recibe el Id como parámetro
        // Devuelve IActionResult (200 OK o 404 NotFound)
        Task<IActionResult> Obtener(int Id);

        // Método para agregar un nuevo bautismo
        // Recibe un objeto BautismoRequest (datos enviados desde el cliente)
        // Devuelve IActionResult (normalmente 201 Created)
        Task<IActionResult> Agregar(BautismoRequest bautismo);

        // Método para editar un bautismo existente
        // Recibe:
        // - Id: identifica qué registro editar
        // - bautismo: nuevos datos
        // Devuelve IActionResult (200 OK o 404 si no existe)
        Task<IActionResult> Editar(int Id, BautismoRequest bautismo);

        // Método para eliminar un bautismo
        // Recibe el Id del registro a eliminar
        // Devuelve IActionResult (normalmente 204 NoContent)
        Task<IActionResult> Eliminar(int Id);
    }
}
