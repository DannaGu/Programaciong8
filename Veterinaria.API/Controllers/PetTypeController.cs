using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.Shared.Entities;

namespace Veterinaria.API.Controllers
{
    //se pone una etiqueta para identificar que tipo de controlador es
    [ApiController]
    [Route("/api/PetTypes")]// por esa ruta va a salir el controlador de PetType en el navegador
    public class PetTypeController:ControllerBase
    {
        private readonly DataContext _context;

        public PetTypeController(DataContext context) {
            _context = context;
        }

        // Se crea el CRUD
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.PetTypes.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult> Post(PetType petType)
        {
            _context.Add(petType);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(petType);
        }

        //metodo Get -por id  
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var petType = await _context.PetTypes.FirstOrDefaultAsync(x => x.id == id);

            if (petType == null)
            {
                return NotFound();
            }
            return Ok(petType);

        }

        //Metodo de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(PetType petType)
        {
            _context.Update(petType);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(petType);
        }


        //metodo para eliminar un registro de la entidad petType
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.PetTypes
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
