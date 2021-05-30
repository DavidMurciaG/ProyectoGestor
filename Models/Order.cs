using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Introduzca el número del pedido")]
        [DisplayName("Número de pedido")]
        [StringLength(10)]
        public string NumOrder { get; set; }

        [Required(ErrorMessage = "Introduzca la fecha")]
        [DisplayName("Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Seleccione el cliente")]
        [DisplayName("Cliente")]
        public int ClientID { get; set; }

        /*[Required(ErrorMessage = "Seleccione el producto")]
        [DisplayName("Producto")]
        public int ProductID { get; set; }*/

        //Propiedades de navegación
        public Client Client { get; set; }

        //public ICollection<Product> Products { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

        public Invoice Invoice { get; set; }
    }
}
