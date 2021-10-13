using System.Collections.Generic;

namespace newPrideMore.Models.ViewModels
{
    public class ProfessionalFormViewModel
    {
        public Professional Professional { get; set; }
        public ICollection<ProfessionalType> ProfessionalTypes { get; set; }
    }
}
