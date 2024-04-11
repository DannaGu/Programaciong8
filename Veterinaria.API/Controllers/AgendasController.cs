using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.Shared.Entities;

namespace Veterinaria.API.Controllers
{
    //se pone una etiqueta para identificar que tipo de controlador es
    [ApiController]
    [Route("/api/Agendas")]// por esa ruta va a salir el controlador de Agenda en el navegador
    public class AgendasController:ControllerBase
    {
        private readonly DataContext _context;

        public AgendasController(DataContext context)
        {
            _context = context;
        }

        // Se crea el CRUD
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Agendas.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult> Post(Agenda agenda)
        {
            _context.Add(agenda);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(agenda);
        }

        //metodo Get -por id  
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var agenda = await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);

            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda );

        }

        //Metodo de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Agenda agenda)
        {
            _context.Update(agenda);
            await _context.SaveChangesAsync();//salva el dato que yo registré
            return Ok(agenda);
        }


        //metodo para eliminar un registro de la entidad Agenda
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Agendas
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
