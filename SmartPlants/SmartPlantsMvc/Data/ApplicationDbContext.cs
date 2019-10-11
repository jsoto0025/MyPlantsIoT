using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPlantsMvc.Models;

namespace SmartPlantsMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Farm> Farms { get; set; }

        public DbSet<PlantType> PlantTypes { get; set; }

        public DbSet<Module> Modules { get; set; }
    }
}
