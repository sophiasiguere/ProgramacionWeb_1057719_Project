using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramacionWeb_1057719_Project.Models;

namespace ProgramacionWeb_1057719_Project.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DbBolsassiguereContext _dbbolsassiguere = new DbBolsassiguereContext();

       

        public async Task<IActionResult> Index() 
        { 
            return View(await _dbbolsassiguere.Usuarios.ToListAsync()); 
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbbolsassiguere.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _dbbolsassiguere.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

            // GET: UsuarioController/Create
       public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string nombre, string usuario1, string correo, string telefono, string contrasena, int idRol)
        {
            DbBolsassiguereContext _dbbolsassiguere = new DbBolsassiguereContext();
            Models.Usuario usuario = new Models.Usuario
            {
                Nombre = nombre,
                Usuario1 = usuario1,
                Correo = correo,
                Telefono = telefono,
                Contrasena = contrasena,
                IdRol = idRol
            };
            _dbbolsassiguere.Usuarios.Add(usuario);
            _dbbolsassiguere.SaveChanges();
            return View();
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbbolsassiguere.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _dbbolsassiguere.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string nombre, string usuario1, string correo, string telefono, string contrasena, int idRol)
        {
            DbBolsassiguereContext _dbbolsassiguere = new DbBolsassiguereContext();
            Models.Usuario usuario = new Models.Usuario
            {
                Id= id,
                Nombre = nombre,
                Usuario1 = usuario1,
                Correo = correo,
                Telefono = telefono,
                Contrasena = contrasena,
                IdRol = idRol
            };
            _dbbolsassiguere.Usuarios.Update(usuario);
            _dbbolsassiguere.SaveChanges();
            return View();
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dbbolsassiguere.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _dbbolsassiguere.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbbolsassiguere.Usuarios == null)
            {
                return Problem("Entity set Usuarios is null.");
            }
            var usuario = await _dbbolsassiguere.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _dbbolsassiguere.Usuarios.Remove(usuario);
            }

            await _dbbolsassiguere.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
