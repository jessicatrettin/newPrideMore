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

        public DbSet<ProfessionalType> ProfessionalType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
}
