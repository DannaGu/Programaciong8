using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Shared.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name ="Documento")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Documento { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {1} es obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "No se permiten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {2} es obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {3} es obligatorio")]
        [EmailAddress(ErrorMessage ="Digite un email válido")]
        public string Email { get; set; }
        public string FixedPhone { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }

        /*Interpolación de cadenas*/
        public string FullName => $"{FirstName}{LastName}";  


    }
}
