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
using System.Xml.XPath;

namespace Devs.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        private DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        private DbSet<Technology> Technologies { get; set; }
        private DbSet<AppUser> AppUsers { get; set; }
        private DbSet<UserGitHub> UserGitHubs { get; set; }
        private DbSet<User> Users { get; set; }
        private DbSet<OperationClaim> OperationClaims { get; set; }
        private DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        //private DbSet<User> Users {get;set;} 

        public BaseDbContext(DbContextOptions contextOptions, IConfiguration configuration) : base(contextOptions)
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

                x.ToTable("ProgrammingLanguages").HasKey(pk => pk.Id);


                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.ProgrammingLanguageName).HasColumnName("Programming_Language_Name");

                x.HasMany(p => p.Technologies);



            });

            modelBuilder.Entity<Technology>(x =>
            {
                x.ToTable("Technologies").HasKey(pk => pk.Id);

                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.ProgrammingLanguageId).HasColumnName("Programming_Language_Id");
                x.Property(p => p.TechnologyName).HasColumnName("Technology_Name");

                x.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<UserGitHub>(x =>
            {
                x.ToTable("UserGitHub");

                x.Property(x => x.Id).HasColumnName("Id");
                x.Property(x => x.AppUserId).HasColumnName("AppUserId");
                x.Property(x => x.GitHubUrl).HasColumnName("GitHubUrl");

                x.HasOne(x => x.AppUser);
            });

            modelBuilder.Entity<AppUser>(x =>
            {
                x.ToTable("AppUser");

                x.HasOne(x => x.UserGitHub);
            });

            modelBuilder.Entity<UserGitHub>(x =>
            {
                x.ToTable("UserGitHub").HasKey(x => x.Id);
                x.Property(x => x.Id).HasColumnName("Id");
                x.Property(x => x.AppUserId).HasColumnName("AppUserId");
                x.Property(x => x.GitHubUrl).HasColumnName("GitHubUrl");

                x.HasOne(x => x.AppUser);
            });

            modelBuilder.Entity<OperationClaim>(x =>
            {
                x.ToTable("OperationClaims").HasKey(x=>x.Id);
                x.Property(x=>x.Id).HasColumnName("Id");
                x.Property(x=>x.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(x =>
            {
                x.ToTable("UserOperationClaims").HasKey(x => x.Id);

                x.Property(x=>x.Id);
                x.Property(x=>x.UserId);
                x.Property(x=>x.OperationClaimId).HasColumnName("OperationClaim");

                x.HasOne(x=>x.User);
                x.HasOne(x=>x.OperationClaim);

             });


            modelBuilder.Entity<User>(x =>
            {
                x.ToTable("Users").HasKey(pk => pk.Id);

                x.Property(x => x.Id).HasColumnName("Id");
                x.Property(x => x.FirstName).HasColumnName("FirstName");
                x.Property(x => x.LastName).HasColumnName("LastName");
                x.Property(x => x.Email).HasColumnName("Email");
                x.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
                x.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
                x.Property(x => x.Status).HasColumnName("Status").HasDefaultValue(true);
                x.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType");

                x.HasMany(x=>x.UserOperationClaims);
                x.HasMany(x=>x.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(p =>
             {
                 p.ToTable("OperationClaims").HasKey(o => o.Id);
                 p.Property(o => o.Id).HasColumnName("Id");
                 p.Property(o => o.Name).HasColumnName("Name");
             });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = {
                new ProgrammingLanguage {Id=1,ProgrammingLanguageName="C#"},
                new ProgrammingLanguage {Id=2,ProgrammingLanguageName="Java"},
                new ProgrammingLanguage {Id=3,ProgrammingLanguageName="JavaScript"},
                new ProgrammingLanguage {Id=4,ProgrammingLanguageName="Python"}
                };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyDataSeed =
            {
                new Technology {Id=1,ProgrammingLanguageId=1,TechnologyName="WFA"},
                new Technology {Id=2,ProgrammingLanguageId=1,TechnologyName="ASP.NET"},
                new Technology {Id=3,ProgrammingLanguageId=2,TechnologyName="Spring"},
                new Technology {Id=4,ProgrammingLanguageId=2,TechnologyName="ADF"},
                new Technology {Id=5,ProgrammingLanguageId=4,TechnologyName="Django"},
            };
            modelBuilder.Entity<Technology>().HasData(technologyDataSeed);


            /*
            AppUser[] appUsersDataSeed =
            {
                new AppUser {Id = 1 ,FirstName="Test" , LastName = "Testoğlu", Email = "test@testmail.com",}
            };
            */
            /*
            OperationClaim[] operationClaimsEntitySeeds =
            {
                new(1, "Admin"), 
                new(2, "User")
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);

            */

        }




    }
}
