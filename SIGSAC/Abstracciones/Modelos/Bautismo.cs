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
        public int? BautizandoId { get; set; }


        [Required(ErrorMessage = "El padre del bautizando es requerido")]
        public int? PadreId { get; set; }

        [Required(ErrorMessage = "La madre del bautizando es requerido")]
        public int? MadreId { get; set; }

        [Required(ErrorMessage = "El tipo de unión es requerido")]
        [StringLength(50, ErrorMessage = "El tipo de unión debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El tipo de unión solo puede contener letras")]
        public string? TipoUnionPadres { get; set; }

        [Required(ErrorMessage = "La propiedad fecha de matrimonio es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaMatrimonioPadres { get; set; }

        [Required(ErrorMessage = "El Abuelo paterno del bautizando es requerido")]
        public int? AbueloPaternoId { get; set; }

        [Required(ErrorMessage = "La Abuela paterna del bautizando es requerido")]
        public int? AbuelaPaternaId { get; set; }

        [Required(ErrorMessage = "El Abuelo materno del bautizando es requerido")]
        public int? AbueloMaternoId { get; set; }

        [Required(ErrorMessage = "La Abuela materna del bautizando es requerido")]
        public int? AbuelaMaternaId { get; set; }

        [Required(ErrorMessage = "El padrino del bautizando es requerido")]
        public int? PadrinoId { get; set; }

        [Required(ErrorMessage = "La madrina del bautizando es requerido")]
        public int? MadrinaId { get; set; }

        [Required(ErrorMessage = "El declarante del bautizando es requerido")]
        public int? DeclaranteId { get; set; }


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
