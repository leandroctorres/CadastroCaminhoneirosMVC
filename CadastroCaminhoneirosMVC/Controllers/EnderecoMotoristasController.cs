using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroCaminhoneirosMVC.Models;

namespace CadastroCaminhoneirosMVC.Controllers
{
    public class EnderecoMotoristasController : Controller
    {
        private readonly Context _context;

        public EnderecoMotoristasController(Context context)
        {
            _context = context;
        }

        // GET: EnderecoMotoristas
        public async Task<IActionResult> Index()
        {
            var context = _context.EnderecoMotorista.Include(e => e.Motorista);
            return View(await context.ToListAsync());
        }

        // GET: EnderecoMotoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoMotorista = await _context.EnderecoMotorista
                .Include(e => e.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoMotorista == null)
            {
                return NotFound();
            }

            return View(enderecoMotorista);
        }

        // GET: EnderecoMotoristas/Create
        public IActionResult Create()
        {
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome");
            return View();
        }

        // POST: EnderecoMotoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cep,Logradouro,Numero,Bairro,Cidade,Estado,MotoristaId")] EnderecoMotorista enderecoMotorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoMotorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome", enderecoMotorista.MotoristaId);
            return View(enderecoMotorista);
        }

        // GET: EnderecoMotoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoMotorista = await _context.EnderecoMotorista.FindAsync(id);
            if (enderecoMotorista == null)
            {
                return NotFound();
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome", enderecoMotorista.MotoristaId);
            return View(enderecoMotorista);
        }

        // POST: EnderecoMotoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cep,Logradouro,Numero,Bairro,Cidade,Estado,MotoristaId")] EnderecoMotorista enderecoMotorista)
        {
            if (id != enderecoMotorista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoMotorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoMotoristaExists(enderecoMotorista.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome", enderecoMotorista.MotoristaId);
            return View(enderecoMotorista);
        }

        // GET: EnderecoMotoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoMotorista = await _context.EnderecoMotorista
                .Include(e => e.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoMotorista == null)
            {
                return NotFound();
            }

            return View(enderecoMotorista);
        }

        // POST: EnderecoMotoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enderecoMotorista = await _context.EnderecoMotorista.FindAsync(id);
            _context.EnderecoMotorista.Remove(enderecoMotorista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoMotoristaExists(int id)
        {
            return _context.EnderecoMotorista.Any(e => e.Id == id);
        }
    }
}
