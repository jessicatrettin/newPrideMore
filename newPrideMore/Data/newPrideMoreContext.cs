using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newPrideMore.Models;

    public class newPrideMoreContext : DbContext
    {
        public newPrideMoreContext (DbContextOptions<newPrideMoreContext> options)
            : base(options)
        {
        }

        public DbSet<newPrideMore.Models.ProfessionalType> ProfessionalType { get; set; }
    }
