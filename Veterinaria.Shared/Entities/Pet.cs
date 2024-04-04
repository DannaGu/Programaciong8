using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.Shared.Entities
{
    public class Pet
    {
        public  int Id { get; set; }

        [Display(Name = "Nombre Mascota")]
        [MaxLength(50, ErrorMessage = "No se permiten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = "Foto Mascota")]
        public string ImageURL { get; set; }

        [Display(Name = "Raza")]
        [MaxLength(50, ErrorMessage = "No se permiten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Race { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd }", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        //se colocan las tablas con las que se relacionan Pet
        public Owner Owners { get; set; }
        public PetType PetTypes { get; set; }

        //Pet va a enviar su clave foranea a varias entidades

        [JsonIgnore]
        public ICollection<History>Histories { get; set; }

        [JsonIgnore]
        public ICollection<Agenda> Agendas { get; set; }
    }
}
