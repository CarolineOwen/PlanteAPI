using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanteAPI.Models;
using System.Web.Http.Cors;

namespace PlanteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantesController : ControllerBase
    {

        private readonly PlanteApiContext _context;

        public PlantesController(PlanteApiContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<List<Plante>>> GetPlantes()
        {
            return await _context.Plantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plante>> GetPlanteById(int id)
        {
            var plante= await _context.Plantes.Where(p=>p.Id.Equals(id)).FirstOrDefaultAsync();
            if(plante == null)
            {
                return NotFound();
                
            }
            return plante;
        }

        [HttpPost]
        public async Task<ActionResult<Plante>> CreatePlante(Plante plante)
        {
            //valider les données
            _context.Plantes.Add(plante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreatePlante), plante);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Plante>> UpdatePlante(int id, Plante plante)
        {
            //trouver la plante
            var planteUpdate = await _context.Plantes.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            if (planteUpdate == null)
            {
                return NotFound();

            }
            plante.Name = planteUpdate.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlante(int id)
        {
            var plante = await _context.Plantes.FindAsync(id);
            if(plante == null)
            {
                return NotFound();
            }
            _context.Plantes.Remove(plante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
