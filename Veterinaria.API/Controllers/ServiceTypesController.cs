using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.Shared.Entities;

namespace Veterinaria.API.Controllers
{
    //se pone una etiqueta para identificar que tipo de controlador es
    [ApiController]
    [Route("/api/ServiceTypes")]// por esa ruta va a salir el controlador de ServiceType en el navegador
    public class ServiceTypesController: ControllerBase
    {
        private readonly DataContext _context;

        public ServiceTypesController(DataContext context)
        {
            _context = context;
        }

        // Se crea el CRUD
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ServiceTypes.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult> Post(ServiceType serviceType)
        {
            _context.Add(serviceType);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(serviceType);
        }

        //metodo Get -por id  
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var serviceType = await _context.PetTypes.FirstOrDefaultAsync(x => x.id == id);

            if (serviceType == null)
            {
                return NotFound();
            }
            return Ok(serviceType);

        }

        //Metodo de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(ServiceType serviceType)
        {
            _context.Update(serviceType);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(serviceType);
        }


        //metodo para eliminar un registro de la entidad ServiceType
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.ServiceTypes
                .Where(x => x.id == id).ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {
                return NotFound();
            }
            //204 sin contenido
            return NoContent();
        }


    }
}
