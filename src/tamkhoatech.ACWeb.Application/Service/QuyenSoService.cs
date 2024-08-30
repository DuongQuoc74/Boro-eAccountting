using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class QuyenSoService : ApplicationService, IQuyenSoService
    {
        public readonly IRepository<QuyenSo, int?> _repository;
        public QuyenSoService(IRepository<QuyenSo, int?> repository)
        {
            _repository = repository;
        }

        public Task<ApiResult> CreateAsync(QuyenSoDto quyenSoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuyenSoDto>> GetListAsync(string maCt)
        {
            return ObjectMapper.Map<List<QuyenSo>, List<QuyenSoDto>>(await _repository.GetListAsync(x=>x.MaCt== maCt));
        }

        public async Task<bool> UpdateSoCTAsync(string maCt, string soQuyen, string soPhieu)
        {
            try
            {
                var quyenSo = await _repository.GetAsync(x => x.SoQuyen == soQuyen && x.MaCt == maCt);
                if (quyenSo != null)
                {
                    quyenSo.SoCtHienTai = Int32.Parse(soPhieu);
                    await _repository.UpdateAsync(quyenSo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
    }
}
