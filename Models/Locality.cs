using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class Locality
    {
        //Propiedades
        public int ID { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        [StringLength(150)]
        public string Name { get; set; }

        [DisplayName("Provincia")]
        [Required(ErrorMessage = "Seleccione la provincia a la que pertenece la localidad")]
        public int ProvinceID { get; set; }

        //Propiedades de navegación
        public Province Province { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
