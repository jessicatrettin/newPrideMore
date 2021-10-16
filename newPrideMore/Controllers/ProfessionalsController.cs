using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newPrideMore.Models;

namespace newPrideMore.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly newPrideMoreContext _context;

        public ProfessionalsController(newPrideMoreContext context)
        {
            _context = context;
        }

        // GET: Professionals
        public async Task<IActionResult> Index()
        {
            var newPrideMoreContext = _context.Professional.Include(p => p.ProfessionalType);
            return View(await newPrideMoreContext.ToListAsync());
        }

        // GET: Professionals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professional
                .Include(p => p.ProfessionalType)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // GET: Professionals/Create
        public IActionResult Create()
        {
            ViewData["ProfessionalTypeId"] = new SelectList(_context.ProfessionalType, "Id", "Id");
            return View();
        }

        // POST: Professionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Register,ProfessionalTypeId,Address,HealthInsurance,Email,Name,Cpf,Phone,Instagram,Password")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessionalTypeId"] = new SelectList(_context.ProfessionalType, "Id", "Id", professional.ProfessionalTypeId);
            return View(professional);
        }

        // GET: Professionals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professional.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }
            ViewData["ProfessionalTypeId"] = new SelectList(_context.ProfessionalType, "Id", "Id", professional.ProfessionalTypeId);
            return View(professional);
        }

        // POST: Professionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Register,ProfessionalTypeId,Address,HealthInsurance,Email,Name,Cpf,Phone,Instagram,Password")] Professional professional)
        {
            if (id != professional.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalExists(professional.Email))
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
            ViewData["ProfessionalTypeId"] = new SelectList(_context.ProfessionalType, "Id", "Id", professional.ProfessionalTypeId);
            return View(professional);
        }

        // GET: Professionals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = await _context.Professional
                .Include(p => p.ProfessionalType)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        // POST: Professionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var professional = await _context.Professional.FindAsync(id);
            _context.Professional.Remove(professional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalExists(string id)
        {
            return _context.Professional.Any(e => e.Email == id);
        }
    }
}
