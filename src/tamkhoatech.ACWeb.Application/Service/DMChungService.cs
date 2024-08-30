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
using Volo.Abp.ObjectMapping;

namespace tamkhoatech.ACWeb.Service
{
    public class DMChungService : ApplicationService, IDMChungService
    {
        public readonly IRepository<DMChung, int?> _repository;
        public DMChungService(IRepository<DMChung, int?> repository)
        {
            _repository = repository;
        }

        public async Task<DmChungDto?> GetByIdAsync(string? loaiDM, string? danhMucChungUd)
        {
            var item = await _repository.GetAsync(x=>x.LoaiDM == loaiDM && x.DMChungUd == danhMucChungUd);
            if(item == null)
                return null;
            return ObjectMapper.Map<DMChung, DmChungDto>(item);
        }

        public async Task<List<DmChungDto>> GetListAsync(string? loaiDM)
        {
            if(loaiDM == null)
                return ObjectMapper.Map<List<DMChung>, List<DmChungDto>>(await _repository.GetListAsync());
            return ObjectMapper.Map<List<DMChung>, List<DmChungDto>>(await _repository.GetListAsync(x=>x.LoaiDM == loaiDM));
        }
    }
}
