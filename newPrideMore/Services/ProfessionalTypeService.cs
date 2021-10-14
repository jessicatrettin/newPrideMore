using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newPrideMore.Models;

namespace newPrideMore.Services
{
    public class ProfessionalTypeService
    {
        private readonly newPrideMoreContext _context;

        public ProfessionalTypeService(newPrideMoreContext context)
        {
            _context = context;
        }

        public List<ProfessionalType> FindAll()
        {
            return _context.ProfessionalType.OrderBy(x => x.Profission).ToList();
        }

        public List<ProfessionalType> FindProfission()
        {
            return _context.ProfessionalType.OrderBy(x => x.Speciality).ToList();
        }
    }
}
