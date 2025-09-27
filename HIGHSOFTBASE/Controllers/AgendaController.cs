using HIGHSOFTBASE.Data;
using HIGHSOFTBASE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HIGHSOFTBASE.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard de agenda (lista y estadísticas)
        public async Task<IActionResult> Index()
        {
            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Servicio)
                .Include(c => c.Empleado)
                .ToListAsync();

            ViewBag.Total = citas.Count;
            ViewBag.Canceladas = citas.Count(c => c.Estado == EstadoCita.Cancelada);
            ViewBag.Cumplidas = citas.Count(c => c.Estado == EstadoCita.Cumplida);
            ViewBag.MasSolicitado = citas.GroupBy(c => c.Servicio.Nombre)
                                        .OrderByDescending(g => g.Count())
                                        .FirstOrDefault()?.Key;

            return View(citas);
        }

        // Crear nueva cita
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cita);
        }

        // Confirmaciones
        public async Task<IActionResult> Confirmaciones()
        {
            var pendientes = await _context.Citas
                .Where(c => c.Estado == EstadoCita.Pendiente)
                .Include(c => c.Cliente)
                .Include(c => c.Servicio)
                .ToListAsync();

            return View(pendientes);
        }

        public async Task<IActionResult> Aprobar(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                cita.Estado = EstadoCita.Programada;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Confirmaciones));
        }

        public async Task<IActionResult> Rechazar(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                cita.Estado = EstadoCita.Cancelada;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Confirmaciones));
        }

      
        // Obtener citas en formato JSON para el calendario
        public async Task<IActionResult> GetCitas()
        {
            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Servicio)
                .Include(c => c.Empleado)
                .ToListAsync();

            var eventos = citas.Select(c => new
            {
                id = c.Id,
                title = $"{c.Cliente.Nombre} - {c.Servicio.Nombre}",
                start = c.Fecha.ToString("s"),  // formato ISO
                end = c.Fecha.AddMinutes(c.Servicio.Duracion).ToString("s"),
                estado = c.Estado.ToString(),
                empleado = c.Empleado.Nombre
            });

            return Json(eventos);
        }

    }
}
