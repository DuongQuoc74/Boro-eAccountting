using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyCongNo;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyTk;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService.IQuanLyHeThong;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service.QuanLyHeThong
{
    public class DuDauKyCongNoService : ApplicationService, IDuDauKyCongNoService
    {
        private readonly IRepository<DuDauKyCongNo, int?> _repository;
        public readonly ACWebDbContext _context;
        public readonly IUtilitiesService _utilitiesService;
        public DuDauKyCongNoService(IRepository<DuDauKyCongNo, int?> repository, ACWebDbContext context, IUtilitiesService utilitiesService)
        {
            _repository = repository;
            _context = context;
            _utilitiesService = utilitiesService;
        }
        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }
        public async Task<List<DuDauKyCongNoDto>> GetListAsync(DauKyRequest request)
        {
            try
            {
                var query = from ddk in _context.DuDauKyCongNos
                            where !ddk.IsDeleted && ddk.ChiNhanhId == request.ChiNhanhId && (ddk.Ngay.HasValue && ddk.Ngay.Value.Year == request.Ngay.Year)
                            join cn in _context.ChiNhanhs on ddk.ChiNhanhId equals cn.Id
                            where !cn.IsDeleted
                            join kh in _context.KhachHangs on ddk.KhachHangId equals kh.Id
                            where !kh.IsDeleted
                            join tk in _context.TaiKhoans on ddk.TaiKhoanId equals tk.Id
                            where !tk.IsDeleted
                            join vv in _context.VuViecs on ddk.VuViecId equals vv.Id into vvs
                            from vv in vvs.DefaultIfEmpty()
                            join mp in _context.DmMaPhis on ddk.MaPhiId equals mp.Id into mps
                            from mp in mps.DefaultIfEmpty()
                            select new { ddk, cn, kh, tk, mp, vv };

                if (request.TaiKhoanId.HasValue)
                {
                    query = query.Where(x => x.ddk.TaiKhoanId == request.TaiKhoanId);
                }
                var items = await query.Select(x => new DuDauKyCongNoDto()
                {
                    Id = x.ddk.Id,
                    ChiNhanhId = x.ddk.ChiNhanhId,
                    ChiNhanhUd = x.cn.ChiNhanhUd,
                    KhachHangId = x.ddk.KhachHangId,
                    KhachHangNm = x.kh.KhachHangNm,
                    KhachHangUd = x.kh.KhachHangUd,
                    TaiKhoanId = x.ddk.TaiKhoanId,
                    TaiKhoanUd = x.tk.TaiKhoanUd,
                    VuViecId = x.ddk.VuViecId,
                    VuViecUd = x.vv.VuViecUd,
                    MaPhiId = x.ddk.MaPhiId,
                    MaPhiUd = x.mp.DmMaPhiUd,
                    DuCo = x.ddk.DuCo,
                    DuNo = x.ddk.DuNo,
                    DuCoVND = x.ddk.DuCoVND,
                    DuNoVND = x.ddk.DuNoVND,
                    Ngay = x.ddk.Ngay,
                }).ToListAsync();
                return items;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<DuDauKyCongNoDto>();
            }

        }

        public async Task<ApiResult> CreateAsync(DuDauKyCongNoRequest request)
        {
            try
            {
                var check = await _repository.AnyAsync(x=>x.TaiKhoanId == request.TaiKhoanId && x.KhachHangId == request.KhachHangId);
                if(check)
                    return new ApiResult() { IsSuccessed = false, Message = "Số dư đầu kỳ của Tài khoản và Khách hàng này đã có!" };
                var item = ObjectMapper.Map<DuDauKyCongNoRequest, DuDauKyCongNo>(request);
                await _repository.InsertAsync(item, true);
                return new ApiResult() { IsSuccessed = true, Message = "Thêm mới thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
            
        }

        public async Task<DuDauKyCongNoDto> GetByIdAsync(int? id)
        {
            try
            {
                var query = from ddk in _context.DuDauKyCongNos
                            where !ddk.IsDeleted && ddk.Id == id
                            join cn in _context.ChiNhanhs on ddk.ChiNhanhId equals cn.Id
                            where !cn.IsDeleted
                            join kh in _context.KhachHangs on ddk.KhachHangId equals kh.Id
                            where !kh.IsDeleted
                            join tk in _context.TaiKhoans on ddk.TaiKhoanId equals tk.Id
                            where !tk.IsDeleted
                            join vv in _context.VuViecs on ddk.VuViecId equals vv.Id into vvs
                            from vv in vvs.DefaultIfEmpty()
                            join mp in _context.DmMaPhis on ddk.MaPhiId equals mp.Id into mps
                            from mp in mps.DefaultIfEmpty()
                            select new { ddk, cn, kh, tk, mp, vv };
                var item = await query.Select(x => new DuDauKyCongNoDto()
                {
                    Id = x.ddk.Id,
                    ChiNhanhId = x.ddk.ChiNhanhId,
                    ChiNhanhUd = x.cn.ChiNhanhUd,
                    ChiNhanhNm = x.cn.ChiNhanhNm,
                    KhachHangId = x.ddk.KhachHangId,
                    KhachHangNm = x.kh.KhachHangNm,
                    KhachHangUd = x.kh.KhachHangUd,
                    TaiKhoanId = x.ddk.TaiKhoanId,
                    TaiKhoanUd = x.tk.TaiKhoanUd,
                    TaiKhoanNm = x.tk.TaiKhoanNm,
                    VuViecId = x.ddk.VuViecId,
                    VuViecUd = x.vv.VuViecUd,
                    VuViecNm = x.vv.VuViecNm,
                    MaPhiId = x.ddk.MaPhiId,
                    MaPhiUd = x.mp.DmMaPhiUd,
                    MaPhiNm = x.mp.DmMaPhiNm,
                    DuCo = x.ddk.DuCo,
                    DuNo = x.ddk.DuNo,
                    DuCoVND = x.ddk.DuCoVND,
                    DuNoVND = x.ddk.DuNoVND,
                    Ngay = x.ddk.Ngay,
                }).FirstAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DuDauKyCongNoDto();
            }
        }

        public async Task<ApiResult> UpdateAsync(int? id, DuDauKyCongNoRequest request)
        {
            try
            {
                var check = await _repository.AnyAsync(x => x.TaiKhoanId == request.TaiKhoanId && x.KhachHangId == request.KhachHangId && x.Id != id);
                if (check)
                    return new ApiResult() { IsSuccessed = false, Message = "Số dư đầu kỳ của Tài khoản và Khách hàng này đã có!" };
                var item = ObjectMapper.Map(request, await _repository.GetAsync(id));
                await _repository.UpdateAsync(item, true);
                return new ApiResult() { IsSuccessed = true, Message = "Cập nhật thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<List<TinhTongDto>> TinhTongAsync(int? taiKhoanId, int? khachHangId, List<DuDauKyCongNoDto> duDauKyCongNoDtos)
        {
            var datas = duDauKyCongNoDtos.AsEnumerable();
            if (taiKhoanId.HasValue)
            {
               datas = datas.Where(x=>x.TaiKhoanId == taiKhoanId);
            }
            if (khachHangId.HasValue)
            {
                datas = datas.Where(x => x.KhachHangId == khachHangId);
            }
            var duNo =  datas.Sum(x => x.DuNo);
            var duNoVND = datas.Sum(x => x.DuNoVND);
            var duCo = datas.Sum(x => x.DuCo);
            var duCoVND = datas.Sum(x => x.DuCoVND);
            var tinhTongs = new List<TinhTongDto>
                {
                    new TinhTongDto
                    {
                        DienGiai = "Dư nợ đầu kỳ",
                        Tien = duNo,
                        TienVND = duNoVND
                    },
                    new TinhTongDto
                    {
                        DienGiai = "Dư có đầu kỳ",
                        Tien = duCo,
                        TienVND = duCoVND
                    }
                }.ToList();
            return await Task.FromResult(tinhTongs);
        }

        public byte[] ExportExcel(List<DuDauKyCongNoDto> requests, string titleName)
        {
            var package = _utilitiesService.CreateExcelTemplate(requests.Count, 10, titleName);
            var worksheet = package.Workbook.Worksheets[titleName];

            // Tạo tên cột
            worksheet.Cells[4, 1].Value = "Chi nhánh";
            worksheet.Cells[4, 2].Value = "Tài khoản";
            worksheet.Cells[4, 3].Value = "Vụ việc";
            worksheet.Cells[4, 4].Value = "Mã phí";
            worksheet.Cells[4, 5].Value = "Mã khách hàng";
            worksheet.Cells[4, 6].Value = "Tên khách hàng";
            worksheet.Cells[4, 7].Value = "Dư nợ ngoại tệ";
            worksheet.Cells[4, 8].Value = "Dư có ngoại tệ";
            worksheet.Cells[4, 9].Value = "Dư nợ";
            worksheet.Cells[4, 10].Value = "Dư có";
            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 12;
            worksheet.Column(3).Width = 12;
            worksheet.Column(4).Width = 12;
            worksheet.Column(5).Width = 12;
            worksheet.Column(6).Width = 50;
            worksheet.Column(7).Width = 12;
            worksheet.Column(8).Width = 12;
            worksheet.Column(9).Width = 12;
            worksheet.Column(10).Width = 12;
            worksheet.Cells[2, 1, 2, 10].Merge = true;//Set vị trí hiển thị title ==> Tổng width của cột phải không quá 210
            //Đọc dữ liệu
            int rowStart = 5; // bắt đầu từ row 5
            if (requests.Count > 0)
            {
                foreach (var item in requests)
                {
                    worksheet.Cells[rowStart, 1].Value = item.ChiNhanhUd;
                    worksheet.Cells[rowStart, 2].Value = item.TaiKhoanUd;
                    worksheet.Cells[rowStart, 3].Value = item.VuViecUd;
                    worksheet.Cells[rowStart, 4].Value = item.MaPhiUd;
                    worksheet.Cells[rowStart, 5].Value = item.KhachHangUd;
                    worksheet.Cells[rowStart, 6].Value = item.KhachHangNm;
                    worksheet.Cells[rowStart, 7].Value = item.DuNo;
                    worksheet.Cells[rowStart, 8].Value = item.DuCo;
                    worksheet.Cells[rowStart, 9].Value = item.DuNoVND;
                    worksheet.Cells[rowStart, 10].Value = item.DuCoVND;
                    rowStart++;
                }
            }

            return package.GetAsByteArray();
        }
    }
}
