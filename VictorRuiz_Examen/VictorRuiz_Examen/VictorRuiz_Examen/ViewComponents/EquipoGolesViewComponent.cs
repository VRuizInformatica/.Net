using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictorRuiz_Examen.Models;

namespace VictorRuiz_Examen.ViewComponents
{
    public class EquipoGolesViewComponent : ViewComponent
    {
        private readonly FutbolContext _context;

        public EquipoGolesViewComponent(FutbolContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.Equipos
                .Select(e => new
                {
                    e.NomEquipo,
                    TotalGoles = e.Jugadores.Sum(j => (int?)j.NumGoles) ?? 0
                })
                .ToListAsync();

            return View(data);
        }
    }
}
