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
    public class NgoaiTeService : ApplicationService, INgoaiTeService
    {
        public readonly IRepository<NgoaiTe, int?> _ngoaiTeRepository;
        public readonly IRepository<TyGiaNgoaiTe, int?> _tyGiaNgoaiTeRepository;
        public NgoaiTeService(IRepository<NgoaiTe, int?> ngoaiTeRepository, IRepository<TyGiaNgoaiTe, int?> tyGiaNgoaiTeRepository)
        {
            _ngoaiTeRepository = ngoaiTeRepository;
            _tyGiaNgoaiTeRepository = tyGiaNgoaiTeRepository;
        }
        public async Task<List<NgoaiTeDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<NgoaiTe>, List<NgoaiTeDto>>(await _ngoaiTeRepository.GetListAsync());
        }
        public async Task<NgoaiTeDto> GetByIdAsync(int? id)
        {
            var ngoaiTe = await _ngoaiTeRepository.GetAsync(id);
            var tiGias = await _tyGiaNgoaiTeRepository.GetListAsync(x => x.NgoaiTeId == id);
            var tiGiaDtos = ObjectMapper.Map<List<TyGiaNgoaiTe>, List<TyGiaNgoaiTeDto>>(tiGias);
            var ngoaiTeDto = ObjectMapper.Map<NgoaiTe, NgoaiTeDto>(ngoaiTe);
            ngoaiTeDto.TyGiaNgoaiTeDtos = tiGiaDtos;
            return ngoaiTeDto;
        }
    }
}
