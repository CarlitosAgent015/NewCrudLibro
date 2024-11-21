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
    public class LibrosAutoresController : Controller
    {
        private readonly MiDbContext _context;

        public LibrosAutoresController(MiDbContext context)
        {
            _context = context;
        }

        // GET: LibrosAutores
        public async Task<IActionResult> Index()
        {
            var miDbContext = _context.LibrosAutors.Include(l => l.IdautorNavigation).Include(l => l.IsbnNavigation);
            return View(await miDbContext.ToListAsync());
        }

        // GET: LibrosAutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosAutor = await _context.LibrosAutors
                .Include(l => l.IdautorNavigation)
                .Include(l => l.IsbnNavigation)
                .FirstOrDefaultAsync(m => m.Idlibrosautor == id);
            if (librosAutor == null)
            {
                return NotFound();
            }

            return View(librosAutor);
        }

        // GET: LibrosAutores/Create
        public IActionResult Create()
        {
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor");
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn");
            return View();
        }

        // POST: LibrosAutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlibrosautor,Idautor,Isbn")] LibrosAutor librosAutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librosAutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", librosAutor.Idautor);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", librosAutor.Isbn);
            return View(librosAutor);
        }

        // GET: LibrosAutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosAutor = await _context.LibrosAutors.FindAsync(id);
            if (librosAutor == null)
            {
                return NotFound();
            }
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", librosAutor.Idautor);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", librosAutor.Isbn);
            return View(librosAutor);
        }

        // POST: LibrosAutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlibrosautor,Idautor,Isbn")] LibrosAutor librosAutor)
        {
            if (id != librosAutor.Idlibrosautor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librosAutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrosAutorExists(librosAutor.Idlibrosautor))
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
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", librosAutor.Idautor);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", librosAutor.Isbn);
            return View(librosAutor);
        }

        // GET: LibrosAutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosAutor = await _context.LibrosAutors
                .FirstOrDefaultAsync(m => m.Idlibrosautor == id);
            if (librosAutor == null)
            {
                return NotFound();
            }

            return View(librosAutor);
        }

        // POST: LibrosAutores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librosAutor = await _context.LibrosAutors.FindAsync(id);
            if (librosAutor == null)
            {
             // Si no se encuentra el autor, devolver un mensaje de error
            return Json(new { success = false, errorMessage = "El libro autor no fue encontrado." });
            }

            _context.LibrosAutors.Remove(librosAutor);
            await _context.SaveChangesAsync();
            // Si la eliminación es exitosa, devolver un mensaje de éxito
            return Json(new { success = true, message = "Libro Autor eliminado correctamente." });
        }

        private bool LibrosAutorExists(int id)
        {
            return _context.LibrosAutors.Any(e => e.Idlibrosautor == id);
        }
    }
}
