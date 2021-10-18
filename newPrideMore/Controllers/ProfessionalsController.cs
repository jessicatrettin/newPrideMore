using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
using newPrideMore.Models.ViewModels;
using newPrideMore.Services;
using newPrideMore.Services.Exeptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace newPrideMore.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly ProfessionalService _professionalService;
        private readonly ProfessionalTypeService _professionalTypeService;

        public ProfessionalsController(ProfessionalService professionalService, ProfessionalTypeService professionalTypeService)
        {
            _professionalService = professionalService;
            _professionalTypeService = professionalTypeService;
        }

        // GET: Professional
        public async Task<IActionResult> Index()
        {
            var list = await _professionalService.FindAllAsync();
            return View(list);
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

        //// POST: Professional/Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    await _professionalService.RemoveAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

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

        // GET: Professional/Search
        public async Task<IActionResult> Search()
        {
                return View();
        }

        // GET: Professional/Search/ProfessionalSearch
        public async Task<IActionResult> ProfessionalSearch()
        {
            return View();
        }
    }
}
