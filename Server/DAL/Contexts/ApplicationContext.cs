using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasMany(p => p.Passports).WithOne(p => p.Pet).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<Collar> Collars { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccinationState> VaccinationStates { get; set; }
    }
}
