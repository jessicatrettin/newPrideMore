using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Models.ViewModels
{
    public class ProfessionalTypeFormViewModel
    {
        public List<Professional> Professionals { get; set; }
        public SelectList ProfessionalTypes { get; set; }
        public ProfessionalType Specialist { get; set; }
        public string SearchSpeciality { get; set; }
    }
}
