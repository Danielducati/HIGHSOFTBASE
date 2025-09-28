using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HIGHSOFT.Models;
using HIGHSOFTBASE.Data;

namespace HIGHSOFTBASE.Controllers
{
    public class CategoriaServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaServicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaServicios.ToListAsync());
        }

        // GET: CategoriaServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }

            return View(categoriaServicio);
        }

        // GET: CategoriaServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Estado")] CategoriaServicio categoriaServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaServicio);
        }

        // GET: CategoriaServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios.FindAsync(id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }
            return View(categoriaServicio);
        }

        // POST: CategoriaServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Estado")] CategoriaServicio categoriaServicio)
        {
            if (id != categoriaServicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaServicioExists(categoriaServicio.Id))
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
            return View(categoriaServicio);
        }

        // GET: CategoriaServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }

            return View(categoriaServicio);
        }

        // POST: CategoriaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaServicio = await _context.CategoriaServicios.FindAsync(id);
            if (categoriaServicio != null)
            {
                _context.CategoriaServicios.Remove(categoriaServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaServicioExists(int id)
        {
            return _context.CategoriaServicios.Any(e => e.Id == id);
        }
    }
}
