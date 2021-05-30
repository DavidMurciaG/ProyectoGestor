using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class OrderProduct
    {
        //Variables
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        //Propiedades de navegación
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
