using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using newPrideMore.Services.Exeptions;

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

        //public Professional FindByProfessionalType(string professionalType)
        //{
        //    return _context.ProfessionalType.FirstOrDefault(obj => obj.Speciality == professionalType);
        //}
        public User FindById(string id)
        {
            return _context.Professional.Include(obj => obj.ProfessionalType).FirstOrDefault(obj => obj.Email == id);
        }

        public void Remove(string id)
        {
            var obj = _context.Professional.Find(id);
            _context.Professional.Remove(obj);
            _context.SaveChanges();
        }
        
        public void Update(Professional obj)
        {
            if (!_context.Professional.Any(x => x.Email == obj.Email))
            {
                throw new NotFoundException("Email não encontrado");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
