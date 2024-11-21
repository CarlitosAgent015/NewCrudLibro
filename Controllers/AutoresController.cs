using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDFABIOCHOAEF.Models;

namespace CRUDFABIOCHOAEF.Controllers
{
    public class AutoresController : Controller
    {
        private readonly MiDbContext _context;

        public AutoresController(MiDbContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autors.ToListAsync());
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors
                .FirstOrDefaultAsync(m => m.Idautor == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idautor,Nombre,Apellido,Nacionalidad")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idautor,Nombre,Apellido,Nacionalidad")] Autor autor)
        {
            if (id != autor.Idautor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Idautor))
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
            return View(autor);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autors
                .FirstOrDefaultAsync(m => m.Idautor == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Buscar el autor por su ID
            var autor = await _context.Autors.FindAsync(id);
            if (autor == null)
            {
                // Si no se encuentra el autor, devolver un mensaje de error
                return Json(new { success = false, errorMessage = "El autor no fue encontrado." });
            }

            
            // Verificar si el autor está relacionado en la tabla LibrosAutors
            bool tieneRelacion = await _context.LibrosAutors.AnyAsync(la => la.Idautor == id);

            if (tieneRelacion)
            {
                // Si está relacionado, no se puede eliminar
                return Json(new { success = false, errorMessage = "No se puede eliminar el autor porque está relacionado con otros registros." });
            }

            // Si no está relacionado, eliminamos el autor
            _context.Autors.Remove(autor);
            await _context.SaveChangesAsync();

            // Si la eliminación es exitosa, devolver un mensaje de éxito
            return Json(new { success = true, message = "Autor eliminado correctamente." });
        }

        private bool AutorExists(int id)
        {
            return _context.Autors.Any(e => e.Idautor == id);
        }
    }
}
