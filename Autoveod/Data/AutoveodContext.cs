using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Autoveod.Models;

namespace Autoveod.Data
{
    public class AutoveodContext : DbContext
    {
        public AutoveodContext (DbContextOptions<AutoveodContext> options)
            : base(options)
        {
        }

        public DbSet<Autoveod.Models.Veod> Veod { get; set; }
    }
}
