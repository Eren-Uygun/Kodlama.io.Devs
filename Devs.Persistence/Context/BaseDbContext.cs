﻿using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        private DbSet<ProgrammingLanguage> ProgrammingLanguages {get; set; }

        public BaseDbContext(DbContextOptions contextOptions,IConfiguration configuration):base(contextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(x =>
            {
               x.ToTable("ProgrammingLanguages").HasKey(pk=>pk.Id);
               x.Property(p=>p.Id).HasColumnName("Id");
               x.Property(p=>p.Name).HasColumnName("Name");

            });


             ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

        }

 


    }
}
