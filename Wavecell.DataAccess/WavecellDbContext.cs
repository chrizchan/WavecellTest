using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wavecell.Entities;


namespace Wavecell.DataAccess
{
    public class WavecellDbContext : DbContext
    {
        public WavecellDbContext()
            : base("name=Wavecell")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }
    }
}
