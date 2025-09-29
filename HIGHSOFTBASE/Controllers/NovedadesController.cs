using HIGHSOFTBASE.Data;
using HIGHSOFTBASE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace HIGHSOFTBASE.Controllers
{
    public class NovedadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NovedadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================
        // 📌 Vista principal con listado de novedades
        // ============================
        public async Task<IActionResult> Index()
        {
            var novedades = await _context.Novedades
                .Include(n => n.Empleado)
                .OrderByDescending(n => n.FechaHora)
                .ToListAsync();

            ViewBag.Empleados = new SelectList(_context.Empleados, "Id", "Nombre");
            return View(novedades);
        }

        // ============================
        // 📌 Crear nueva novedad
        // ============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                _context.Novedades.Add(novedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Empleados = new SelectList(_context.Empleados, "Id", "Nombre", novedad.EmpleadoId);
            return View("Index", await _context.Novedades.Include(n => n.Empleado).ToListAsync());
        }
    }
}
