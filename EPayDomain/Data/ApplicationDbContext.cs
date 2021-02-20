using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayDomain.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<EPayDomain.Entities.Payment> Payment { get; set; }
            public DbSet<EPayDomain.Entities.PaymentTransaction> PaymentTransaction { get; set; }
    }

    
}
