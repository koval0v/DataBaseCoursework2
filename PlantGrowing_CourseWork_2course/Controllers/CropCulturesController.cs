#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantGrowing_CourseWork_2course.Models;

namespace PlantGrowing_CourseWork_2course.Controllers
{
    public class CropCulturesController : Controller
    {
        private readonly PlantsContext _context;

        public CropCulturesController(PlantsContext context)
        {
            _context = context;
        }

        // GET: CropCultures
        public async Task<IActionResult> Index()
        {
            return View(await _context.CropCultures.ToListAsync());
        }

        // GET: CropCultures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropCulture = await _context.CropCultures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cropCulture == null)
            {
                return NotFound();
            }

            return View(cropCulture);
        }

        // GET: CropCultures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CropCultures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Income")] CropCulture cropCulture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cropCulture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cropCulture);
        }

        // GET: CropCultures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropCulture = await _context.CropCultures.FindAsync(id);
            if (cropCulture == null)
            {
                return NotFound();
            }
            return View(cropCulture);
        }

        // POST: CropCultures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Income")] CropCulture cropCulture)
        {
            if (id != cropCulture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cropCulture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropCultureExists(cropCulture.Id))
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
            return View(cropCulture);
        }

        // GET: CropCultures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropCulture = await _context.CropCultures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cropCulture == null)
            {
                return NotFound();
            }

            return View(cropCulture);
        }

        // POST: CropCultures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cropCulture = await _context.CropCultures.FindAsync(id);
            _context.CropCultures.Remove(cropCulture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CropCultureExists(int id)
        {
            return _context.CropCultures.Any(e => e.Id == id);
        }
    }
}
