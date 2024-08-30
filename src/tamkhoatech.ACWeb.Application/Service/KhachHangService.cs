using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class KhachHangService : ApplicationService, IKhachHangService
    {
        public readonly IRepository<KhachHang, int?> _repository;
        public readonly IRepository<NhomKhachHang, int?> _nhomKhachRepository;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanhRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;
        public readonly IRepository<DuDauKyCongNo, int?> _duDauKyCongNoRepository;
        public readonly IRepository<PhieuThu, int?> _phieuThuRepository;
        public readonly IRepository<PhieuThuCT, int> _phieuThuCtRepository;
        public readonly IRepository<PhieuChi, int?> _phieuChiRepository;
        public readonly IRepository<PhieuChiCT, int> _phieuChiCtRepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGTGTRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<VuViec, int?> _vuViecRepository;
        public readonly IRepository<PhieuNhap, int?> _phieuNhapRepository;
        public readonly IRepository<PhieuXuat, int?> _phieuXuatRepository;
        public readonly IUtilitiesService _utilitiesService;
        public KhachHangService(IRepository<KhachHang, int?> repository, IRepository<NhomKhachHang, int?> nhomKhachRepository, IRepository<TaiKhoan, int?> taiKhoanhRepository, IRepository<SoCai, int?> soCaiRepository, IRepository<TheKho, int?> theKhoRepository, IRepository<DuDauKyCongNo, int?> duDauKyCongNoRepository
                                , IRepository<PhieuThu, int?> phieuThuRepository, IRepository<PhieuThuCT, int> phieuThuCtRepository,IRepository<PhieuChi, int?> phieuChiRepository, IRepository<PhieuChiCT, int> phieuChiCtRepository, IRepository<HoaDonGtgt, int> hoaDonGTGTRepository, IRepository<VuViec, int?> vuViecRepository
                                , IRepository<PhieuNhap, int?> phieuNhapRepository, IRepository<PhieuXuat, int?> phieuXuatRepository, IUtilitiesService utilitiesService)
        {
            _repository = repository;
            _nhomKhachRepository = nhomKhachRepository;
            _taiKhoanhRepository = taiKhoanhRepository;
            _soCaiRepository = soCaiRepository;
            _theKhoRepository = theKhoRepository;
            _duDauKyCongNoRepository = duDauKyCongNoRepository;
            _phieuThuRepository = phieuThuRepository;
            _phieuThuCtRepository = phieuThuCtRepository;
            _hoaDonGTGTRepository = hoaDonGTGTRepository;
            _phieuChiRepository = phieuChiRepository;
            _phieuChiCtRepository = phieuChiCtRepository;
            _vuViecRepository = vuViecRepository;
            _phieuNhapRepository = phieuNhapRepository;
            _phieuXuatRepository = phieuXuatRepository;
            _utilitiesService = utilitiesService;
        }
        public async Task<ApiResult> CreateAsync(KhachHangRequest request)
        {
            try
            {
                var count = await _repository.CountAsync(x => x.KhachHangUd == request.KhachHangUd);
            if (count > 0)
            {
                return new ApiResult() { IsSuccessed = false, Message="Mã khách hàng đã tồn tại!" };
            }

                var item = ObjectMapper.Map<KhachHangRequest, KhachHang>(request);
                await _repository.InsertAsync(item, true);
                return new ApiResult() { IsSuccessed = true, Message = "Thêm mới thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ."};
            }
        }

        public async Task<ApiResult> DeleteAsync(int id)
        {
            try
            {
                var check = await CheckPhatSinh(id);
                if (!check)
                    return new ApiResult() { IsSuccessed = false, Message = "Đã có phát sinh, không xóa được!" };
                else
                {
                    await _repository.DeleteAsync(id);
                    return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công!" };
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
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
                        namesBuilder.Append(kh.KhachHangUd).Append(", ");
                    }
                    else
                    {
                        await _repository.DeleteAsync(id);
                    }
                }
                string names = namesBuilder.ToString().TrimEnd(',', ' ');
                return !string.IsNullOrEmpty(names) ? new ApiResult() { IsSuccessed = false, Message =$"Mã khách hàng <b>{names}</b> đã có phát sinh!"} : new ApiResult() { IsSuccessed = true, Message = "Xóa thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<KhachHangDto> GetByIdAsync(int? id)
        {
            KhachHangDto kh = new KhachHangDto();
            try
            {
                kh = ObjectMapper.Map<KhachHang, KhachHangDto>(await _repository.GetAsync(id));
                if (kh.NhomKhachHang1.HasValue)
                {
                    var nhomKH1 = await _nhomKhachRepository.FirstOrDefaultAsync(x=>x.Id == kh.NhomKhachHang1);
                    kh.NhomKhachHangUd1 = nhomKH1?.NhomKhachHangUd;
                    kh.NhomKhachHangNm1 = nhomKH1?.NhomKhachHangNm;
                }
                if (kh.NhomKhachHang2.HasValue)
                {
                    var nhomKH2 = await _nhomKhachRepository.FirstOrDefaultAsync(x => x.Id == kh.NhomKhachHang2);
                    kh.NhomKhachHangUd2 = nhomKH2?.NhomKhachHangUd;
                    kh.NhomKhachHangNm2 = nhomKH2?.NhomKhachHangNm;
                }
                if (kh.NhomKhachHang2.HasValue)
                {
                    var nhomKH3 = await _nhomKhachRepository.FirstOrDefaultAsync(x => x.Id == kh.NhomKhachHang1);
                    kh.NhomKhachHangUd3 = nhomKH3?.NhomKhachHangUd;
                    kh.NhomKhachHangNm3 = nhomKH3?.NhomKhachHangNm;
                }
                if (kh.TkNgamDinh.HasValue)
                {
                    var tk = await _taiKhoanhRepository.FirstOrDefaultAsync(x => x.Id == kh.TkNgamDinh);
                    kh.TkNgamDinhNm = tk?.TaiKhoanNm;
                }
                if (kh.TkKho.HasValue)
                {
                    var tk = await _taiKhoanhRepository.FirstOrDefaultAsync(x => x.Id == kh.TkKho);
                    kh.TkKhoNm = tk?.TaiKhoanNm;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(kh != null)
                return kh;
            return new KhachHangDto();
        }

        public async Task<List<KhachHangDto>> GetListAsync(int loai)
        {
          
            try
            {
                var khs = new List<KhachHangDto>();
                if (loai == 0)
                    khs = ObjectMapper.Map<List<KhachHang>, List<KhachHangDto>>(await _repository.GetListAsync(x => x.Loai == 0));
                else
                    khs = ObjectMapper.Map<List<KhachHang>, List<KhachHangDto>>(await _repository.GetListAsync(x => x.Loai == 0 || x.Loai == loai));
                foreach (var item in khs)
                {
                    var nhomKH1 = await _nhomKhachRepository.FirstOrDefaultAsync(x => x.Id == item.NhomKhachHang1);
                    var nhomKH2 = await _nhomKhachRepository.FirstOrDefaultAsync(x => x.Id == item.NhomKhachHang2);
                    var nhomKH3 = await _nhomKhachRepository.FirstOrDefaultAsync(x => x.Id == item.NhomKhachHang3);
                    item.NhomKhachHangUd1 = nhomKH1?.NhomKhachHangUd;
                    item.NhomKhachHangUd2 = nhomKH2?.NhomKhachHangUd;
                    item.NhomKhachHangUd3 = nhomKH3?.NhomKhachHangUd;
                }
                return khs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<KhachHangDto>();
            }
        }
        public async Task<ApiResult> UpdateAsync(int? id, KhachHangRequest request)
        {
            try
            {
                var khachhang = await _repository.GetAsync(id);
                if(khachhang.Loai != request.Loai && request.Loai !=0)
                {
                    var pt = await _phieuThuRepository.CountAsync(x => x.KhachHangId == id);
                    var pc = await _phieuChiRepository.CountAsync(x => x.KhachHangId == id);
                    if (pt + pc > 0)
                    {
                        return new ApiResult() { IsSuccessed = false, Message = "Khách hàng này đã có phát sinh, bạn chỉ có thể đổi thành <b>Khách hàng - Nhà cung cấp</b>." };
                    }
                }
                var count = await _repository.CountAsync(x => x.KhachHangUd == request.KhachHangUd);
                if (count > 0 && request.KhachHangUd != khachhang.KhachHangUd)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Mã khách hàng đã tồn tại!" };
                }
                var item = ObjectMapper.Map(request, khachhang);
                await _repository.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
            return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công!" };
        }

        public async Task<List<NhomKhachHangDto>> GetListNhomKhachHangAsync(int loai)
        {
            return ObjectMapper.Map<List<NhomKhachHang>, List<NhomKhachHangDto>>(await _nhomKhachRepository.GetListAsync(x => x.KieuPhanNhom == loai));
        }

        public async Task<string[]> TraCuuAsync(string mst)
        {
            try
            {
                string[] data = new string[5];
                TraCuuMaSoThue _tracuu = new TraCuuMaSoThue(mst);
                var thongTin = await _tracuu.TraCuu();
                data[0] = thongTin[0];
                data[1] = thongTin[1];
                data[2] = thongTin[2];
                data[3] = thongTin[3];
                var trngThai = await _tracuu.Kiem_tra_cks_mInvoice_extra_info_MST(mst);
                data[4] = trngThai;
                return data;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return new string[5];
            }

        }

        public async Task<KhachHangDto?> GetByKhachHangUdAsync(string khachHangUd)
        {
            try
            {
                return ObjectMapper.Map<KhachHang, KhachHangDto>(await _repository.GetAsync(x => x.KhachHangUd == khachHangUd));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<ApiResult> GopMaAsync(int? id, int newId, string? newKhachHangUd)
        {
            if( newId != 0)
            {
                var phieuThus = await _phieuThuRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in phieuThus)
                {
                    item.KhachHangId = newId;
                }
                await _phieuThuRepository.UpdateManyAsync(phieuThus);
                var phieuThuCts = await _phieuThuCtRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in phieuThuCts)
                {
                    item.KhachHangId = newId;
                }
                await _phieuThuCtRepository.UpdateManyAsync(phieuThuCts);
                var phieuChis = await _phieuChiRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in phieuChis)
                {
                    item.KhachHangId = newId;
                }
                await _phieuChiRepository.UpdateManyAsync(phieuChis);
                var phieuChiCts = await _phieuChiCtRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in phieuChiCts)
                {
                    item.KhachHangId = newId;
                }
                await _phieuChiCtRepository.UpdateManyAsync(phieuChiCts);
                var hoaDonGTGTs = await _hoaDonGTGTRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in hoaDonGTGTs)
                {
                    item.KhachHangId = newId;
                }
                await _hoaDonGTGTRepository.UpdateManyAsync(hoaDonGTGTs);
                var soCais = await _soCaiRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in soCais)
                {
                    item.KhachHangId = newId;
                }
                await _soCaiRepository.UpdateManyAsync(soCais);
                var vuViecs = await _vuViecRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in vuViecs)
                {
                    item.KhachHangId = newId;
                }
                await _vuViecRepository.UpdateManyAsync(vuViecs);
                var phieuNhaps = await _phieuNhapRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in phieuNhaps)
                {
                    item.KhachHangId = newId;
                }
                await _phieuNhapRepository.UpdateManyAsync(phieuNhaps);
                var phieuXuats = await _phieuXuatRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in phieuXuats)
                {
                    item.KhachHangId = newId;
                }
                await _phieuXuatRepository.UpdateManyAsync(phieuXuats);
                var theKhos = await _theKhoRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in theKhos)
                {
                    item.KhachHangId = newId;
                }
                await _theKhoRepository.UpdateManyAsync(theKhos);
                var duDauKyCongNos = await _duDauKyCongNoRepository.GetListAsync(x => x.KhachHangId == id);
                foreach (var item in duDauKyCongNos)
                {
                    item.KhachHangId = newId;
                }
                await _duDauKyCongNoRepository.UpdateManyAsync(duDauKyCongNos);

                await _repository.DeleteAsync(id);
            }
            else
            {
                var khachhang = await _repository.GetAsync(id);
                khachhang.KhachHangUd = newKhachHangUd;
                await _repository.UpdateAsync(khachhang);
            }
            return new ApiResult() { IsSuccessed = true };
        }

        public async Task<bool> CheckPhatSinh(int? id)
        {
            var soCai = await _soCaiRepository.CountAsync(x => x.KhachHangId == id);
            var theKho = await _theKhoRepository.CountAsync(x => x.KhachHangId == id);
            var duDauKyCongNo = await _duDauKyCongNoRepository.CountAsync(x => x.KhachHangId == id);
            var vuViec = await _vuViecRepository.CountAsync(x => x.KhachHangId == id);
            var phieuNhap = await _phieuNhapRepository.CountAsync(x => x.KhachHangId == id);
            var phieuXuat = await _phieuNhapRepository.CountAsync(x => x.KhachHangId == id);
            if (soCai > 0 || theKho > 0 || duDauKyCongNo > 0 || vuViec > 0 || phieuNhap > 0 || phieuXuat >0)
                return false;
            else
            {
                return true;
            }
        }

        public byte[] ExportExcel(List<KhachHangDto> requests, string titleName)
        {
            var package = _utilitiesService.CreateExcelTemplate(requests.Count, 13, titleName);
            var worksheet = package.Workbook.Worksheets[titleName];

            // Tạo tên cột
            worksheet.Cells[4, 1].Value = "Mã khách";
            worksheet.Cells[4, 2].Value = "Tên khách";
            worksheet.Cells[4, 3].Value = "Mã số thuế";
            worksheet.Cells[4, 4].Value = "Địa chỉ";
            worksheet.Cells[4, 5].Value = "Số điện thoại";
            worksheet.Cells[4, 6].Value = "Fax";
            worksheet.Cells[4, 7].Value = "Email";
            worksheet.Cells[4, 8].Value = "Đối tác";
            worksheet.Cells[4, 9].Value = "STK ngân hàng";
            worksheet.Cells[4, 10].Value = "Tên ngân hàng";
            worksheet.Cells[4, 11].Value = "Tỉnh thành";
            worksheet.Cells[4, 12].Value = "Ghi chú";
            worksheet.Cells[4, 13].Value = "Tên 2";
            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 16;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 16;
            worksheet.Column(4).Width = 50;
            worksheet.Column(5).Width = 16;
            worksheet.Column(6).Width = 16;
            worksheet.Column(7).Width = 30;
            worksheet.Column(8).Width = 30;
            worksheet.Column(9).Width = 16;
            worksheet.Column(10).Width = 30;
            worksheet.Column(11).Width = 30;
            worksheet.Column(12).Width = 30;
            worksheet.Column(13).Width = 30;
            worksheet.Cells[2, 1, 2, 7].Merge = true;//Set vị trí hiển thị title ==> Tổng width của cột phải không quá 210
            //Đọc dữ liệu
            int rowStart = 5; // bắt đầu từ row 5
            if (requests.Count > 0)
            {
                foreach (var item in requests)
                {
                    worksheet.Cells[rowStart, 1].Value = item.KhachHangUd;
                    worksheet.Cells[rowStart, 2].Value = item.KhachHangNm;
                    worksheet.Cells[rowStart, 3].Value = item.MaSoThue;
                    worksheet.Cells[rowStart, 4].Value = item.DiaChi;
                    worksheet.Cells[rowStart, 5].Value = item.DienThoai;
                    worksheet.Cells[rowStart, 6].Value = item.Fax;
                    worksheet.Cells[rowStart, 7].Value = item.Email;
                    worksheet.Cells[rowStart, 8].Value = item.DoiTac;
                    worksheet.Cells[rowStart, 9].Value = item.TkNganHang;
                    worksheet.Cells[rowStart, 10].Value = item.TenNganHang;
                    worksheet.Cells[rowStart, 11].Value = item.TinhThanh;
                    worksheet.Cells[rowStart, 12].Value = item.GhiChu;
                    worksheet.Cells[rowStart, 13].Value = item.KhachHangNm2;
                    rowStart++;
                }
            }

            return package.GetAsByteArray();
        }
    }
}
