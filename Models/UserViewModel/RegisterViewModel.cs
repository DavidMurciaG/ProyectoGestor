using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models.UserViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El email debe ser rellenado.")]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña incorrecta.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password",
            ErrorMessage = "Contraseña y repetir contraseña no coinciden")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Introduce tu nombre")]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Introduce tu apellido")]
        [StringLength(20)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
    }
}
