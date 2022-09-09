﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class Technology:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string TechnologyName { get; set; }

        public virtual ProgrammingLanguage? ProgrammingLanguage {get;set;}

        public Technology()
        {

        }

        public Technology(int id,int programmingLanguageId, string technologyName):this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            TechnologyName = technologyName;
        }
    }
}
