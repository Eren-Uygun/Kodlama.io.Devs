using Core.Security.Entities;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        private DbSet<ProgrammingLanguage> ProgrammingLanguages {get; set; }
        private DbSet<Technology> Technologies {get;set;}

        //private DbSet<User> Users {get;set;} 

        public BaseDbContext(DbContextOptions contextOptions,IConfiguration configuration):base(contextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
            
            //Add-migration yapılırken alınan hatanın detayları için yazıldı.
            optionsBuilder.EnableSensitiveDataLogging();
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProgrammingLanguage>(x =>
            {

               x.ToTable("ProgrammingLanguages").HasKey(pk=>pk.Id);
              

               x.Property(p=>p.Id).HasColumnName("Id");
               x.Property(p=>p.ProgrammingLanguageName).HasColumnName("Programming_Language_Name");

               x.HasMany(p=>p.Technologies);

        

            });

            modelBuilder.Entity<Technology>(x =>
            {
                x.ToTable("Technologies").HasKey(pk=>pk.Id);

                x.Property(p=>p.Id).HasColumnName("Id");
                x.Property(p=>p.ProgrammingLanguageId).HasColumnName("Programming_Language_Id");
                x.Property(p=>p.TechnologyName).HasColumnName("Technology_Name");

                x.HasOne(p=>p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(x =>
            {
                x.ToTable("Users").HasKey(pk=>pk.Id);

                x.Property(p=>p.Id).HasColumnName("Id");
                x.Property(p=>p.FirstName).HasColumnName("FirstName");
                x.Property(p=>p.LastName).HasColumnName("LastName");
                x.Property(p=>p.Email).HasColumnName("Email");
                x.Property(p=>p.PasswordHash).HasColumnName("PasswordHash");
                x.Property(p=>p.PasswordSalt).HasColumnName("PasswordSalt");
                x.Property(p=>p.Status).HasColumnName("Status");
                x.Property(p=>p.AuthenticatorType).HasColumnName("AuthenticatorType");
            });

            



           // ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "JavaScript"),new(4, "Python") };
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { 
                new ProgrammingLanguage {Id=1,ProgrammingLanguageName="C#"},
                new ProgrammingLanguage {Id=2,ProgrammingLanguageName="Java"},
                new ProgrammingLanguage {Id=3,ProgrammingLanguageName="JavaScript"},
                new ProgrammingLanguage {Id=4,ProgrammingLanguageName="Python"}
                };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            //Technology[] technologyDataSeed = { new(1, 1, "WFA"), new(2, 1, "ASP.NET"), new(3, 2, "Spring"), new(3, 2, "ADF")};
            Technology[] technologyDataSeed =
            {
                new Technology {Id=1,ProgrammingLanguageId=1,TechnologyName="WFA"},
                new Technology {Id=2,ProgrammingLanguageId=1,TechnologyName="ASP.NET"},
                new Technology {Id=3,ProgrammingLanguageId=2,TechnologyName="Spring"},
                new Technology {Id=4,ProgrammingLanguageId=2,TechnologyName="ADF"},
                new Technology {Id=5,ProgrammingLanguageId=4,TechnologyName="Django"},
            };
            modelBuilder.Entity<Technology>().HasData(technologyDataSeed);



        }

 


    }
}
