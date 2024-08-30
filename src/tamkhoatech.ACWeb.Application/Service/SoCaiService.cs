using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class SoCaiService : ApplicationService, ISoCaiService
    {
        public readonly IRepository<SoCai, int?> _repository;
        public SoCaiService(IRepository<SoCai, int?> repository) 
        {
            _repository  = repository;
        }

        public async Task<List<SoCaiDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<SoCai>, List<SoCaiDto>>(await _repository.GetListAsync());
        }
    }
}
