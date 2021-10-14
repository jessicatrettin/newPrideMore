using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
using newPrideMore.Models.ViewModels;
using newPrideMore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Controllers
{
    public class ProfessionalsController : Controller
    {

        private readonly ProfessionalService _professionalService;
        private readonly ProfessionalTypeService _professionaTypeService;

        public ProfessionalsController(ProfessionalService professionalService, ProfessionalTypeService professionalTypeService)
        {
            _professionalService = professionalService;
            _professionaTypeService = professionalTypeService;
        }

        public IActionResult Index()
        {
            var list = _professionalService.FindAll();
            return View(list);
        }

        public IActionResult FindProfessional()
        {
            var list = _professionalService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var professionalTypes = _professionaTypeService.FindAll();
            var viewModel = new ProfessionalFormViewModel { ProfessionalTypes = professionalTypes };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Professional professional)
        {
            _professionalService.Insert(professional);
            return RedirectToAction(nameof(Index));
        }
    }
}
