using Microsoft.AspNetCore.Mvc;
using newPrideMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using newPrideMore.Services.Exeptions;
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

        public async Task<List<Professional>> FindAllAsync( )
        {
            return await _context.Professional.ToListAsync();
        }
        
        public async Task InsertAsync(Professional obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _context.Professional.Include(obj => obj.ProfessionalType).FirstOrDefaultAsync(obj => obj.Email == id);
        }

        public async Task RemoveAsync(string id)
        {
            var obj = await _context.Professional.FindAsync(id);
            _context.Professional.Remove(obj);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Professional obj)
        {
            bool hasAny = await _context.Professional.AnyAsync(x => x.Email == obj.Email);
            if (!hasAny)
            {
                throw new NotFoundException("Email não encontrado");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
