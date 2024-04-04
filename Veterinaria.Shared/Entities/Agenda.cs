using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Shared.Entities
{
    public class Agenda
    {
        //El id representa la primary key y la autoincrementación 
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }


        //Este campo se creo para saber las citas disponibles que 
        //existen dentro de la agenda
        [Display (Name= "Is Available")]
        public bool IsAvailable { get; set; }
        

        //las relaciones siempre se ponen al final de la entidad
        public Owner Owners { get; set; }
        public Pet Pets { get; set; }
        
        
    }
}
