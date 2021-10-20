using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newPrideMore.Models;
using newPrideMore.Models.ViewModels;
using newPrideMore.Services;
using newPrideMore.Services.Exeptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly ProfessionalService _professionalService;
        private readonly ProfessionalTypeService _professionalTypeService;
        private readonly newPrideMoreContext _context;

        public ProfessionalsController(ProfessionalService professionalService, ProfessionalTypeService professionalTypeService, newPrideMoreContext context)
        {
            _professionalService = professionalService;
            _professionalTypeService = professionalTypeService;
            _context = context;
        }


        // GET: Professional

        public async Task<IActionResult> Index(ProfessionalType specialist, string searchSpeciality)
        {
            IQueryable<ProfessionalType> professionalTypeQuery = from p in _context.Professional
                                                                 orderby p.ProfessionalType
                                                                 select p.ProfessionalType;

            var professional = from p in _context.Professional
                               select p;

            if (!string.IsNullOrEmpty(searchSpeciality))
            {
                professional = professional.Where(s => s.Name.Contains(searchSpeciality));
            }

            /*if (ProfessionalType.ProfessionalIsNullOrEmpty(specialist))
            { 
                professional = professional.Where(x => x.ProfessionalType == specialist);
            }*/

            var profissionalTypeVM = new ProfessionalTypeFormViewModel
            {
                ProfessionalTypes = new SelectList(await professionalTypeQuery.ToListAsync()),
                Professionals = await professional.ToListAsync()
            };

            return View(profissionalTypeVM);
        }

        // GET: ProfessionalTypes/Create
        public async Task<IActionResult> Create()
        {
            var professionalTypes = await _professionalTypeService.FindAllAsync();
            var viewModel = new ProfessionalFormViewModel { ProfessionalTypes = professionalTypes };
            return View(viewModel);
        }

        // POST: ProfessionalTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professional professional)
        {
            await _professionalService.InsertAsync(professional);
            return RedirectToAction(nameof(Index));
        }

        // GET: Professional/Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _professionalService.FindByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        /*// POST: Professional/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id) 
        {
            await _professionalService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }*/

        // GET: Professionals/Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _professionalService.FindByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Professionals/Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _professionalService.FindByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            List<ProfessionalType> professionalTypes = await _professionalTypeService.FindAllAsync();
            ProfessionalFormViewModel viewModel = new ProfessionalFormViewModel { Professional = (Professional)obj, ProfessionalTypes = professionalTypes };
            return View(viewModel);
        }

        // POST: Professionals/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Professional professional)
        {
            if (id != professional.Email)
            {
                return BadRequest();
            }

            try
            {
                await _professionalService.UpdateAsync(professional);
                return RedirectToAction(nameof(Index));
            }

            catch (NotFoundException)
            {
                return BadRequest();
            }
        }


        
    }
}
