using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace tamkhoatech.ACWeb.Service
{
    public class VatTuService : ApplicationService, IVatTuService
    {
        public readonly IRepository<VatTu, int?> _repository;
        public readonly IRepository<DMChung, int?> _danhMucChungRepository;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public readonly IRepository<PhieuNhap, int?> _phieuNhapRepository;
        public readonly IRepository<PhieuNhapCT, int> _phieuNhapCtRepository;
        public readonly IRepository<NhomVatTu, int?> _nhomVatTuRepository;
        public readonly IRepository<Kho, int?> _khoRepository;
        public readonly IRepository<PhanBoChiPhi, int> _phanBoChiPhiRepository;
        public readonly IRepository<PhanBoChietKhauThuongMai, int> _phanBoChietKhauThuongMaiRepository;
        public readonly IUtilitiesService _utilitiesService;
        public VatTuService(IRepository<VatTu, int?> repository, IRepository<DMChung, int?> danhMucChungRepository, IRepository<TaiKhoan, int?> taiKhoanRepository, IRepository<PhieuNhap, int?> phieuNhapRepository, 
            IRepository<PhieuNhapCT, int> phieuNhapCtRepository, IRepository<NhomVatTu, int?> nhomVatTuRepository, IRepository<Kho, int?> khoRepository, IRepository<PhanBoChiPhi, int> phanBoChiPhiRepository, IUtilitiesService utilitiesService,
            IRepository<PhanBoChietKhauThuongMai, int> phanBoChietKhauThuongMaiRepository)
        {
            _repository = repository;
            _danhMucChungRepository = danhMucChungRepository;
            _taiKhoanRepository = taiKhoanRepository;
            _phieuNhapRepository = phieuNhapRepository;
            _phieuNhapCtRepository = phieuNhapCtRepository;
            _nhomVatTuRepository = nhomVatTuRepository;
            _khoRepository = khoRepository;
            _phanBoChiPhiRepository = phanBoChiPhiRepository;
            _phanBoChietKhauThuongMaiRepository = phanBoChietKhauThuongMaiRepository;
            _utilitiesService = utilitiesService;
        }

        public async Task<List<VatTuDto>> GetListAsync(string? danhMucChungUd)
        {
            try
            {
                if (danhMucChungUd.IsNullOrEmpty())
                {
                    var items = ObjectMapper.Map<List<VatTu>, List<VatTuDto>>(await _repository.GetListAsync());
                    foreach (var item in items)
                    {
                        if (item.TkKho.HasValue && item.TkKho.Value != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x=>x.Id == item.TkKho);
                            item.TkKhoUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                        }
                        else
                            item.TkKhoUd = SystemConstants.NA;
                        if (item.TkGiaVon.HasValue && item.TkGiaVon.Value != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkGiaVon);
                            item.TkGiaVonUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                        }
                        else
                            item.TkGiaVonUd = SystemConstants.NA;
                        if (item.TkDoanhThu.HasValue && item.TkDoanhThu.Value != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkDoanhThu);
                            item.TkDoanhThuUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                        }
                        else
                            item.TkDoanhThuUd = SystemConstants.NA;
                        if (item.TkHangBiTra.HasValue && item.TkHangBiTra.Value != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkHangBiTra);
                            item.TkHangBiTraUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                        }
                        else
                            item.TkHangBiTraUd = SystemConstants.NA;
                        if (item.TkSpDoDang.HasValue && item.TkSpDoDang.Value != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkSpDoDang);
                            item.TkSpDoDangUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                        }
                        else
                            item.TkSpDoDangUd = SystemConstants.NA;
                        if (item.TkChenhLechGiaVt.HasValue && item.TkChenhLechGiaVt.Value != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkChenhLechGiaVt);
                            item.TkChenhLechGiaVtUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                        }
                        else
                            item.TkChenhLechGiaVtUd = SystemConstants.NA;
                    }
                    return items;
                }
                else
                {
                    var res = await _danhMucChungRepository.GetAsync(x => x.DMChungUd == danhMucChungUd);
                    if (res == null)
                        return new List<VatTuDto>();
                    return ObjectMapper.Map<List<VatTu>, List<VatTuDto>>(await _repository.GetListAsync(x => x.LoaiVatTu == res.Id));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<VatTuDto>();
            }
        }

        public async Task<VatTuDto> GetByIdAsync(int? id)
        {
            var item = new VatTuDto();
            try
            {
                item = ObjectMapper.Map<VatTu, VatTuDto>(await _repository.GetAsync(id));

                if (item.LoaiVatTu.HasValue && item.LoaiVatTu != 0)
                {
                    var dm = await _danhMucChungRepository.FirstOrDefaultAsync(x => x.Id == item.LoaiVatTu);
                    item.LoaiVatTuNm = dm?.DMChungNm;
                }
                if (item.TkKho.HasValue && item.TkKho != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x=>x.Id == item.TkKho);
                    item.TkKhoNm = tk?.TaiKhoanNm;
                }
                if (item.TkGiaVon.HasValue && item.TkGiaVon != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkGiaVon);
                    item.TkGiaVonNm = tk?.TaiKhoanNm;
                }
                if (item.TkDoanhThu.HasValue && item.TkDoanhThu != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkDoanhThu);
                    item.TkDoanhThuNm = tk?.TaiKhoanNm;
                }
                if (item.TkHangBiTra.HasValue && item.TkHangBiTra != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkHangBiTra);
                    item.TkHangBiTraNm = tk?.TaiKhoanNm;
                }
                if (item.TkSpDoDang.HasValue && item.TkSpDoDang != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkSpDoDang);
                    item.TkSpDoDangNm = tk?.TaiKhoanNm;
                }
                if (item.TkChenhLechGiaVt.HasValue && item.TkChenhLechGiaVt != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkChenhLechGiaVt);
                    item.TkChenhLechGiaVtNm = tk?.TaiKhoanNm;
                }
                if (item.NhomVT1.HasValue && item.NhomVT1 != 0)
                {
                    var nvt = await _nhomVatTuRepository.FirstOrDefaultAsync(x => x.Id == item.NhomVT1);
                    item.NhomVtNm1 = nvt?.NhomVatTuNm;
                }
                if (item.NhomVT2.HasValue && item.NhomVT2 != 0)
                {
                    var nvt = await _nhomVatTuRepository.FirstOrDefaultAsync(x => x.Id == item.NhomVT2);
                    item.NhomVtNm2 = nvt?.NhomVatTuNm;
                }
                if (item.NhomVT3.HasValue && item.NhomVT3 != 0)
                {
                    var nvt = await _nhomVatTuRepository.FirstOrDefaultAsync(x => x.Id == item.NhomVT3);
                    item.NhomVtNm3 = nvt?.NhomVatTuNm;
                }
                if (item.KhoId.HasValue && item.KhoId != 0)
                {
                    var k = await _khoRepository.FirstOrDefaultAsync(x => x.Id == item.KhoId);
                    item.KhoNm = k?.KhoNm;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return item;
        }

        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                StringBuilder namesBuilder = new StringBuilder();
                foreach (var id in ids)
                {
                  var check = await CheckPhatSinh(id);
                    if (!check)
                    {
                        var kh = await _repository.GetAsync(id);
                        namesBuilder.Append(kh.VatTuUd).Append(", ");
                    }
                    else
                    {
                        await _repository.DeleteAsync(id);
                    }
                }
                string names = namesBuilder.ToString().TrimEnd(',', ' ');
                return !string.IsNullOrEmpty(names) ? new ApiResult() { IsSuccessed = false, Message = $"Mã vật tư <b>{names}</b> đã có phát sinh!" } : new ApiResult() { IsSuccessed = true, Message = "Xóa thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<List<NhomVatTuDto>> GetListNhomVatTuAsync(int? kieuPhanNhom)
        {
            return ObjectMapper.Map<List<NhomVatTu>, List<NhomVatTuDto>>(await _nhomVatTuRepository.GetListAsync(x=>x.KieuPhanNhom == kieuPhanNhom));
        }

        public async Task<ApiResult> CreateAsync(VatTuRequest request)
        {

            try
            {
                var count = await _repository.CountAsync(x => x.VatTuUd == request.VatTuUd);
                if (count > 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Mã vật tư đã tồn tại!" };
                }
                var item = ObjectMapper.Map<VatTuRequest, VatTu>(request);
                await _repository.InsertAsync(item, true);
                return new ApiResult() { IsSuccessed = true, Message = "Thêm mới thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> UpdateAsync(int? id, VatTuRequest request)
        {
            try
            {
                var vatTu = await _repository.GetAsync(id);
                var count = await _repository.CountAsync(x => x.VatTuUd == request.VatTuUd);
                if (count > 0 && request.VatTuUd != vatTu.VatTuUd)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Mã vật tư đã tồn tại!" };
                }
                var item = ObjectMapper.Map(request, vatTu);

                await _repository.UpdateAsync(item);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<VatTuDto?> GetByVatTuUdAsync(string vatTuUd)
        {
            try
            {
                var vt = await _repository.FirstOrDefaultAsync(x => x.VatTuUd == vatTuUd);              
                return vt == null ? null : ObjectMapper.Map<VatTu, VatTuDto>(vt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<ApiResult> GopMaAsync(int? id, int newId, string? newVatTuUd)
        {
            if(newId != 0)
            {
                var vatTuCts = await _phieuNhapCtRepository.GetListAsync(x => x.VatTuId == id);
                foreach (var item in vatTuCts)
                {
                    item.VatTuId = newId;
                }
                await _phieuNhapCtRepository.UpdateManyAsync(vatTuCts);
                var phanBoChiPhis = await _phanBoChiPhiRepository.GetListAsync(x => x.VatTuId == id);
                foreach (var item in phanBoChiPhis)
                {
                    item.VatTuId = newId;
                }
                await _phanBoChiPhiRepository.UpdateManyAsync(phanBoChiPhis);
                var phanBoChiPhiThuongMai = await _phanBoChietKhauThuongMaiRepository.GetListAsync(x => x.VatTuId == id);
                foreach (var item in phanBoChiPhiThuongMai)
                {
                    item.VatTuId = newId;
                }
                await _phanBoChietKhauThuongMaiRepository.UpdateManyAsync(phanBoChiPhiThuongMai);
                await _repository.DeleteAsync(id);
            }
            else
            {
                var vatTu = await _repository.GetAsync(id);
                vatTu.VatTuUd = newVatTuUd;
                await _repository.UpdateAsync(vatTu);
            }

            return new ApiResult() { IsSuccessed = true };
        }

        public async Task<bool> CheckPhatSinh(int? id)
        {
            var phieuNhapCt = await _phieuNhapCtRepository.CountAsync(x => x.VatTuId == id);
            var phanBoChiPhi = await _phanBoChiPhiRepository.CountAsync(x => x.VatTuId == id);
            var phanBoChiPhiThuongMai = await _phanBoChietKhauThuongMaiRepository.CountAsync(x => x.VatTuId == id);
            if (phieuNhapCt > 0 || phanBoChiPhi > 0 || phanBoChiPhiThuongMai > 0)
            {
                return false;
            }
            else
            {
               return true;
            }
        }

        public byte[] ExportExcel(List<VatTuDto> requests, string titleName)
        {
            var package = _utilitiesService.CreateExcelTemplate(requests.Count, 15, titleName);
            var worksheet = package.Workbook.Worksheets[titleName];

            // Tạo tên cột
            worksheet.Cells[4, 1].Value = "Mã vật tư";
            worksheet.Cells[4, 2].Value = "Tên vật tư";
            worksheet.Cells[4, 3].Value = "Đơn vị tính";
            worksheet.Cells[4, 4].Value = "Nhóm vật tư 1";
            worksheet.Cells[4, 5].Value = "Nhóm vật tư 2";
            worksheet.Cells[4, 6].Value = "Nhóm vật tư 3";
            worksheet.Cells[4, 7].Value = "Cách tính giá";
            worksheet.Cells[4, 8].Value = "Tk vật tư";
            worksheet.Cells[4, 9].Value = "Tk giá vốn";
            worksheet.Cells[4, 10].Value = "Tk doanh thu";
            worksheet.Cells[4, 11].Value = "Tk hàng bán trả lại";
            worksheet.Cells[4, 12].Value = "Tk sản phẩm dở dang";
            worksheet.Cells[4, 13].Value = "Tk chênh lệch giá vt";
            worksheet.Cells[4, 14].Value = "Ghi chú";
            worksheet.Cells[4, 15].Value = "Tên 2";
            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 16;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 12;
            worksheet.Column(4).Width = 12;
            worksheet.Column(5).Width = 12;
            worksheet.Column(6).Width = 12;
            worksheet.Column(7).Width = 12;
            worksheet.Column(8).Width = 12;
            worksheet.Column(9).Width = 12;
            worksheet.Column(10).Width = 12;
            worksheet.Column(11).Width = 16;
            worksheet.Column(12).Width = 16;
            worksheet.Column(13).Width = 16;
            worksheet.Column(14).Width = 30;
            worksheet.Column(15).Width = 30;
            worksheet.Cells[2, 1, 2, 13].Merge = true;//Set vị trí hiển thị title ==> Tổng width của cột phải không quá 210
            //Đọc dữ liệu
            int rowStart = 5; // bắt đầu từ row 5
            if (requests.Count > 0)
            {
                foreach (var item in requests)
                {
                    worksheet.Cells[rowStart, 1].Value = item.VatTuUd;
                    worksheet.Cells[rowStart, 2].Value = item.VatTuNm;
                    worksheet.Cells[rowStart, 3].Value = item.DonViTinh;
                    worksheet.Cells[rowStart, 4].Value = item.NhomVT1;
                    worksheet.Cells[rowStart, 5].Value = item.NhomVT2;
                    worksheet.Cells[rowStart, 6].Value = item.NhomVT3;
                    worksheet.Cells[rowStart, 7].Value = item.CachTinhGia;
                    worksheet.Cells[rowStart, 8].Value = item.TkKhoUd;
                    worksheet.Cells[rowStart, 9].Value = item.TkGiaVonUd;
                    worksheet.Cells[rowStart, 10].Value = item.TkDoanhThuUd;
                    worksheet.Cells[rowStart, 11].Value = item.TkHangBiTraUd;
                    worksheet.Cells[rowStart, 12].Value = item.TkSpDoDangUd;
                    worksheet.Cells[rowStart, 13].Value = item.TkChenhLechGiaVtUd;
                    worksheet.Cells[rowStart, 14].Value = item.GhiChu;
                    worksheet.Cells[rowStart, 15].Value = item.VatTuNm2;
                    rowStart++;
                }
            }

            return package.GetAsByteArray();
        }
    }
}
