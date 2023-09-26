using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Domain;
using Microsoft.EntityFrameworkCore;


namespace PortfolioManager.Infrasrtructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
       : base(options)
        {
        }
        public DbSet<Competition> Competitions { get; set; } 
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Stage> Stages { get; set; }

    }
}
