using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models.UserViewModel
{
    public class EditUserViewModel
    {

        public EditUserViewModel()
        {
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Usuario incorrecto")]
        [Display(Name = "Nombre de usuario")]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Administration")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El email debe ser rellenado.")]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Administration")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduce tu nombre")]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Introduce tu apellido")]
        [StringLength(20)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        public IList<string> Roles { get; set; }
    }
}
