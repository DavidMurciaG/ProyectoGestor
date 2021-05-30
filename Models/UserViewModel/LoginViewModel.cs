using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models.UserViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email incorrecto.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña incorrecta.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Mantenerse conectado")]
        public bool RememberMe { get; set; }
    }
}
