/* Resumencito de este código: 
 
        PersonaBase → datos + validaciones
        PersonaRequest → entrada
        PersonaResponse → salida + Id
        PersonaDetalle → más información
        DataAnnotations → validación automática
 
Se usa una clase base para centralizar propiedades comunes y aplicar herencia
Se usa para evitar repetir código

*/

using System.ComponentModel.DataAnnotations; // Importa las validaciones (Required, StringLength, etc.)

namespace Abstracciones.Modelos // Namespace de modelos dentro del CORE (Abstracciones)
{
    // Clase base que contiene TODAS las propiedades comunes de Persona
    public class PersonaBase // clase base tiene todos los campos
    {
        // Campo Nombre
        // Required = obligatorio
        // StringLength = mínimo y máximo de caracteres
        // RegularExpression = solo letras
        [Required(ErrorMessage = "La propiedad nombre es requerida")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras")]
        public string Nombre { get; set; }

        // Primer Apellido con validaciones similares
        [Required(ErrorMessage = "La propiedad primer apellido es requerida")]
        [StringLength(50, ErrorMessage = "El primer apellido debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo puede contener letras")]
        public string PrimerApellido { get; set; }

        // Segundo Apellido
        [Required(ErrorMessage = "La propiedad segundo apellido es requerida")]
        [StringLength(50, ErrorMessage = "El segundo apellido debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo puede contener letras")]
        public string SegundoApellido { get; set; }

        // Cédula (exactamente 9 números)
        [Required(ErrorMessage = "La propiedad cédula es requerida")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "La cédula debe tener 9 números")]
        public string Cedula { get; set; }

        // Pasaporte
        [Required(ErrorMessage = "La propiedad pasaporte es requerida")]
        [StringLength(20, ErrorMessage = "El pasaporte debe tener entre 3 y 20 caracteres", MinimumLength = 3)]
        public string Pasaporte { get; set; }

        // Sexo (solo Masculino o Femenino)
        [Required(ErrorMessage = "La propiedad sexo es requerida")]
        [RegularExpression(@"^(Masculino|Femenino)$", ErrorMessage = "El sexo debe ser Masculino o Femenino")]
        public string Sexo { get; set; }

        // Fecha de nacimiento (tipo DateTime)
        [Required(ErrorMessage = "La propiedad fecha nacimiento es requerida")]
        [DataType(DataType.Date)] // Indica que es una fecha
        public DateTime FechaNacimiento { get; set; }

        // Hora de nacimiento (formato HH:mm)
        [Required(ErrorMessage = "La propiedad hora nacimiento es requerida")]
        [RegularExpression(@"^([01]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "La hora debe tener formato HH:mm")]
        public string HoraNacimiento { get; set; }

        // Lugar de nacimiento
        [Required(ErrorMessage = "La propiedad lugar nacimiento es requerida")]
        [StringLength(100, ErrorMessage = "El lugar de nacimiento debe tener entre 3 y 100 caracteres", MinimumLength = 3)]
        public string LugarNacimiento { get; set; }

        // Nacionalidad
        [Required(ErrorMessage = "La propiedad nacionalidad es requerida")]
        [StringLength(50, ErrorMessage = "La nacionalidad debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string Nacionalidad { get; set; }

        // Estado civil con valores permitidos
        [Required(ErrorMessage = "La propiedad estado civil es requerida")]
        [RegularExpression(@"^(Soltero|Casado|Divorciado|Viudo|Soltera|Casada|Divorciada|Viuda)$", ErrorMessage = "Estado civil no válido")]
        public string EstadoCivil { get; set; }

        // Profesión
        [Required(ErrorMessage = "La propiedad profesión es requerida")]
        [StringLength(50, ErrorMessage = "La profesión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string Profesion { get; set; }

        // Religión
        [Required(ErrorMessage = "La propiedad religión es requerida")]
        [StringLength(50, ErrorMessage = "La religión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string Religion { get; set; }

        // Dirección
        [Required(ErrorMessage = "La propiedad dirección es requerida")]
        [StringLength(200, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres", MinimumLength = 5)]
        public string Direccion { get; set; }
    }

    // Clase para ENTRADA de datos (POST / PUT)
    // Hereda TODAS las propiedades de PersonaBase
    public class PersonaRequest : PersonaBase
    {
        // No tiene propiedades propias
        // Solo reutiliza las de PersonaBase
    }

    // Clase para SALIDA de datos (GET)
    public class PersonaResponse : PersonaBase
    {
        // Se agrega el Id porque ya viene de la base de datos
        public int Id { get; set; } // Se usa cuando el API devuelve información
    }

    // Clase para respuestas más detalladas
    // Hereda de PersonaResponse (y por ende también de PersonaBase)
    public class PersonaDetalle : PersonaResponse
    {
        // Se puede extender con más propiedades si se necesitan
        // Ejemplo: historial, datos adicionales, etc.
    }
}