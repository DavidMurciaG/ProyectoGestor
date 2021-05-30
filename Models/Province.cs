using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class Province
    {
        //Propiedades
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo nombre debe ser rellando")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Name { get; set; }

        //Propiedades de navegación
        public ICollection<Locality> Localities { get; set; }
    }
}
