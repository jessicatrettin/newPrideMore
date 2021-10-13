using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
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

        public ProfessionalsController(ProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }

        public IActionResult Index()
        {
            var list = _professionalService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
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
