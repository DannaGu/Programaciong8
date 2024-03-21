using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.Shared.Entities;

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

        //se crea el CRUD

        [HttpGet]//Etiqueta que me ayuda a identificar el metodo
        //siempre que se habra un async Task quiere decir que se está esperando una respuesta
        //metodo get que me devuelve la lista de los campos de Owners
        public async Task<ActionResult> Get() {
            return Ok(await _context.Owners.ToListAsync());
           
        }

        [HttpPost]
        public async Task<ActionResult> Post(Owner owner) { 
            _context.Add(owner);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(owner);
        }

        
        //metodo Get -por id  
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (owner == null) {
                return NotFound();
            }
            return Ok(owner);

        }

        //Metodo de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            _context.Update(owner);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(owner);
        }


        //metodo para eliminar un registro de la entidad Owners
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id) {
            var Filasafectadas = await _context.Owners
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
