using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class Invoice
    {
        //Propiedades
        public int ID { get; set; }

        [Required(ErrorMessage = "Introduzca el número de factura")]
        [DisplayName("Número de factura")]
        [StringLength(10)]
        public string NumInvoice { get; set; }

        [Required(ErrorMessage = "Introduzca el coste de la factura")]
        [DisplayName("Coste")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public float Cost { get; set; }

        [DisplayName("Pagada")]
        public bool IsPaid { get; set; }

        [Required(ErrorMessage = "Seleccione un pedido")]
        [DisplayName("Pedido")]
        public int OrderID { get; set; }

        //Propiedades de navegación
        public Order Order { get; set; }
    }
}
