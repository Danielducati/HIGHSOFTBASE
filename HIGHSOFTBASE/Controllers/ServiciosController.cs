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
    public class ServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servicios
        public async Task<IActionResult> Index(int? categoriaId)
        {
            var query = _context.Servicios.Include(s => s.CategoriaServicio).AsQueryable();

            ViewBag.CategoriasFiltro = new SelectList(_context.CategoriaServicios.OrderBy(c => c.Nombre), "Id", "Nombre", categoriaId);

            if (categoriaId.HasValue)
                query = query.Where(s => s.CategoriaServicioId == categoriaId.Value);

            var lista = await query.OrderBy(s => s.Nombre).ToListAsync();
            return View(lista);
        }


        // GET: Servicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .Include(s => s.CategoriaServicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: Servicios/Create
        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_context.CategoriaServicios.OrderBy(c => c.Nombre).ToList(), "Id", "Nombre");
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,DuracionMinutos,CategoriaServicioId")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                servicio.Estado = "Activo";
                servicio.CreadoEn = DateTime.UtcNow;
                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = new SelectList(_context.CategoriaServicios.OrderBy(c => c.Nombre).ToList(), "Id", "Nombre", servicio.CategoriaServicioId);
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null) return NotFound();
            ViewBag.Categorias = new SelectList(_context.CategoriaServicios.OrderBy(c => c.Nombre).ToList(), "Id", "Nombre", servicio.CategoriaServicioId);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,DuracionMinutos,CategoriaServicioId,Estado,CreadoEn")] Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.Id))
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
            ViewData["CategoriaServicioId"] = new SelectList(_context.CategoriaServicios, "Id", "Nombre", servicio.CategoriaServicioId);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .Include(s => s.CategoriaServicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.Id == id);
        }
    }
}
