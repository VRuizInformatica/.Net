using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VictorRuiz_Examen.Models;

namespace VictorRuiz_Examen.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly FutbolContext _context;

        public JugadoresController(FutbolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? equipoId)
        {
            var equipos = await _context.Equipos.ToListAsync();
            ViewBag.Equipos = new SelectList(equipos, "Id", "NomEquipo");

            var jugadoresQuery = _context.Jugadores.Include(j => j.Equipo).AsQueryable();

            if (equipoId.HasValue && equipoId > 0)
            {
                jugadoresQuery = jugadoresQuery.Where(j => j.EquipoId == equipoId);
            }

            var jugadores = await jugadoresQuery.ToListAsync();
            return View(jugadores);
        }
    }
}
