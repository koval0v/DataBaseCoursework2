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
    public class CostElementsController : Controller
    {
        private readonly PlantsContext _context;

        public CostElementsController(PlantsContext context)
        {
            _context = context;
        }

        // GET: CostElements
        public async Task<IActionResult> Index()
        {
            return View(await _context.CostElements.ToListAsync());
        }

        // GET: CostElements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costElement = await _context.CostElements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costElement == null)
            {
                return NotFound();
            }

            return View(costElement);
        }

        // GET: CostElements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostElements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CostElement costElement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costElement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costElement);
        }

        // GET: CostElements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costElement = await _context.CostElements.FindAsync(id);
            if (costElement == null)
            {
                return NotFound();
            }
            return View(costElement);
        }

        // POST: CostElements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CostElement costElement)
        {
            if (id != costElement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costElement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostElementExists(costElement.Id))
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
            return View(costElement);
        }

        // GET: CostElements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costElement = await _context.CostElements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costElement == null)
            {
                return NotFound();
            }

            return View(costElement);
        }

        // POST: CostElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costElement = await _context.CostElements.FindAsync(id);
            _context.CostElements.Remove(costElement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostElementExists(int id)
        {
            return _context.CostElements.Any(e => e.Id == id);
        }
    }
}
