using HIGHSOFTBASE.Data;
using HIGHSOFTBASE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HIGHSOFTBASE.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = new Dashboard
            {
                TotalVentas = await _context.Ventas.CountAsync(),
                TotalEmpleados = await _context.Empleados.CountAsync(),
                TotalUsuarios = await _context.Usuarios.CountAsync(),
                VentasTotales = await _context.Ventas.SumAsync(v => (decimal?)v.Precio) ?? 0
            };

            return View(dashboard);
        }
    }
}
