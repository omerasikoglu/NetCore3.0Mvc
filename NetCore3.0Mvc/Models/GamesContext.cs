using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore3._0Mvc.Models
{
    public class GamesContext:DbContext
    {

        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {

        }
        public DbSet<Games> GamesTable { get; set; }
        public DbSet<User> UserTable { get; set; }
    }

  
}
