using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class ProductCategory
    {
        //Variables
        public int ID { get; set; }

        [Required(ErrorMessage = "Introduzca el nombre de la categoría")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Category { get; set; }

        //Propiedades de navegación
        public ICollection<Product> Products { get; set; }
    }
}
