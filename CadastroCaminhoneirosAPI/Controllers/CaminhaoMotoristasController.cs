using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCaminhoneirosMVC.Models;

namespace CadastroCaminhoneirosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminhaoMotoristasController : ControllerBase
    {
        private readonly Context _context;

        public CaminhaoMotoristasController(Context context)
        {
            _context = context;
        }

        // GET: api/CaminhaoMotoristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaminhaoMotorista>>> GetCaminhaoMotorista()
        {
            return await _context.CaminhaoMotorista.Include("Motorista").ToListAsync();
        }

        // GET: api/CaminhaoMotoristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaminhaoMotorista>> GetCaminhaoMotorista(int id)
        {
            var caminhaoMotorista = await _context.CaminhaoMotorista.Include("Motorista").FirstOrDefaultAsync(x => x.Id == id);

            if (caminhaoMotorista == null)
            {
                return NotFound();
            }

            return caminhaoMotorista;
        }

        // PUT: api/CaminhaoMotoristas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaminhaoMotorista(int id, CaminhaoMotorista caminhaoMotorista)
        {
            if (id != caminhaoMotorista.Id)
            {
                return BadRequest();
            }

            _context.Entry(caminhaoMotorista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaminhaoMotoristaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CaminhaoMotoristas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CaminhaoMotorista>> PostCaminhaoMotorista(CaminhaoMotorista caminhaoMotorista)
        {
            _context.CaminhaoMotorista.Add(caminhaoMotorista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaminhaoMotorista", new { id = caminhaoMotorista.Id }, caminhaoMotorista);
        }

        // DELETE: api/CaminhaoMotoristas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CaminhaoMotorista>> DeleteCaminhaoMotorista(int id)
        {
            var caminhaoMotorista = await _context.CaminhaoMotorista.FindAsync(id);
            if (caminhaoMotorista == null)
            {
                return NotFound();
            }

            _context.CaminhaoMotorista.Remove(caminhaoMotorista);
            await _context.SaveChangesAsync();

            return caminhaoMotorista;
        }

        private bool CaminhaoMotoristaExists(int id)
        {
            return _context.CaminhaoMotorista.Any(e => e.Id == id);
        }
    }
}
