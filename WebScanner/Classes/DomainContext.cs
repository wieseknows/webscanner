using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScanner.Classes {
    class DomainContext : DbContext {
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}
