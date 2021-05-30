using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Data
{
    public class ApplicationUser : IdentityUser
    {
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
