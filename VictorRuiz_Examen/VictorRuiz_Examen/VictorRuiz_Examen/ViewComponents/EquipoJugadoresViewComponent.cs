using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictorRuiz_Examen.Models;

namespace VictorRuiz_Examen.ViewComponents
{
    public class EquipoJugadoresViewComponent : ViewComponent
    {
        private readonly FutbolContext _context;

        public EquipoJugadoresViewComponent(FutbolContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.Equipos
                .Select(e => new
                {
                    e.NomEquipo,
                    NumJugadores = e.Jugadores.Count()
                })
                .ToListAsync();

            return View(data);
        }
    }
}
