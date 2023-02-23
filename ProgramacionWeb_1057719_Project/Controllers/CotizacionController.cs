using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramacionWeb_1057719_Project.Models;

namespace ProgramacionWeb_1057719_Project.Controllers
{
    public class CotizacionController : Controller
    {
        private readonly DbBolsassiguereContext _dbbolsassiguere = new DbBolsassiguereContext();
        public async Task<IActionResult> Index()
        {
            return View(await _dbbolsassiguere.Cotizacions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbbolsassiguere.Cotizacions == null)
            {
                return NotFound();
            }

            var cotizacion = await _dbbolsassiguere.Cotizacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string correoCliente, string telefonoCliente)
        {
            DbBolsassiguereContext _dbbolsassiguere = new DbBolsassiguereContext();
            Models.Cotizacion cotizacion = new Models.Cotizacion
            {
                CorreoCliente = correoCliente,
                TelefonoCliente = telefonoCliente,
                FechaCotizacion = DateTime.Now,
            };
            _dbbolsassiguere.Cotizacions.Add(cotizacion);
            _dbbolsassiguere.SaveChanges();
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbbolsassiguere.Cotizacions == null)
            {
                return NotFound();
            }

            var cotizacion = await _dbbolsassiguere.Cotizacions.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            return View(cotizacion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string correoCliente, string telefonoCliente)
        {
            DbBolsassiguereContext _dbbolsassiguere = new DbBolsassiguereContext();
            Models.Cotizacion cotizacion = new Models.Cotizacion
            {
                Id = id,
                CorreoCliente = correoCliente,
                TelefonoCliente = telefonoCliente,
                FechaCotizacion = DateTime.Now,
            };
            _dbbolsassiguere.Cotizacions.Update(cotizacion);
            _dbbolsassiguere.SaveChanges();
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbbolsassiguere.Cotizacions == null)
            {
                return NotFound();
            }

            var cotizacion = await _dbbolsassiguere.Cotizacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbbolsassiguere.Cotizacions == null)
            {
                return Problem("Entity set Cotizacion is null.");
            }
            var cotizacion = await _dbbolsassiguere.Cotizacions.FindAsync(id);
            if (cotizacion != null)
            {
                _dbbolsassiguere.Cotizacions.Remove(cotizacion);
            }

            await _dbbolsassiguere.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
