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
    public class BoPhanService : ApplicationService, IBoPhanService
    {
        private readonly IRepository<BoPhan, int> _repository;
        public BoPhanService(IRepository<BoPhan, int> repository)
        {
            _repository = repository;
        }
        public async Task<List<BoPhanDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<BoPhan>, List<BoPhanDto>>(await _repository.GetListAsync());
        }
    }
}
