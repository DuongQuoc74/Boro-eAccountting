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
    public class CongTrinhService: ApplicationService, ICongTrinhService
    {
        private readonly IRepository<CongTrinh, int?> _repository;
        public CongTrinhService(IRepository<CongTrinh, int?> repository)
        {
            _repository = repository;
        }

        public async Task<List<CongTrinhDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<CongTrinh>, List<CongTrinhDto>>( await _repository.GetListAsync());
        }
    }
}
