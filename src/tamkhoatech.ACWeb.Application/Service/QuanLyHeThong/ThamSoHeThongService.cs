using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService.IQuanLyHeThong;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service.QuanLyHeThong
{
    public class ThamSoHeThongService : ApplicationService, IThamSoHeThongService
    {
        private readonly IRepository<ThamSoHeThong, int> _repository;
        public ThamSoHeThongService(IRepository<ThamSoHeThong, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> CachLayDienGiaiKhiTaoTuDongPhieuThuChiAsync(int loaithamsocanlay)
        {
            try
            {
                if (loaithamsocanlay == 1)
                {
                    var cachlay = await _repository.FirstOrDefaultAsync(p => p.ThamSoHeThongUd == "LAY_DIEN_GIAI_TC_DV");
                    var value = int.Parse(cachlay?.GiaTri ?? "0");
                    return value > 2 ? 0 : value;
                }
                if (loaithamsocanlay == 2)
                {
                    var cachlay = await _repository.FirstOrDefaultAsync(p => p.ThamSoHeThongUd == "LAY_DIEN_GIAI_TC_VT");
                    var value = int.Parse(cachlay?.GiaTri ?? "0");
                    return value > 3 ? 0 : value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public async Task<ThamSoHeThongDto> GetByIdAsync(int id)
        {
            return ObjectMapper.Map<ThamSoHeThong, ThamSoHeThongDto>(await _repository.GetAsync(id));
        }

        public async Task<ThamSoHeThongDto> GetByThamSoHeThongUdAsync(string thamSoHeThongUd)
        {
            return ObjectMapper.Map<ThamSoHeThong, ThamSoHeThongDto>(await _repository.FirstAsync(x=>x.ThamSoHeThongUd == thamSoHeThongUd));
        }

        public async Task<List<ThamSoHeThongDto>> GetListAsync(string nhomThamSo)
        {
            return ObjectMapper.Map<List<ThamSoHeThong>, List<ThamSoHeThongDto>>( await _repository.GetListAsync(x => x.NhomThamSo == nhomThamSo && (x.IsHidden == false || x.IsHidden == null)));
        }

        public string GioiHanKyTu(string inputString, int limit)
        {
            string[] words = inputString.Split(' ');
            inputString = string.Join(" ", words.Take(limit));
            inputString = inputString.TrimEnd(' ').TrimEnd(',');
            return inputString;
        }

        public async Task<int> TuDongTaoThuChiAsync()
        {
            var cachlay = await _repository.FirstOrDefaultAsync(p => p.ThamSoHeThongUd == "TAO_TU_DONG_TCNC");
            var value = int.Parse(cachlay?.GiaTri ?? "0");
            return value > 3 ? 0 : value;
        }

        public async Task<ApiResult> UpdateAsync(int id, string? value)
        {
            try
            {
                var item = await _repository.GetAsync(id);
                item.GiaTri = value;
                await _repository.UpdateAsync(item);
                return new ApiResult() { IsSuccessed = true, Message = "Cập nhật thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
        }
    }
}
