using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
using newPrideMore.Models.ViewModels;
using newPrideMore.Services;

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

        public IActionResult Delete(string? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var obj = _professionalService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }
        /*public IActionResult Details(int? id)
        {

        }*/
    }
}
