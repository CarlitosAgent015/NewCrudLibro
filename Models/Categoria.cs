using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDFABIOCHOAEF.Models
{
    public partial class Categoria
    {
        
        public int CodigoCategoria { get; set; }

        // Para validar que sea obligatorio  el campo Nombre
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? Nombre { get; set; }

        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
