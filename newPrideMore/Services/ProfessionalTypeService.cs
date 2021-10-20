using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newPrideMore.Models;
using Microsoft.EntityFrameworkCore;

namespace newPrideMore.Services
{
    public class ProfessionalTypeService
    {
        private readonly newPrideMoreContext _context;

        public ProfessionalTypeService(newPrideMoreContext context)
        {
            _context = context;
        }

        public async Task<List<ProfessionalType>> FindAllAsync()
        {
            return await _context.ProfessionalType.OrderBy(x => x.Speciality).ToListAsync();
        }

        public List<ProfessionalType> FindProfission()
        {
            return _context.ProfessionalType.OrderBy(x => x.Speciality).ToList();
        }

        /*public bool HasAnySpeciality(string? speciality)
        {
            var speciality = _context.ProfessionalType
            if(!string.IsNullOrEmpty())
        }*/
    }
}
