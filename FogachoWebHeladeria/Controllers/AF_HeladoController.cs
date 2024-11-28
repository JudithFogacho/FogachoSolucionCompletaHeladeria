using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FogachoWebHeladeria;
using FogachoWebHeladeria.Models;

namespace FogachoWebHeladeria.Controllers
{
    public class AF_HeladoController : Controller
    {
        private readonly Data _context;

        public AF_HeladoController(Data context)
        {
            _context = context;
        }
        // GET: AF_Helado
        public async Task<IActionResult> Index()
        {
            return View(await _context.AF_Helado.ToListAsync());
        }

        // GET: AF_Helado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aF_Helado = await _context.AF_Helado
                .FirstOrDefaultAsync(m => m.AF_IdHeladeria == id);
            if (aF_Helado == null)
            {
                return NotFound();
            }

            return View(aF_Helado);
        }

        // GET: AF_Helado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AF_Helado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AF_IdHeladeria,AF_Nombre,AF_Sabor,AF_Categorias,AF_Precio,AF_Queso")] AF_Helado aF_Helado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aF_Helado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aF_Helado);
        }

        // GET: AF_Helado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aF_Helado = await _context.AF_Helado.FindAsync(id);
            if (aF_Helado == null)
            {
                return NotFound();
            }
            return View(aF_Helado);
        }

        // POST: AF_Helado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AF_IdHeladeria,AF_Nombre,AF_Sabor,AF_Categorias,AF_Precio,AF_Queso")] AF_Helado aF_Helado)
        {
            if (id != aF_Helado.AF_IdHeladeria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aF_Helado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AF_HeladoExists(aF_Helado.AF_IdHeladeria))
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
            return View(aF_Helado);
        }

        // GET: AF_Helado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aF_Helado = await _context.AF_Helado
                .FirstOrDefaultAsync(m => m.AF_IdHeladeria == id);
            if (aF_Helado == null)
            {
                return NotFound();
            }

            return View(aF_Helado);
        }

        // POST: AF_Helado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aF_Helado = await _context.AF_Helado.FindAsync(id);
            if (aF_Helado != null)
            {
                _context.AF_Helado.Remove(aF_Helado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AF_HeladoExists(int id)
        {
            return _context.AF_Helado.Any(e => e.AF_IdHeladeria == id);
        }
    }
}
