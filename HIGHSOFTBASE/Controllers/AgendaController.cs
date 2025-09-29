using HIGHSOFTBASE.Data;
using HIGHSOFTBASE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // ============================
        // 📌 Vista principal con calendario + cards
        // ============================
        public async Task<IActionResult> Index()
        {
            ViewBag.Servicios = await _context.Servicios.ToListAsync();
            ViewBag.Clientes = await _context.Clientes.ToListAsync();

            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Servicio)
                .ToListAsync();

            return View(citas);
        }

        // ============================
        // 📌 Guardar nueva cita desde modal
        // ============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cita cita, string clienteNombre)
        {
            if (ModelState.IsValid)
            {
                // Buscar cliente, si no existe lo crea
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Nombre == clienteNombre);

                if (cliente == null)
                {
                    cliente = new Cliente { Nombre = clienteNombre };
                    _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();
                }

                cita.ClienteId = cliente.Id;

                _context.Citas.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // recarga combos si falla validación
            ViewBag.Servicios = await _context.Servicios.ToListAsync();
            ViewBag.Clientes = await _context.Clientes.ToListAsync();
            return View("Index", await _context.Citas.Include(c => c.Servicio).Include(c => c.Cliente).ToListAsync());
        }
    }
}
