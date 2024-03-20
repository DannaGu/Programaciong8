using Microsoft.AspNetCore.Mvc;
using Veterinaria.API.Data;

namespace Veterinaria.API.Controllers
{
    //se pone una etiqueta para identificar que tipo de controlador es
    [ApiController]
    [Route ("/api/owners") ]// por esa ruta va a salir el controlador de owners en el navegador

    public class OwnersController: ControllerBase
    {
        //se arma un costructor y se mapea el objeto
        private readonly DataContext _context;

        // va a coger el datacontext, este controlador es necesario para cada 
        //controlador de cada entidad
        public OwnersController(DataContext context) { 
            
            //con esto se puede obtener todos los campos que hay en owners
            _context = context; 
        }

    }
}
