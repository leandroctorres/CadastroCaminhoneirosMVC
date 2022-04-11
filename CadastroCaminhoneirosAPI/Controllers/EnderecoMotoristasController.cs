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
    public class EnderecoMotoristasController : ControllerBase
    {
        private readonly Context _context;

        public EnderecoMotoristasController(Context context)
        {
            _context = context;
        }

        // GET: api/EnderecoMotoristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoMotorista>>> GetEnderecoMotorista()
        {
            return await _context.EnderecoMotorista.Include("Motorista").ToListAsync();
        }

        // GET: api/EnderecoMotoristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoMotorista>> GetEnderecoMotorista(int id)
        {
            var enderecoMotorista = await _context.EnderecoMotorista.Include("Motorista").FirstOrDefaultAsync(x => x.Id == id);

            if (enderecoMotorista == null)
            {
                return NotFound();
            }

            return enderecoMotorista;
        }

        // PUT: api/EnderecoMotoristas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoMotorista(int id, EnderecoMotorista enderecoMotorista)
        {
            if (id != enderecoMotorista.Id)
            {
                return BadRequest();
            }

            //_context.Entry(enderecoMotorista).State = EntityState.Modified;
            _context.SetModified(enderecoMotorista);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoMotoristaExists(id))
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

        // POST: api/EnderecoMotoristas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnderecoMotorista>> PostEnderecoMotorista(EnderecoMotorista enderecoMotorista)
        {
            _context.EnderecoMotorista.Add(enderecoMotorista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoMotorista", new { id = enderecoMotorista.Id }, enderecoMotorista);
        }

        // DELETE: api/EnderecoMotoristas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoMotorista>> DeleteEnderecoMotorista(int id)
        {
            var enderecoMotorista = await _context.EnderecoMotorista.FindAsync(id);
            if (enderecoMotorista == null)
            {
                return NotFound();
            }

            _context.EnderecoMotorista.Remove(enderecoMotorista);
            await _context.SaveChangesAsync();

            return enderecoMotorista;
        }

        private bool EnderecoMotoristaExists(int id)
        {
            return _context.EnderecoMotorista.Any(e => e.Id == id);
        }
    }
}
