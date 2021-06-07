using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSHogwartz.Dtos
{
    public class ApplicationDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]{1,20}$", ErrorMessage = "El nombre debe estar compuesto de sólo letras empezando por mayúsculas. Máximo 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]{1,20}$", ErrorMessage = "El apellido debe estar compuesto de sólo letras empezando por mayúsculas. Máximo 20 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La identificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "Ingrese una identificación válida. Máximo 10 dígitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "La identificación debe ser sólo números.")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [MaxLength(2, ErrorMessage = "Ingrese una edad válida. Máximo 2 dígitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "La edad debe ser sólo números.")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "La casa es obligatoria.")]
        [RegularExpression("Gryffindor|Hufflepuff|Ravenclaw|Slytherin", ErrorMessage = "Por favor ingrese un nombre de casa válido: Gryffindor, Hufflepuff, Ravenclaw, Slytherin.")]
        public string Casa { get; set; }
    }
}
