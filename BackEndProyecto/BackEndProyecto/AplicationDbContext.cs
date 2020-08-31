using BackEndProyecto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProyecto
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Proyecto> Proyecto { get; set; }

        public AplicationDbContext()
        {

        }

        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=AppProyecto;Uid=root;Pwd=adminivan");
            }
        }
    }
}
