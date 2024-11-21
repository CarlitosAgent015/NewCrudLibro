using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDFABIOCHOAEF.Models
{
    public partial class Editoriale
    {
        public int Nit { get; set; }

        // Validar que el nombre sea obligatorio
        [Required(ErrorMessage = "El nombre de la editorial es obligatorio.")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder los 200 caracteres.")]
        public string? Nombre { get; set; }

        // validar que el telefono sea obligatorio
        [Required(ErrorMessage = "El numero del telefono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres.")]
        public string? Telefono { get; set; }

        [StringLength(300, ErrorMessage = "La dirección no puede exceder los 300 caracteres.")]
        public string? Direccion { get; set; }

        // valida que el email sea obligatorio
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? Email { get; set; }

        [Url(ErrorMessage = "El sitio web no es válido.")]
        [StringLength(200, ErrorMessage = "El sitio web no puede exceder los 200 caracteres.")]
        public string? Sitioweb { get; set; }

        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
