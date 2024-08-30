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
    public class BoPhanHTService : ApplicationService, IBoPhanHTService
    {
        public readonly IRepository<BoPhanHT, int?> _repository;
        public BoPhanHTService(IRepository<BoPhanHT, int?> repository)
        {
            _repository = repository;
        }

        public async Task<List<BoPhanHTDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<BoPhanHT>, List<BoPhanHTDto>>(await _repository.GetListAsync());
        }
    }
}
