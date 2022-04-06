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
    public class CaminhaoMotoristasController : Controller
    {
        private readonly Context _context;

        public CaminhaoMotoristasController(Context context)
        {
            _context = context;
        }

        // GET: CaminhaoMotoristas
        public async Task<IActionResult> Index()
        {
            var context = _context.CaminhaoMotorista.Include(c => c.Motorista);
            return View(await context.ToListAsync());
        }

        // GET: CaminhaoMotoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhaoMotorista = await _context.CaminhaoMotorista
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caminhaoMotorista == null)
            {
                return NotFound();
            }

            return View(caminhaoMotorista);
        }

        // GET: CaminhaoMotoristas/Create
        public IActionResult Create()
        {
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome");
            return View();
        }

        // POST: CaminhaoMotoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Placa,Eixos,MotoristaId")] CaminhaoMotorista caminhaoMotorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caminhaoMotorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome", caminhaoMotorista.MotoristaId);
            return View(caminhaoMotorista);
        }

        // GET: CaminhaoMotoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhaoMotorista = await _context.CaminhaoMotorista.FindAsync(id);
            if (caminhaoMotorista == null)
            {
                return NotFound();
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome", caminhaoMotorista.MotoristaId);
            return View(caminhaoMotorista);
        }

        // POST: CaminhaoMotoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Placa,Eixos,MotoristaId")] CaminhaoMotorista caminhaoMotorista)
        {
            if (id != caminhaoMotorista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhaoMotorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoMotoristaExists(caminhaoMotorista.Id))
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
            ViewData["MotoristaId"] = new SelectList(_context.Motorista, "Id", "PrimeiroNome", caminhaoMotorista.MotoristaId);
            return View(caminhaoMotorista);
        }

        // GET: CaminhaoMotoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhaoMotorista = await _context.CaminhaoMotorista
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caminhaoMotorista == null)
            {
                return NotFound();
            }

            return View(caminhaoMotorista);
        }

        // POST: CaminhaoMotoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caminhaoMotorista = await _context.CaminhaoMotorista.FindAsync(id);
            _context.CaminhaoMotorista.Remove(caminhaoMotorista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoMotoristaExists(int id)
        {
            return _context.CaminhaoMotorista.Any(e => e.Id == id);
        }
    }
}
