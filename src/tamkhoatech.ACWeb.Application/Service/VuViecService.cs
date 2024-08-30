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
    public class VuViecService : ApplicationService, IVuViecService
    {
        public readonly IRepository<VuViec, int?> _repository;
        public VuViecService(IRepository<VuViec, int?> repository)
        {
            _repository = repository;
        }

        public async Task<List<VuViecDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<VuViec>, List<VuViecDto>>(await _repository.GetListAsync());
        }
    }
}
