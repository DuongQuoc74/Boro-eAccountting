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
    public class DmMaPhiService : ApplicationService, IDmMaPhiService
    {
        public readonly IRepository<DmMaPhi, int?> _repository;
        public DmMaPhiService (IRepository<DmMaPhi, int?> repository)
        {
            _repository = repository;
        }
        public async Task<List<DmMaPhiDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<DmMaPhi>, List<DmMaPhiDto>>(await _repository.GetListAsync());
        }
    }
}
