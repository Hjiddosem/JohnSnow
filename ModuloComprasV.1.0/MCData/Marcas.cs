using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MCData
{
    public class Marcas
    {
        public int IdMarca { get; set; }
        [Required(ErrorMessage = "Debe introducir un nombre para la marca.")]
        [Display(Description = "Nombre de la Marca")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "El nombre de la marca debe ser mayor que {2} caracteres y menor que {1} caracteres.")]
        public string NombreMarca { get; set; }
        public int RNC { get; set; }
        public string Estado { get; set; }
    }
}
