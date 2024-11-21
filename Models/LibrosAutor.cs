using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDFABIOCHOAEF.Models
{
    public partial class LibrosAutor
    {
        public int Idlibrosautor { get; set; }

        // valida que el id del autor sea obligatorio
        [Required(ErrorMessage = "El ID del autor es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del autor debe ser un número positivo.")]
        public int? Idautor { get; set; }

        // valida que el Isbn del libro sea obligatorio
        [Required(ErrorMessage = "El ISBN del libro es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ISBN debe ser un número positivo.")]
        public int? Isbn { get; set; }

        public virtual Autor? IdautorNavigation { get; set; }

        public virtual Libro? IsbnNavigation { get; set; }
    }
}
