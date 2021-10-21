using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newPrideMore.Models;

namespace newPrideMore.Controllers
{
    public class ProfessionalTypesController : Controller
    {
        private readonly newPrideMoreContext _context;

        public ProfessionalTypesController(newPrideMoreContext context)
        {
            _context = context;
        }

        // GET: ProfessionalTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfessionalType.ToListAsync());
        }

        // GET: ProfessionalTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalType = await _context.ProfessionalType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalType == null)
            {
                return NotFound();
            }

            return View(professionalType);
        }

        // GET: ProfessionalTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessionalTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Profission,Speciality")] ProfessionalType professionalType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professionalType);
        }

        // GET: ProfessionalTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalType = await _context.ProfessionalType.FindAsync(id);
            if (professionalType == null)
            {
                return NotFound();
            }
            return View(professionalType);
        }

        // POST: ProfessionalTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Profission,Speciality")] ProfessionalType professionalType)
        {
            if (id != professionalType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalTypeExists(professionalType.Id))
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
            return View(professionalType);
        }

        // GET: ProfessionalTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalType = await _context.ProfessionalType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalType == null)
            {
                return NotFound();
            }

            return View(professionalType);
        }

        // POST: ProfessionalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professionalType = await _context.ProfessionalType.FindAsync(id);
            _context.ProfessionalType.Remove(professionalType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalTypeExists(int id)
        {
            return _context.ProfessionalType.Any(e => e.Id == id);
        }
    }
}
