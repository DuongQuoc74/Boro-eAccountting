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
    public class MaGiaoDichService : ApplicationService, IMaGiaoDichService
    {
        public readonly IRepository<MaGiaoDich, int?> _repository;
        public readonly IRepository<ManHinhNhap, int?> _manHinhNhapRepository;
        public MaGiaoDichService(IRepository<MaGiaoDich, int?> repository, IRepository<ManHinhNhap, int?> manHinhNhapRepository)
        {
            _repository = repository;
            _manHinhNhapRepository = manHinhNhapRepository;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0)
                return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<MaGiaoDichDto> GetByIdAsync(int id)
        {
            return ObjectMapper.Map<MaGiaoDich, MaGiaoDichDto>(await _repository.GetAsync(id));
        }

        public async Task<List<MaGiaoDichDto>> GetListAsync(string maCt)
        {
            try
            {
                var maPhieu = await _manHinhNhapRepository.GetAsync(x => x.ChungTuUd == maCt);
                if (maPhieu != null)
                    return ObjectMapper.Map<List<MaGiaoDich>, List<MaGiaoDichDto>>(await _repository.GetListAsync(x => x.ManHinhNhapId == maPhieu.Id));
                else
                    return new List<MaGiaoDichDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MaGiaoDichDto>();
            }
        }

    }
}
