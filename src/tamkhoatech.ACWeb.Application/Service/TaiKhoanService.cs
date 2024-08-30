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
    public class TaiKhoanService : ApplicationService, ITaiKhoanService
    {
        public readonly IRepository<TaiKhoan, int?> _repository;
        public TaiKhoanService(IRepository<TaiKhoan, int?> repository)
        {
            _repository = repository;
        }
        public async Task<List<TaiKhoanDto>> GetListAsync()
        {
            var taiKhoans = await _repository.GetListAsync();
            var ids = taiKhoans.Where(x=>x.TaiKhoanParentId.HasValue).Select(x => x.TaiKhoanParentId).Distinct().ToList();
            var items = taiKhoans.Where(x => !ids.Contains(x.Id)).ToList();

            return ObjectMapper.Map<List<TaiKhoan>, List<TaiKhoanDto>>(items);
        }
        public async Task<TaiKhoanDto> GetByIdAsync(int? id)
        {
            return ObjectMapper.Map<TaiKhoan, TaiKhoanDto>(await _repository.GetAsync(id));
        }
    }
}
