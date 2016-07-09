using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModuloComprasV._1._0.Models
{
    public class CuentaDeUsuario
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Falta el Nombre.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Falta el Apellido.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="Falta el usuario.")]
        public string usuario { get; set; }
        [Required(ErrorMessage ="Falta la contraseña.")]
        public string contraseña { get; set; }
        [Required(ErrorMessage ="Confirme su contraseña.")]
        public string ConfirmarContraseña { get; set; }

    }
}