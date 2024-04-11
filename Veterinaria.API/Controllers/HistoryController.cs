using Microsoft.AspNetCore.Mvc;

namespace Veterinaria.API.Controllers
{
    //se pone una etiqueta para identificar que tipo de controlador es
    [ApiController]
    [Route("/api/Histories")]// por esa ruta va a salir el controlador de History en el navegador
    public class HistoryController:ControllerBase
    {
        
    }
}
