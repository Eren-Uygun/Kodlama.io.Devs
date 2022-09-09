using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class ProgrammingLanguage:Entity
    {
        public ProgrammingLanguage()
        {

        }

        public string ProgrammingLanguageName { get; set; }

        public virtual ICollection<Technology> Technologies {get;set;}

        public ProgrammingLanguage(int id,string programmingLanguageName):this()
        {
            Id = id;
            ProgrammingLanguageName = programmingLanguageName;
        }

    }
}
