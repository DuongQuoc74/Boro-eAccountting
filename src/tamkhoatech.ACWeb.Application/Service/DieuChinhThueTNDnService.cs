

using System.Collections.Generic;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace tamkhoatech.ACWeb.Service
{
    public class DieuChinhThueTNDnService : ApplicationService, IDieuChinhThueTNDnService
    {
        public readonly IRepository<DieuChinhThueTNDN, int?> _repository;
        public DieuChinhThueTNDnService (IRepository<DieuChinhThueTNDN, int?> repository)
        {
            _repository = repository;
        }
        public async Task<List<DieuChinhThueTNDnDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<DieuChinhThueTNDN>, List<DieuChinhThueTNDnDto>>(await _repository.GetListAsync());
        }
    }
}
