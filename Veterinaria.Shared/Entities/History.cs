using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Shared.Entities
{
    public class History
    {
        public int id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 100 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString ="{0: yyyy/MM/dd  " +
            "HH:mm}",ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        //atributo que nos permite coger el tiempo que tiene el computardor
        
        public DateTime DateLocal=>Date.ToLocalTime();

        //relacionamos history con serviceType
        //se invoca el objeto completo
        public ServiceType ServiceTypes { get; set; }

        public Pet Pets{ get; set; }
    }
}
