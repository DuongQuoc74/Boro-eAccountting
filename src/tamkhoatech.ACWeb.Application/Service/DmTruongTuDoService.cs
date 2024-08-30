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
    public class DmTruongTuDoService : ApplicationService, IDmTruongTuDoService
    {
        public readonly IRepository<DmTruongTuDo, int?> _repository;
        public DmTruongTuDoService (IRepository<DmTruongTuDo, int?> repository)
        {
            _repository = repository;
        }
        public async Task<List<DmTruongTuDoDto>> GetListLoai1Async()
        {
            return ObjectMapper.Map<List<DmTruongTuDo>, List<DmTruongTuDoDto>>(await _repository.GetListAsync(x=>x.LoaiTruongTuDo == 1));
        }

        public async Task<List<DmTruongTuDoDto>> GetListLoai2Async()
        {
            return ObjectMapper.Map<List<DmTruongTuDo>, List<DmTruongTuDoDto>>(await _repository.GetListAsync(x => x.LoaiTruongTuDo == 2));
        }

        public async Task<List<DmTruongTuDoDto>> GetListLoai3Async()
        {
            return ObjectMapper.Map<List<DmTruongTuDo>, List<DmTruongTuDoDto>>(await _repository.GetListAsync(x => x.LoaiTruongTuDo == 3));
        }
    }
}
