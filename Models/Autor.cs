using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDFABIOCHOAEF.Models
{
    public partial class Autor
    {
        public int Idautor { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")] // Valida que no sea nulo o vacío
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")] // Limita la longitud
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
        [StringLength(30, ErrorMessage = "La nacionalidad no puede exceder los 30 caracteres.")]
        public string? Nacionalidad { get; set; }

        // Relación con LibrosAutor
        public virtual ICollection<LibrosAutor> LibrosAutors { get; set; } = new List<LibrosAutor>();
    }
}
