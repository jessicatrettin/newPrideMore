using newPrideMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newPrideMore.Services
{
    public class ProfessionalService
    {
        private readonly newPrideMoreContext _context;

        public ProfessionalService(newPrideMoreContext context)
        {
            _context = context;
        }

        public List<Professional> FindAll()
        {
            return _context.Professional.ToList();
        }
        
        public void Insert(Professional obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public static implicit operator ProfessionalService(ProfessionalTypeService v)
        {
            throw new NotImplementedException();
        }
    }
}
