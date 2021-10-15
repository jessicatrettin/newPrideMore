using newPrideMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //public Professional FindByProfessionalType(string professionalType)
        //{
        //    return _context.ProfessionalType.FirstOrDefault(obj => obj.Speciality == professionalType);
        //}
        public User FindById(string id)
        {
            return _context.Professional.FirstOrDefault(obj => obj.Email == id);
        }

        public void Remove(string id)
        {
            var obj = _context.Professional.Find(id);
            _context.Professional.Remove(obj);
            _context.SaveChanges();
        }
    }
}
