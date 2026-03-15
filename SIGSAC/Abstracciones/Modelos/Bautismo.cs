using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class BautismoBase
    {
        [Required(ErrorMessage = "El bautizando es requerido")]
        public string? Bautizandoid { get; set; }
        
        [Required(ErrorMessage = "El padre del bautizando es requerido")]
        public string? Padreid { get; set; }

        [Required(ErrorMessage = "La madre del bautizando es requerido")]
        public string? Madreid { get; set; }

        [Required(ErrorMessage = "El tipo de unión es requerido")]
        [StringLength(50, ErrorMessage = "El tipo de unión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El tipo de unión solo puede contener letras")]
        public string? TipoUnion { get; set; }

        [Required(ErrorMessage = "La propiedad fecha de matrimonio es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaMatrimonio { get; set; }

        [Required(ErrorMessage = "El Abuelo paterno del bautizando es requerido")]
        public string? AbueloPaternoid { get; set; }

        [Required(ErrorMessage = "La Abuela paterna del bautizando es requerido")]
        public string? AbuelaPaternaid { get; set; }

        [Required(ErrorMessage = "El Abuelo materno del bautizando es requerido")]
        public string? AbueloMaternoid { get; set; }

        [Required(ErrorMessage = "La Abuela materna del bautizando es requerido")]
        public string? AbuelaMaternaid { get; set; }

        [Required(ErrorMessage = "El padrino del bautizando es requerido")]
        public string? Padrinoid { get; set; }

        [Required(ErrorMessage = "La madrina del bautizando es requerido")]
        public string? Madrinaid { get; set; }

        [Required(ErrorMessage = "El declarante del bautizando es requerido")]
        public string? Declaranteid { get; set; }


    }
    public class BautismoRequest : BautismoBase //Se usa cuando envías datos al API... está vacía porque BautismoRequest automáticamente hereda todas las propiedades de BautismoBase
    {
    }

    public class BautismoResponse : BautismoBase
    {
        public int Id { get; set; } // Se usa cuando el API devuelve información
    }

    public class BautismoDetalle : BautismoResponse // Se usa cuando quieres más información que la normal... sirve para agregar información extra cuando haces consultas más complejas
    {
    }

}
