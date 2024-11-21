using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDFABIOCHOAEF.Models
{
    public partial class Libro
    {
        
        public int Isbn { get; set; }

        
        // valida que el titulo sea obligatorio
        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres.")]
        public string? Titulo { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Descripcion { get; set; }

        // valida que el nombre del autor sea obligatorio
        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre del autor no puede exceder los 150 caracteres.")]
        public string? NombreAutor { get; set; }

        // valida que la fecha de publicacion sea obligatoria
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de publicación es obligatoria.")]
        public DateOnly? Publicacion { get; set; }

        // valida que la fecha de registro sea obligatoria
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
        public DateOnly? FechaRegistro { get; set; }

        // valida que el codigo de la categoria sea obligatorio
        [Required(ErrorMessage = "El código de categoría es obligatorio.")]
        public int? CodigoCategoria { get; set; }

        // valida que el nit de la editorial sea obligatorio
        [Required(ErrorMessage = "El NIT de la editorial es obligatorio.")]
        public int? NitEditorial { get; set; }

        public virtual Categoria? CodigoCategoriaNavigation { get; set; }

        public virtual ICollection<LibrosAutor> LibrosAutors { get; set; } = new List<LibrosAutor>();

        public virtual Editoriale? NitEditorialNavigation { get; set; }
    }
}
