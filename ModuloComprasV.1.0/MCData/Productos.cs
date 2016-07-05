using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MCData
{
    public class Productos
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage ="Debe introducir un nombre para el producto.")]
        [Display(Description ="Nombre del Producto")]
        [StringLength(150, MinimumLength =4, ErrorMessage ="El nombre del producto debe ser mayor que {2} caracteres y menor que {1} caracteres.")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "Debe introducir una descripcion del producto.")]
        [Display(Description = "Descripcion")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "La descripción del producto debe ser mayor que {2} caracteres y menor que {1} caracteres.")]
        public string Descripcion { get; set; }
        [Range(1, 9999, ErrorMessage ="El {0} debe estar entre {1} y {2}.")]
        public decimal Precio { get; set; }
        [Range(1, 99, ErrorMessage = "La {0} debe estar entre {1} y {2}.")]
        public int Cantidad { get; set; }
    }
}
