using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class PersonaBase // clase base tiene todos los campos
    {
        [Required(ErrorMessage = "La propiedad nombre es requerida")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad primer apellido es requerida")]
        [StringLength(50, ErrorMessage = "El primer apellido debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo puede contener letras")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "La propiedad segundo apellido es requerida")]
        [StringLength(50, ErrorMessage = "El segundo apellido debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo puede contener letras")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "La propiedad cédula es requerida")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "La cédula debe tener 9 números")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "La propiedad pasaporte es requerida")]
        [StringLength(20, ErrorMessage = "El pasaporte debe tener entre 3 y 20 caracteres", MinimumLength = 3)]
        public string Pasaporte { get; set; }

        [Required(ErrorMessage = "La propiedad sexo es requerida")]
        [RegularExpression(@"^(Masculino|Femenino)$", ErrorMessage = "El sexo debe ser Masculino o Femenino")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "La propiedad fecha nacimiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La propiedad hora nacimiento es requerida")]
        [RegularExpression(@"^([01]\d|2[0-3]):([0-5]\d)$", ErrorMessage = "La hora debe tener formato HH:mm")]
        public string HoraNacimiento { get; set; }

        [Required(ErrorMessage = "La propiedad lugar nacimiento es requerida")]
        [StringLength(100, ErrorMessage = "El lugar de nacimiento debe tener entre 3 y 100 caracteres", MinimumLength = 3)]
        public string LugarNacimiento { get; set; }

        [Required(ErrorMessage = "La propiedad nacionalidad es requerida")]
        [StringLength(50, ErrorMessage = "La nacionalidad debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "La propiedad estado civil es requerida")]
        [RegularExpression(@"^(Soltero|Casado|Divorciado|Viudo|Soltera|Casada|Divorciada|Viuda)$", ErrorMessage = "Estado civil no válido")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "La propiedad profesión es requerida")]
        [StringLength(50, ErrorMessage = "La profesión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string Profesion { get; set; }

        [Required(ErrorMessage = "La propiedad religión es requerida")]
        [StringLength(50, ErrorMessage = "La religión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string Religion { get; set; }

        [Required(ErrorMessage = "La propiedad dirección es requerida")]
        [StringLength(200, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres", MinimumLength = 5)]
        public string Direccion { get; set; }
    }

    public class PersonaRequest : PersonaBase //Se usa cuando envías datos al API... está vacía porque PersonaRequest automáticamente hereda todas las propiedades de PersonaBase
    {
    }

    public class PersonaResponse : PersonaBase
    {
        public int Id { get; set; } // Se usa cuando el API devuelve información
    }

    public class PersonaDetalle : PersonaResponse // Se usa cuando quieres más información que la normal... sirve para agregar información extra cuando haces consultas más complejas
    {
    }
}