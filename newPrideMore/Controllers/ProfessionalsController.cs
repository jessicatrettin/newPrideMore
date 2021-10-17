using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
using newPrideMore.Models.ViewModels;
using newPrideMore.Services;
using newPrideMore.Services.Exeptions;
using System.Collections.Generic;

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
        public IActionResult Index()
        {
            var list = _professionalService.FindAll();
            return View(list);
        }

        // GET: ProfessionalTypes/Create
        public IActionResult Create()
        {
            var professionalTypes = _professionalTypeService.FindAll();
            var viewModel = new ProfessionalFormViewModel { ProfessionalTypes = professionalTypes };
            return View(viewModel);
        }

        // POST: ProfessionalTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Professional professional)
        {
            _professionalService.Insert(professional);
            return RedirectToAction(nameof(Index));
        }

        // GET: Professional/Delete
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _professionalService.FindById(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //// POST: Professional/Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(string id)
        //{
        //    _professionalService.Remove(id);
        //    return RedirectToAction(nameof(Index));
        //}

        // GET: Professionals/Details
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _professionalService.FindById(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Professionals/Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _professionalService.FindById(id);
            if (obj == null)
            {
                return NotFound();
            }

            List<ProfessionalType> professionalTypes = _professionalTypeService.FindAll();
            ProfessionalFormViewModel viewModel = new ProfessionalFormViewModel { Professional = (Professional)obj, ProfessionalTypes = professionalTypes };
            return View(viewModel);
        }

        // POST: Professionals/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Professional professional)
        {
            if (id != professional.Email)
            {
                return BadRequest();
            }

            try
            {
                _professionalService.Update(professional);
                return RedirectToAction(nameof(Index));
            }

            catch (NotFoundException)
            {
                return BadRequest();
            }

        }

    }
}
