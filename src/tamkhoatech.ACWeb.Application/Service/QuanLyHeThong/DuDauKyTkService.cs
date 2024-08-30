using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyTk;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService;
using tamkhoatech.ACWeb.IService.IQuanLyHeThong;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service.QuanLyHeThong
{
    public class DuDauKyTkService : ApplicationService, IDuDauKyTkService
    {
        public readonly IRepository<DuDauKyTk, int?> _repository;
        public readonly ACWebDbContext _context;
        public readonly ITaiKhoanService _taiKhoanService;
        public readonly IUtilitiesService _utilitiesService;
        public DuDauKyTkService(IRepository<DuDauKyTk, int?> repository, ACWebDbContext context, ITaiKhoanService taiKhoanService, IUtilitiesService utilitiesService)
        {
            _repository = repository;
            _context = context;
            _taiKhoanService = taiKhoanService;
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

        public byte[] ExportExcel(List<DuDauKyTkDto> requests, string titleName)
        {
            var package = _utilitiesService.CreateExcelTemplate(requests.Count, 10, titleName);
            var worksheet = package.Workbook.Worksheets[titleName];

            // Tạo tên cột
            worksheet.Cells[4, 1].Value = "Tài khoản";
            worksheet.Cells[4, 2].Value = "Tên tài khoản";
            worksheet.Cells[4, 3].Value = "Dư nợ đầu kỳ ngoại tệ";
            worksheet.Cells[4, 4].Value = "Dư có đầu kỳ ngoại tệ";
            worksheet.Cells[4, 5].Value = "Dư nợ đầu kỳ";
            worksheet.Cells[4, 6].Value = "Dư có đầu kỳ";
            worksheet.Cells[4, 7].Value = "Dư nợ đầu năm ngoại tệ";
            worksheet.Cells[4, 8].Value = "Dư có đầu năm ngoại tệ";
            worksheet.Cells[4, 9].Value = "Dư nợ đầu năm";
            worksheet.Cells[4, 10].Value = "Dư có đầu năm";
            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 12;
            worksheet.Column(4).Width = 12;
            worksheet.Column(5).Width = 12;
            worksheet.Column(6).Width = 12;
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
                    worksheet.Cells[rowStart, 1].Value = item.TaiKhoanUd;
                    worksheet.Cells[rowStart, 2].Value = item.TaiKhoanNm;
                    worksheet.Cells[rowStart, 3].Value = item.DuNoDauKy;
                    worksheet.Cells[rowStart, 4].Value = item.DuCoDauKy;
                    worksheet.Cells[rowStart, 5].Value = item.DuNoDauKyVND;
                    worksheet.Cells[rowStart, 6].Value = item.DuCoDauKyVND;
                    worksheet.Cells[rowStart, 7].Value = item.DuNoDauNam;
                    worksheet.Cells[rowStart, 8].Value = item.DuCoDauNam;
                    worksheet.Cells[rowStart, 9].Value = item.DuNoDauNamVND;
                    worksheet.Cells[rowStart, 10].Value = item.DuCoDauNamVND;
                    rowStart++;
                }
            }

            return package.GetAsByteArray();
        }

        public async Task<DuDauKyTkDto> GetByIdAsync(int? id)
        {
            try
            {
                var query = from ddk in _context.DuDauKyTks
                            where !ddk.IsDeleted && ddk.Id == id
                            join tk in _context.TaiKhoans on ddk.TaiKhoanId equals tk.Id
                            where !tk.IsDeleted
                            join cn in _context.ChiNhanhs on ddk.ChiNhanhId equals cn.Id
                            where !cn.IsDeleted
                            select new { ddk, tk, cn };
                var item = await query.Select(x => new DuDauKyTkDto
                {
                    Id = x.ddk.Id,
                    ChiNhanhId = x.ddk.ChiNhanhId,
                    ChiNhanhNm = x.cn.ChiNhanhNm,
                    Ngay = x.ddk.Ngay,
                    TaiKhoanId = x.ddk.TaiKhoanId,
                    TaiKhoanUd = x.tk.TaiKhoanUd,
                    TaiKhoanNm = x.tk.TaiKhoanNm,
                    DuCoDauKy = x.ddk.DuCoDauKy,
                    DuCoDauKyVND = x.ddk.DuCoDauKyVND,
                    DuCoDauNamVND = x.ddk.DuCoDauNamVND,
                    DuCoDauNam = x.ddk.DuCoDauNam,
                    DuNoDauKy = x.ddk.DuNoDauKy,
                    DuNoDauKyVND = x.ddk.DuNoDauKyVND,
                    DuNoDauNamVND = x.ddk.DuNoDauNamVND,
                    DuNoDauNam = x.ddk.DuNoDauNam,
                    IsNotTkCongNoOrTkVatTu = true

            }).FirstAsync();
                //Tài khoản công nợ
                var chuoiTaiKhoanCongNos = await _context.ThamSoHeThongs
                    .Where(x => x.ThamSoHeThongUd == "TK_CONG_NO" && !x.IsDeleted)
                    .ToListAsync();
                var taiKhoanCongNos = chuoiTaiKhoanCongNos.Where(tk => tk.GiaTri != null)
                    .SelectMany(tk =>
                    {
                        if (tk.GiaTri != null)
                        {
                            return tk.GiaTri.Replace(" ","").Split(',');
                        }
                        else
                        {
                            return Enumerable.Empty<string>();
                        }
                    }).ToList();
                //tài khoản vật tư
                var chuoiTaiKhoanVatTus = await _context.ThamSoHeThongs
                .Where(x => x.ThamSoHeThongUd == "TK_VAT_TU" && !x.IsDeleted)
                .ToListAsync();
                var taiKhoanVatTus = chuoiTaiKhoanVatTus.Where(tk => tk.GiaTri != null)
                    .SelectMany(tk =>
                    {
                        if (tk.GiaTri != null)
                        {
                            return tk.GiaTri.Replace(" ", "").Split(',');
                        }
                        else
                        {
                            return Enumerable.Empty<string>();
                        }
                    }).ToList();
                if (item.TaiKhoanUd != null && taiKhoanCongNos.Exists(x=> item.TaiKhoanUd.Contains(x)))
                {
                    var datas = await _context.DuDauKyCongNos.Where(x => !x.IsDeleted && x.TaiKhoanId == item.TaiKhoanId && x.ChiNhanhId == item.ChiNhanhId).ToListAsync();
                    item.IsNotTkCongNoOrTkVatTu = false;
                    item.DuNoDauKy = datas.Sum(x => x.DuNo);
                    item.DuCoDauKy = datas.Sum(x => x.DuCo);
                    item.DuNoDauKyVND = datas.Sum(x => x.DuNoVND);
                    item.DuCoDauKyVND = datas.Sum(x => x.DuCoVND);

                }
                else if (item.TaiKhoanUd != null && taiKhoanVatTus.Exists(x => item.TaiKhoanUd.Contains(x)))
                {
                    item.IsNotTkCongNoOrTkVatTu = false;
                    var datas = await _context.TonKhos.Where(x => !x.IsDeleted && x.TaiKhoanId == item.TaiKhoanId).ToListAsync();
                    item.IsNotTkCongNoOrTkVatTu = false;
                    item.DuNoDauKy = datas.Sum(x => x.Tien);
                    item.DuCoDauKy = 0;
                    item.DuNoDauKyVND = datas.Sum(x => x.TienVND);
                    item.DuCoDauKyVND = 0;
                }
                return item ?? new DuDauKyTkDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DuDauKyTkDto();
            }
        }

        public async Task<List<DuDauKyTkDto>> GetListAsync(DauKyRequest request, bool isDeleted = false)
        {
            if (!isDeleted)
            {
                var taiKhoans = await _taiKhoanService.GetListAsync();
                var taiKhoanIds = taiKhoans.Select(x => x.Id).ToList();
                // Lấy danh sách các TaiKhoanId đã tồn tại trong DuDauKyTk
                var existingTaiKhoanIds = await _context.DuDauKyTks
                                                  .Where(d => d.ChiNhanhId == request.ChiNhanhId && !d.IsDeleted)
                                                  .Select(d => d.TaiKhoanId)
                                                  .ToListAsync();
                // Lọc ra các TaiKhoanId chưa tồn tại
                var newTaiKhoanIds = taiKhoanIds.Except(existingTaiKhoanIds);
                if (newTaiKhoanIds.Any())
                {
                    // Tạo danh sách các đối tượng TaiKhoan cần insert
                    var newDuDauKyTks = newTaiKhoanIds.Select(id => new DuDauKyTk
                    {
                        TaiKhoanId = id,
                        ChiNhanhId = request.ChiNhanhId,
                        Ngay = request.Ngay,
                        DuCoDauKy = 0,
                        DuCoDauKyVND = 0,
                        DuCoDauNamVND = 0,
                        DuCoDauNam = 0,
                        DuNoDauKy = 0,
                        DuNoDauKyVND = 0,
                        DuNoDauNamVND = 0,
                        DuNoDauNam = 0,
                    }).ToList();
                    await _repository.InsertManyAsync(newDuDauKyTks, true);
                }
            }
            var query = from ddk in _context.DuDauKyTks
                        where !ddk.IsDeleted && ddk.ChiNhanhId == request.ChiNhanhId && (ddk.Ngay.HasValue && ddk.Ngay.Value.Year == request.Ngay.Year)
                        join tk in _context.TaiKhoans on ddk.TaiKhoanId equals tk.Id
                        where !tk.IsDeleted
                        select new { ddk, tk };
            var items = await query.Select(x => new DuDauKyTkDto
            {
                Id = x.ddk.Id,
                ChiNhanhId = x.ddk.ChiNhanhId,
                Ngay = x.ddk.Ngay,
                TaiKhoanId = x.ddk.TaiKhoanId,
                TaiKhoanNm = x.tk.TaiKhoanNm,
                TaiKhoanUd = x.tk.TaiKhoanUd,
                DuCoDauKy = x.ddk.DuCoDauKy,
                DuCoDauKyVND = x.ddk.DuCoDauKyVND,
                DuCoDauNamVND = x.ddk.DuCoDauNamVND,
                DuCoDauNam = x.ddk.DuCoDauNam,
                DuNoDauKy = x.ddk.DuNoDauKy,
                DuNoDauKyVND = x.ddk.DuNoDauKyVND,
                DuNoDauNamVND = x.ddk.DuNoDauNamVND,
                DuNoDauNam = x.ddk.DuNoDauNam,

            }).ToListAsync();
            return items ?? new List<DuDauKyTkDto>();
        }

        public async Task<List<TinhTongDto>> TinhTongAsync(int? taiKhoanId, List<DuDauKyTkDto> duDauKyTkDtos)
        {
            var tinhTongs = new List<TinhTongDto>();
            if (taiKhoanId.HasValue)
            {
                var item = duDauKyTkDtos.Find(x => x.TaiKhoanId == taiKhoanId);

                if (item != null)
                {
                    tinhTongs.AddRange(new[]
                    {
                        new TinhTongDto
                        {
                            DienGiai = "Dư nợ đầu kỳ",
                            Tien = item.DuNoDauKy,
                            TienVND = item.DuNoDauKyVND
                        },
                        new TinhTongDto
                        {
                            DienGiai = "Dư có đầu kỳ",
                            Tien = item.DuCoDauKy,
                            TienVND = item.DuCoDauKyVND
                        },
                        new TinhTongDto
                        {
                            DienGiai = "Dư nợ đầu năm",
                            Tien = item.DuNoDauNam,
                            TienVND = item.DuNoDauNamVND
                        },
                        new TinhTongDto
                        {
                            DienGiai = "Dư có đầu năm",
                            Tien = item.DuCoDauNam,
                            TienVND = item.DuCoDauNamVND
                        }
                    });
                }

            }
            else
            {
                var duNoDauKySum = duDauKyTkDtos.Sum(x => x.DuNoDauKy);
                var duNoDauKyVNDSum = duDauKyTkDtos.Sum(x => x.DuNoDauKyVND);
                var duCoDauKySum = duDauKyTkDtos.Sum(x => x.DuCoDauKy);
                var duCoDauKyVNDSum = duDauKyTkDtos.Sum(x => x.DuCoDauKyVND);
                var duNoDauNamSum = duDauKyTkDtos.Sum(x => x.DuNoDauNam);
                var duNoDauNamVNDSum = duDauKyTkDtos.Sum(x => x.DuNoDauNamVND);
                var duCoDauNamSum = duDauKyTkDtos.Sum(x => x.DuCoDauNam);
                var duCoDauNamVNDSum = duDauKyTkDtos.Sum(x => x.DuCoDauNamVND);

                tinhTongs = new List<TinhTongDto>
                {
                    new TinhTongDto
                    {
                        DienGiai = "Dư nợ đầu kỳ",
                        Tien = duNoDauKySum,
                        TienVND = duNoDauKyVNDSum
                    },
                    new TinhTongDto
                    {
                        DienGiai = "Dư có đầu kỳ",
                        Tien = duCoDauKySum,
                        TienVND = duCoDauKyVNDSum
                    },
                    new TinhTongDto
                    {
                        DienGiai = "Dư nợ đầu năm",
                        Tien = duNoDauNamSum,
                        TienVND = duNoDauNamVNDSum
                    },
                    new TinhTongDto
                    {
                        DienGiai = "Dư có đầu năm",
                        Tien = duCoDauNamSum,
                        TienVND = duCoDauNamVNDSum
                    }
                }.ToList();

            }
            return await Task.FromResult(tinhTongs);
        }

        public async Task<ApiResult> UpdateAsync(int? id, DuDauKyTkRequest request)
        {
            try
            {
                var item = ObjectMapper.Map(request, await _repository.GetAsync(id));
                await _repository.UpdateAsync(item, true);
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
