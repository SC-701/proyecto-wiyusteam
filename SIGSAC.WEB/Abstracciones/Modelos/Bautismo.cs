/* Resumencito de este código: 
 
        BautismoBase → datos + validaciones
        BautismoRequest → entrada
        BautismoResponse → salida + Id
        BautismoDetalle → más información (incluye nombres relacionados)
        DataAnnotations → validación automática
 
Se usa una clase base para centralizar propiedades comunes y aplicar herencia
Se usa para evitar repetir código

En este caso Bautismo maneja muchas relaciones (personas relacionadas),
por eso en Detalle se agregan nombres adicionales

*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Validaciones (Required, StringLength, etc.)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos // Namespace de modelos dentro del CORE
{
    // Clase base con TODAS las propiedades del bautismo
    public class BautismoBase
    {
        // IDs de las personas relacionadas (relaciones con otras tablas)

        [Required(ErrorMessage = "El bautizando es requerido")]
        public int? BautizandoId { get; set; }

        [Required(ErrorMessage = "El padre del bautizando es requerido")]
        public int? PadreId { get; set; }

        [Required(ErrorMessage = "La madre del bautizando es requerido")]
        public int? MadreId { get; set; }

        // Tipo de unión de los padres (texto validado)
        [Required(ErrorMessage = "El tipo de unión es requerido")]
        [StringLength(50, ErrorMessage = "El tipo de unión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El tipo de unión solo puede contener letras")]
        public string? TipoUnionPadres { get; set; }

        // Fecha de matrimonio
        [Required(ErrorMessage = "La propiedad fecha de matrimonio es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaMatrimonioPadres { get; set; }

        // Abuelos paternos
        [Required(ErrorMessage = "El Abuelo paterno del bautizando es requerido")]
        public int? AbueloPaternoId { get; set; }

        [Required(ErrorMessage = "La Abuela paterna del bautizando es requerido")]
        public int? AbuelaPaternaId { get; set; }

        // Abuelos maternos
        [Required(ErrorMessage = "El Abuelo materno del bautizando es requerido")]
        public int? AbueloMaternoId { get; set; }

        [Required(ErrorMessage = "La Abuela materna del bautizando es requerido")]
        public int? AbuelaMaternaId { get; set; }

        // Padrinos
        [Required(ErrorMessage = "El padrino del bautizando es requerido")]
        public int? PadrinoId { get; set; }

        [Required(ErrorMessage = "La madrina del bautizando es requerido")]
        public int? MadrinaId { get; set; }

        // Persona que declara
        [Required(ErrorMessage = "El declarante del bautizando es requerido")]
        public int? DeclaranteId { get; set; }
    }

    // Clase para ENTRADA de datos (POST / PUT)
    // Hereda TODAS las propiedades de BautismoBase
    public class BautismoRequest : BautismoBase
    {
        // No agrega nada, reutiliza todo
    }

    // Clase para SALIDA básica (GET)
    public class BautismoResponse : BautismoBase
    {
        public int Id { get; set; } // Id generado en la base de datos
    }

    // Clase para SALIDA DETALLADA
    // Incluye nombres además de IDs (JOIN con otras tablas)
    public class BautismoDetalle : BautismoResponse
    {
        // Información adicional (no solo IDs, sino nombres)

        public string? BautizandoNombre { get; set; }
        public string? PadreNombre { get; set; }
        public string? MadreNombre { get; set; }
        public string? AbueloPaternoNombre { get; set; }
        public string? AbuelaPaternaNombre { get; set; }
        public string? AbueloMaternoNombre { get; set; }
        public string? AbuelaMaternaNombre { get; set; }

        public string? PadrinoNombre { get; set; }
        public string? MadrinaNombre { get; set; }
        public string? DeclaranteNombre { get; set; }
    }
}