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
            modelBuilder.Entity<PetPassport>().HasMany(p => p.Passports).WithOne(p => p.Pet).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData(new[] {
                new Role()
                {
                    Id = 1,
                    Name = "admin"
                },
                new Role()
                {
                    Id = 2,
                    Name = "doctor"
                },
                new Role()
                {
                    Id = 3,
                    Name = "owner"
                }
            });

            modelBuilder.Entity<Vaccination>().HasData(new[] {
                new Vaccination()
                {
                    Id = 1,
                    Name = "hepatitis"
                },
                new Vaccination()
                {
                    Id = 2,
                    Name = "enteritis"
                },
                new Vaccination()
                {
                    Id = 3,
                    Name = "leptospirosis"
                },
                new Vaccination()
                {
                    Id = 4,
                    Name = "rabies"
                }
            });

            modelBuilder.Entity<VaccinationState>().HasData(new[] {
                new VaccinationState()
                {
                    Id = 1,
                    Name = "start"
                },
                new VaccinationState()
                {
                    Id = 2,
                    Name = "finish"
                },
                new VaccinationState()
                {
                    Id = 3,
                    Name = "process"
                },
                new VaccinationState()
                {
                    Id = 4, 
                    Name = "fail"
                }
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<Collar> Collars { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<PetPassport> PetPassports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccinationState> VaccinationStates { get; set; }
    }
}
