using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class Product
    {
        //Variables
        public int ID { get; set; }

        [Required(ErrorMessage = "Introduzca un nombre.")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Introduzca un precio.")]
        [DisplayName("Precio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public float Price { get; set; }

        [DisplayName("Descripción")]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Categoría")]
        public int ProductCategoryID { get; set; }

        //Propiedades de navegación
        //public ICollection<Order> Orders { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
