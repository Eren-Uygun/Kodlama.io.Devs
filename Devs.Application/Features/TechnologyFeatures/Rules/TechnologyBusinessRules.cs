using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _technologyRepository = technologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(x=>x.TechnologyName == name);
            if(result.Items.Any()) throw new BusinessException("Technology name is exists");
        }

        public void CheckTechnologyWhenRequested(Technology? technology)
        {
            if(technology == null)throw new BusinessException("Requested technology does not exists");
        }

        public void CheckTechnologyExistsWhenRequested(int technologyId)
        {
            var item = _technologyRepository.Get(x=>x.Id ==  technologyId);
            if(item==null) throw new BusinessException("Technology does not exists");
        }

        public void CheckProgrammingLanguageExistsWhenRequested(int programmingLanguageId)
        {
            var item = _programmingLanguageRepository.Get(x=>x.Id == programmingLanguageId);
            if(item==null) throw new BusinessException("Programming Language does not exists");
        }
    }
}
