using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models.RoleViewModel
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Rellene el campo con un rol")]
        [Display(Name = "Nombre Rol")]
        public string RoleName { get; set; }
    }
}
