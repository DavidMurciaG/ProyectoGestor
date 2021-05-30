using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestor.Models
{
    public class Client
    {
        //Propiedades
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Nombre debe ser rellenado")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido debe ser rellenado")]
        [DisplayName("Apellido")]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Correo")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [DisplayName("Número de Teléfono")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string CIF { get; set; }

        [DisplayName("Dirección")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Seleccione una localidad.")]
        [DisplayName("Localidad")]
        public int LocalityID { get; set; }

        public string FullName
        {
            get
            {
                return Name + " " + LastName;
            }
        }

        //Propiedades de navegación
        public Locality Locality { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
