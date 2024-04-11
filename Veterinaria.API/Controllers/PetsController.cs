using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.Shared.Entities;

namespace Veterinaria.API.Controllers
{
    //se pone una etiqueta para identificar que tipo de controlador es
    [ApiController]
    [Route("/api/Pets")]// por esa ruta va a salir el controlador de Pet en el navegador
    public class PetsController: ControllerBase

    {
        private readonly DataContext _context;

        public PetsController(DataContext context)
        {
            _context = context;
        }

        // Se crea el CRUD
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Pets.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult> Post(Pet pet)
        {
            _context.Add(pet);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(pet);
        }

        //metodo Get -por id  
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);

        }

        //Metodo de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Pet pet)
        {
            _context.Update(pet);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(pet);
        }


        //metodo para eliminar un registro de la entidad pet
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Pets
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {
                return NotFound();
            }
            //204 sin contenido
            return NoContent();
        }

    }
}
