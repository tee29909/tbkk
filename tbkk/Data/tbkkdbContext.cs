using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tbkk.Models
{
    public class tbkkdbContext : DbContext
    {
        public tbkkdbContext (DbContextOptions<tbkkdbContext> options)
            : base(options)
        {
        }

        public DbSet<tbkk.Models.Employee> Employee { get; set; }

        public DbSet<tbkk.Models.Login> Login { get; set; }

        public DbSet<tbkk.Models.Canteen> Canteen { get; set; }
        public DbSet<tbkk.Models.CarType> CarType { get; set; }
        public DbSet<tbkk.Models.Company> Company { get; set; }

        public DbSet<tbkk.Models.CompanyCar> CompanyCar { get; set; }
        public DbSet<tbkk.Models.Department> Department { get; set; }
        public DbSet<tbkk.Models.DetailOT> DetailOT { get; set; }

        public DbSet<tbkk.Models.EmployeeType> EmployeeType { get; set; }
        public DbSet<tbkk.Models.FoodSet> FoodSet { get; set; }
        public DbSet<tbkk.Models.Location> Location { get; set; }

        public DbSet<tbkk.Models.OT> OT { get; set; }
        public DbSet<tbkk.Models.Part> Part { get; set; }
        public DbSet<tbkk.Models.Position> Position { get; set; }
    }
}
