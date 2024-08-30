using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuNhapService : ApplicationService, IPhieuNhapService
    {
        public readonly IRepository<PhieuNhap, int?> _repository;
        public readonly IRepository<PhieuNhapCT, int> _phieuNhapCtRepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGtgtRepository;
        public readonly IRepository<PhanBoChietKhauThuongMai, int> _phanBoChietKhauThuongMaiRepository;
        public readonly IRepository<PhanBoChiPhi, int> _phanBoChiPhiRepository;
        public readonly IRepository<PhanBoThueNk, int> _phanBoThueNkRepository;
        public readonly IRepository<NgoaiTe, int?> _ngoaiTeRepository;
        public readonly IRepository<KhachHang, int?> _khachHangRepository;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<VatTu, int?> _vatTuRepository;
        public readonly IRepository<Kho, int?> _khoRepository;
        public readonly IRepository<DMChung, int?> _dmChungRepository;
        public readonly IRepository<VuViec, int?> _vuViecRepository;
        public readonly IRepository<DmMaPhi, int?> _dmMaPhiRepository;
        public readonly IRepository<DmTruongTuDo, int?> _dmTruongTuDoRepository;
        public readonly IRepository<HoaDonMuaHang, int> _hoaDonMuaHangRepository;
        public readonly IRepository<ChiNhanh, int?> _chiNhanhRepository;
        public readonly IPhieuChiService _phieuChiService;
        public readonly ACWebDbContext _context;
        public PhieuNhapService(IRepository<PhieuNhap, int?> repository, IRepository<NgoaiTe, int?> ngoaiTeRepository,
            IRepository<KhachHang, int?> khachHangRepository, IRepository<TaiKhoan, int?> taiKhoanRepository,
            IRepository<PhieuNhapCT, int> phieuNhapCtRepository, IRepository<SoCai, int?> soCaiRepository, IRepository<VatTu, int?> vatTuRepository,
            IRepository<Kho, int?> khoRepository, IRepository<HoaDonGtgt, int> hoaDonGtgtRepository, IRepository<PhanBoChietKhauThuongMai, int> phanBoChietKhauThuongMaiRepository,
            IRepository<PhanBoChiPhi, int> phanBoChiPhiRepository, IRepository<DMChung, int?> dmChungRepository, IRepository<VuViec, int?> vuViecRepository, IRepository<DmMaPhi, int?> dmMaPhiRepository, 
            IRepository<DmTruongTuDo, int?> dmTruongTuDoRepository, IRepository<PhanBoThueNk, int> phanBoThueNkRepository, IRepository<HoaDonMuaHang, int> hoaDonMuaHangRepository, IRepository<ChiNhanh, int?> chiNhanhRepository, IPhieuChiService phieuChiService, ACWebDbContext context)
        {
            _repository = repository;
            _ngoaiTeRepository = ngoaiTeRepository;
            _khachHangRepository = khachHangRepository;
            _taiKhoanRepository = taiKhoanRepository;
            _phieuNhapCtRepository = phieuNhapCtRepository;
            _soCaiRepository = soCaiRepository;
            _vatTuRepository = vatTuRepository;
            _khoRepository = khoRepository;
            _hoaDonGtgtRepository = hoaDonGtgtRepository;
            _phanBoChietKhauThuongMaiRepository = phanBoChietKhauThuongMaiRepository;
            _phanBoChiPhiRepository = phanBoChiPhiRepository;
            _dmChungRepository = dmChungRepository;
            _vuViecRepository = vuViecRepository;
            _dmMaPhiRepository = dmMaPhiRepository;
            _dmTruongTuDoRepository = dmTruongTuDoRepository;
            _phanBoThueNkRepository = phanBoThueNkRepository;
            _hoaDonMuaHangRepository = hoaDonMuaHangRepository;
            _chiNhanhRepository = chiNhanhRepository;
            _phieuChiService = phieuChiService;
            _context = context;
        }

        public async Task<int?> CreateAsync(PhieuNhapRequest request)
        {
            try
            {
                var phieuNhapCt = new List<PhieuNhapCT>();
                if (request.PhieuNhapCtRequests != null)
                {
                    phieuNhapCt = ObjectMapper.Map<List<PhieuNhapCtRequest>, List<PhieuNhapCT>>(request.PhieuNhapCtRequests);
                }
                var hoaDonGTGTs = new List<HoaDonGtgt>();
                if (request.HoaDonRequests != null)
                {
                    hoaDonGTGTs = ObjectMapper.Map<List<HoaDonRequest>, List<HoaDonGtgt>>(request.HoaDonRequests);
                }
                var phanBoChietKhauThuongMais = new List<PhanBoChietKhauThuongMai>();
                if (request.PhanBoChietKhauThuongMaiRequests != null)
                {
                    phanBoChietKhauThuongMais = ObjectMapper.Map<List<PhanBoChietKhauThuongMaiRequest>, List<PhanBoChietKhauThuongMai>>(request.PhanBoChietKhauThuongMaiRequests);
                }
                var phanBoChiPhis = new List<PhanBoChiPhi>();
                if (request.PhanBoChiPhiRequests != null)
                {
                    phanBoChiPhis = ObjectMapper.Map<List<PhanBoChiPhiRequest>, List<PhanBoChiPhi>>(request.PhanBoChiPhiRequests);
                }
                var phanBoThueNk = new List<PhanBoThueNk>();
                if (request.PhanBoThueNkRequests != null)
                {
                    phanBoThueNk = ObjectMapper.Map<List<PhanBoThueNkRequest>, List<PhanBoThueNk>>(request.PhanBoThueNkRequests);
                }
                var hoaDonMuaHangs = new List<HoaDonMuaHang>();
                if (request.HoaDonMuaHangRequests != null)
                {
                    hoaDonMuaHangs = ObjectMapper.Map<List<HoaDonMuaHangRequest>, List<HoaDonMuaHang>>(request.HoaDonMuaHangRequests);
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }

                var phieuNhap = ObjectMapper.Map<PhieuNhapRequest, PhieuNhap>(request);
                phieuNhap.PhieuNhapCTs = phieuNhapCt;
                phieuNhap.HoaDonGtgts = hoaDonGTGTs;
                phieuNhap.SoCais = soCais;
                phieuNhap.PhanBoChietKhauThuongMais = phanBoChietKhauThuongMais;
                phieuNhap.PhanBoChiPhis = phanBoChiPhis;
                phieuNhap.PhanBoThueNks = phanBoThueNk;
                phieuNhap.HoaDonMuaHangs = hoaDonMuaHangs;
                var result = await _repository.InsertAsync(phieuNhap, true);
                return result.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }

        }

        public async Task<ApiResult> DeleteAsync(int? id)
        {
            try
            {
                var phieuchi = await _context.PhieuChis.FirstOrDefaultAsync(x=>x.PhieuNhapId == id && !x.IsDeleted);
                if(phieuchi != null)
                    await _phieuChiService.DeleteAsync(phieuchi.Id);
                await _soCaiRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phieuNhapCtRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _hoaDonGtgtRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phanBoChietKhauThuongMaiRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phanBoChiPhiRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phanBoThueNkRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _hoaDonMuaHangRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _repository.DeleteAsync(id);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                var phieuChiIds = await _context.PhieuChis.Where(x => ids.Contains(x.PhieuNhapId) && !x.IsDeleted).Select(x=> x.Id).ToListAsync();
                if (phieuChiIds != null)
                    await _phieuChiService.DeleteListAsync(phieuChiIds);
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _phieuNhapCtRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _hoaDonGtgtRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _phanBoChietKhauThuongMaiRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _phanBoChiPhiRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _phanBoThueNkRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _hoaDonMuaHangRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapId));
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<List<PhieuNhapDto>> FilterAsync(FilterRequest request)
        {
            var data = await _repository.GetListAsync();

            if (request.FromDate != null && request.ToDate != null)
            {
                data = data.Where(x => x.NgayHt >= request.FromDate && x.NgayHt <= request.ToDate).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Value1))
            {
                var value1 = request.Value1.Replace(" ", "");
                data = data.Where(x => x.Sopn != null && x.Sopn.Contains(value1)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Value2))
            {
                var value2 = request.Value2.Replace(" ", "");
                data = data.Where(x => x.SoHd != null && x.SoHd.Contains(value2)).ToList();
            }

            if (request.Id3 != null)
            {
                data = data.Where(x => x.KhachHangId == request.Id3).ToList();
            }
            var phieuNhaps = ObjectMapper.Map<List<PhieuNhap>, List<PhieuNhapDto>>(data);
            foreach (var item in phieuNhaps)
            {
                if (item.NgoaiTeId != 0 && item.NgoaiTeId != null)
                {
                    var nt = await _ngoaiTeRepository.FirstOrDefaultAsync(x => x.Id == item.NgoaiTeId);
                    item.NgoaiTeUd = nt?.NgoaiTeUd ?? SystemConstants.NA;
                }
                else
                    item.NgoaiTeUd = SystemConstants.NA;

                if (item.KhachHangId != 0 && item.KhachHangId != null)
                {
                    var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id == item.KhachHangId);
                    item.KhachHangNm = kh?.KhachHangNm ?? SystemConstants.NA;
                    item.KhachHangUd = kh?.KhachHangUd ?? SystemConstants.NA;
                }
                else
                {
                    item.KhachHangUd = SystemConstants.NA;
                    item.KhachHangNm = SystemConstants.NA;
                }

                if (item.GhiCoTk != 0 && item.GhiCoTk != null)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiCoTk);
                    item.GhiCoTkUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                }
                else
                    item.GhiCoTkUd = SystemConstants.NA;
                if (item.TkThueVat != 0 && item.TkThueVat != null)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.TkThueVat);
                    item.TkThueVatUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                }
                else
                    item.GhiCoTkUd = SystemConstants.NA;

            }
            return phieuNhaps;
        }

        public async Task<PhieuNhapDto> GetByIdAsync(int? id)
        {
            try
            {
                var phieuNhap = await _repository.GetAsync(id);
                var phieuNhapCts = await _phieuNhapCtRepository.GetListAsync(x => x.PhieuNhapId == id);
                var phieuNhapCtDtos = ObjectMapper.Map<List<PhieuNhapCT>, List<PhieuNhapCtDto>>(phieuNhapCts);
                if (phieuNhapCtDtos != null && phieuNhapCtDtos.Count > 0)
                {
                    foreach (var item in phieuNhapCtDtos)
                    {
                        if (item.VatTuId.HasValue && item.VatTuId != 0)
                        {
                            var vt = await _vatTuRepository.FirstOrDefaultAsync(x=>x.Id == item.VatTuId);
                            item.VatTuUd = vt?.VatTuUd;
                            item.VatTuNm = vt?.VatTuNm;
                            item.DonViTinh = vt?.DonViTinh;
                        }                
                        if (item.KhoId.HasValue && item.KhoId != 0)
                        {
                            var kho = await _khoRepository.FirstOrDefaultAsync(x => x.Id == item.KhoId);
                            item.KhoUd = kho?.KhoUd;
                        }
                        if (item.GhiNoTK.HasValue && item.GhiNoTK != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiNoTK);
                            item.GhiNoTKUd = tk?.TaiKhoanUd;
                        }
                        if (item.VuViecId.HasValue && item.VuViecId != 0)
                        {
                            var vuViec = await _vuViecRepository.FirstOrDefaultAsync(x => x.Id == item.VuViecId);
                            item.VuViecUd = vuViec?.VuViecUd;
                        }
                        if (item.MaPhiId.HasValue && item.MaPhiId != 0)
                        {
                            var maPhi = await _dmMaPhiRepository.FirstOrDefaultAsync(x => x.Id == item.MaPhiId);
                            item.MaPhiUd = maPhi?.DmMaPhiUd;
                        }
                        if (item.MaTD01.HasValue && item.MaTD01 != 0)
                        {
                            var truongTuDo = await _dmTruongTuDoRepository.FirstOrDefaultAsync(x => x.Id == item.MaTD01);
                            item.MaTD01Ud = truongTuDo?.DmTruongTuDoUd;
                        }
                    }
                }
                var hoaDonGtgts = await _hoaDonGtgtRepository.GetListAsync(x => x.PhieuNhapId == id);
                var hoaDonGtgtDtos = ObjectMapper.Map<List<HoaDonGtgt>, List<HoaDonGtgtDto>>(hoaDonGtgts);
                if(hoaDonGtgtDtos != null && hoaDonGtgtDtos.Count > 0)
                {
                    foreach (var item in hoaDonGtgtDtos)
                    {
                        if (item.LoaiThue.HasValue && item.LoaiThue != 0)
                        {
                            var loaiThue = await _dmChungRepository.FirstOrDefaultAsync(x => x.Id ==item.LoaiThue);
                            item.LoaiThueUd = loaiThue?.DMChungUd;
                        }
                        if (item.KhachHangId.HasValue && item.KhachHangId != 0)
                        {
                            var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id ==item.KhachHangId);
                            item.KhachHangUd = kh?.KhachHangUd;
                            item.KhachHangNm = kh?.KhachHangNm;
                            item.DiaChi = kh?.DiaChi;
                            item.MaSoThue = kh?.MaSoThue;
                        }
                        if (item.TkThue.HasValue && item.TkThue != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id ==item.TkThue);
                            item.TkThueUd = tk?.TaiKhoanUd;
                        }
                        if(item.VuViecId.HasValue && item.VuViecId != 0)
                        {
                            var vuViec = await _vuViecRepository.FirstOrDefaultAsync(x => x.Id ==item.VuViecId);
                            item.VuViecUd = vuViec?.VuViecUd;
                        }
                        if (item.MaPhiId.HasValue && item.MaPhiId != 0)
                        {
                            var maPhi = await _dmMaPhiRepository.FirstOrDefaultAsync(x => x.Id ==item.MaPhiId);
                            item.MaPhiUd = maPhi?.DmMaPhiUd;
                        }               
                        if (item.MaTD01.HasValue && item.MaTD01 != 0)
                        {
                            var truongTuDo = await _dmTruongTuDoRepository.FirstOrDefaultAsync(x => x.Id ==item.MaTD01);
                            item.MaTD01Ud = truongTuDo?.DmTruongTuDoUd;
                        }
                    }
                }
                var phanBoChietKhauThuongMais = await _phanBoChietKhauThuongMaiRepository.GetListAsync(x => x.PhieuNhapId == id);
                var phanBoChietKhauThuongMaiDtos = ObjectMapper.Map<List<PhanBoChietKhauThuongMai>, List<PhanBoChietKhauThuongMaiDto>>(phanBoChietKhauThuongMais);
                if (phanBoChietKhauThuongMaiDtos != null && phanBoChietKhauThuongMaiDtos.Count > 0)
                {
                    foreach (var item in phanBoChietKhauThuongMaiDtos)
                    {
                        if (item.VatTuId.HasValue && item.VatTuId != 0)
                        {
                            var vt = await _vatTuRepository.FirstOrDefaultAsync(x => x.Id ==item.VatTuId);
                            item.VatTuUd = vt?.VatTuUd;
                            item.VatTuNm = vt?.VatTuNm;
                            item.DonViTinh = vt?.DonViTinh;
                        }
                    }
                }
                var phanBoChiPhis = await _phanBoChiPhiRepository.GetListAsync(x => x.PhieuNhapId == id);
                var phanBoChiPhiDtos = ObjectMapper.Map<List<PhanBoChiPhi>, List<PhanBoChiPhiDto>>(phanBoChiPhis);
                if (phanBoChiPhiDtos != null && phanBoChiPhiDtos.Count > 0)
                {
                    foreach (var item in phanBoChiPhiDtos)
                    {
                        if (item.VatTuId.HasValue && item.VatTuId != 0)
                        {
                            var vt = await _vatTuRepository.FirstOrDefaultAsync(x => x.Id ==item.VatTuId);
                            item.VatTuUd = vt?.VatTuUd;
                            item.VatTuNm = vt?.VatTuNm;
                            item.DonViTinh = vt?.DonViTinh;
                        }
                        if (item.KhoId.HasValue && item.KhoId != 0)
                        {
                            var kho = await _khoRepository.FirstOrDefaultAsync(x => x.Id ==item.KhoId);
                            item.KhoUd = kho?.KhoUd;
                        }
                    }
                }
                var phanBoThueNks = await _phanBoThueNkRepository.GetListAsync(x => x.PhieuNhapId == id);
                var phanBoThueNkDtos = ObjectMapper.Map<List<PhanBoThueNk>, List<PhanBoThueNkDto>>(phanBoThueNks);
                if (phanBoThueNkDtos != null && phanBoThueNkDtos.Count > 0)
                {
                    foreach (var item in phanBoThueNkDtos)
                    {
                        if (item.VatTuId.HasValue && item.VatTuId != 0)
                        {
                            var vt = await _vatTuRepository.FirstOrDefaultAsync(x => x.Id ==item.VatTuId);
                            item.VatTuUd = vt?.VatTuUd;
                            item.VatTuNm = vt?.VatTuNm;
                        }
                        if (item.TkNo.HasValue && item.TkNo != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id ==item.TkNo);
                            item.TkNoUd = tk?.TaiKhoanUd;
                        }
                    }
                }

                var hoaDonMuaHangs = await _hoaDonMuaHangRepository.GetListAsync(x => x.PhieuNhapId == id);
                var hoaDonMuaHangDtos = ObjectMapper.Map<List<HoaDonMuaHang>, List<HoaDonMuaHangDto>>(hoaDonMuaHangs);
                if (hoaDonMuaHangDtos != null && hoaDonMuaHangDtos.Count > 0)
                {
                    foreach (var item in hoaDonMuaHangDtos)
                    {
                        if (item.GhiNoTK.HasValue && item.GhiNoTK != 0)
                        {
                            var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiNoTK);
                            item.GhiNoTKUd = tk?.TaiKhoanUd;
                            item.GhiNoTKNm = tk?.TaiKhoanNm;
                        }
                        if (item.VuViecId.HasValue && item.VuViecId != 0)
                        {
                            var vuViec = await _vuViecRepository.FirstOrDefaultAsync(x => x.Id == item.VuViecId);
                            item.VuViecUd = vuViec?.VuViecUd;
                        }
                        if (item.MaPhiId.HasValue && item.MaPhiId != 0)
                        {
                            var maPhi = await _dmMaPhiRepository.FirstOrDefaultAsync(x => x.Id == item.MaPhiId);
                            item.MaPhiUd = maPhi?.DmMaPhiUd;
                        }
                        if (item.MaTD01.HasValue && item.MaTD01 != 0)
                        {
                            var truongTuDo = await _dmTruongTuDoRepository.FirstOrDefaultAsync(x => x.Id == item.MaTD01);
                            item.MaTD01Ud = truongTuDo?.DmTruongTuDoUd;
                        }
                    }
                }

                var phieuNhapDto = ObjectMapper.Map<PhieuNhap, PhieuNhapDto>(phieuNhap);
                if (phieuNhapDto.ChiNhanhId.HasValue && phieuNhapDto.ChiNhanhId != 0)
                {
                    var cn = await _chiNhanhRepository.FirstOrDefaultAsync(x => x.Id == phieuNhapDto.ChiNhanhId);
                    phieuNhapDto.ChiNhanhNm = cn?.ChiNhanhNm;
                }
                if (phieuNhapDto.KhachHangId.HasValue && phieuNhapDto.KhachHangId != 0)
                {
                    var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id ==phieuNhapDto.KhachHangId);
                    phieuNhapDto.KhachHangNm = kh?.KhachHangNm;
                    phieuNhapDto.SoDu = kh?.Sodu;
                }
                if (phieuNhapDto.GhiCoTk.HasValue && phieuNhapDto.GhiCoTk != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id ==phieuNhapDto.GhiCoTk);
                    phieuNhapDto.GhiCoTkNm = tk?.TaiKhoanNm;
                    phieuNhapDto.GhiCoTkUd = tk?.TaiKhoanUd;
                }
                if (phieuNhapDto.TkThueVat.HasValue && phieuNhapDto.TkThueVat != 0)
                {
                    var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id ==phieuNhapDto.TkThueVat);
                    phieuNhapDto.TkThueVatUd = tk?.TaiKhoanUd;
                }
                phieuNhapDto.PhieuNhapCtDtos = phieuNhapCtDtos;
                phieuNhapDto.HoaDonGtgtDtos = hoaDonGtgtDtos;
                phieuNhapDto.PhanBoChietKhauThuongMaiDtos = phanBoChietKhauThuongMaiDtos;
                phieuNhapDto.PhanBoChiPhiDtos = phanBoChiPhiDtos;
                phieuNhapDto.PhanBoThueNkDtos = phanBoThueNkDtos;
                phieuNhapDto.HoaDonMuaHangDtos = hoaDonMuaHangDtos;
                return phieuNhapDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuNhapDto();
            }
        }

        public async Task<List<PhieuNhapDto>> GetListAsync(string? loaiPhieu, DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var phieuNhaps = ObjectMapper.Map<List<PhieuNhap>, List<PhieuNhapDto>>(await _repository.GetListAsync(x=> x.LoaiPhieu == loaiPhieu && x.NgayHt >= tuNgay && x.NgayHt <= denNgay));
                foreach (var item in phieuNhaps)
                {
                    if (item.NgoaiTeId != 0 && item.NgoaiTeId != null)
                    {
                        var nt = await _ngoaiTeRepository.FirstOrDefaultAsync(x => x.Id == item.NgoaiTeId);
                        item.NgoaiTeUd = nt?.NgoaiTeUd ?? SystemConstants.NA;
                    }
                    else
                        item.NgoaiTeUd = SystemConstants.NA;

                    if (item.KhachHangId != 0 && item.KhachHangId != null)
                    {
                        var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id == item.KhachHangId);
                        item.KhachHangNm = kh?.KhachHangNm ?? SystemConstants.NA; 
                        item.KhachHangUd = kh?.KhachHangUd ?? SystemConstants.NA;
                    }
                    else
                    {
                        item.KhachHangUd = SystemConstants.NA;
                        item.KhachHangNm = SystemConstants.NA;
                    }

                    if (item.GhiCoTk != 0 && item.GhiCoTk != null)
                    {
                        var tk = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiCoTk);
                        item.GhiCoTkUd = tk?.TaiKhoanUd ?? SystemConstants.NA;
                    }
                    else
                        item.GhiCoTkUd = SystemConstants.NA;

                }
                return phieuNhaps;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuNhapDto>();
            }
        }

        public async Task<List<PhieuNhapDto>> GetListByKhachHangIdAsync(int? khachHangId)
        {
            return ObjectMapper.Map<List<PhieuNhap>, List<PhieuNhapDto>>( await _repository.GetListAsync(x => x.KhachHangId == khachHangId));
        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuNhapDto> phieuNhapDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuNhapDtos != null)
            {
                foreach (var item in phieuNhapDtos)
                {
                    if (item.TongTien == null)
                        item.TongTien = 0;
                    sumPhatSinh += item.TongTien;
                    if (item.TongTienVND == null)
                        item.TongTienVND = 0;
                    sumPhatSinhVND += item.TongTienVND;
                }
            }
            var result = new TongTienDto()
            {
                SoLuongChungTu = phieuNhapDtos != null ? phieuNhapDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuNhapRequest request)
        {
            try
            {
                var phieuchi = await _context.PhieuChis.FirstOrDefaultAsync(x => x.PhieuNhapId == id && !x.IsDeleted);
                if (phieuchi != null)
                    await _phieuChiService.DeleteAsync(phieuchi.Id);
                await _soCaiRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phieuNhapCtRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _hoaDonGtgtRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phanBoChietKhauThuongMaiRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phanBoChiPhiRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _phanBoThueNkRepository.DeleteAsync(x => x.PhieuNhapId == id);
                await _hoaDonMuaHangRepository.DeleteAsync(x => x.PhieuNhapId == id);
                var phieuNhaps = new List<PhieuNhapCT>();
                if (request.PhieuNhapCtRequests != null)
                {
                    phieuNhaps = ObjectMapper.Map<List<PhieuNhapCtRequest>, List<PhieuNhapCT>>(request.PhieuNhapCtRequests);
                }
                var hoaDonGTGTs = new List<HoaDonGtgt>();
                if (request.HoaDonRequests != null)
                {
                    hoaDonGTGTs = ObjectMapper.Map<List<HoaDonRequest>, List<HoaDonGtgt>>(request.HoaDonRequests);
                }
                var phanBoChietKhauThuongMais = new List<PhanBoChietKhauThuongMai>();
                if (request.PhanBoChietKhauThuongMaiRequests != null)
                {
                    phanBoChietKhauThuongMais = ObjectMapper.Map<List<PhanBoChietKhauThuongMaiRequest>, List<PhanBoChietKhauThuongMai>>(request.PhanBoChietKhauThuongMaiRequests);
                }
                var phanBoChiPhis = new List<PhanBoChiPhi>();
                if (request.PhanBoChiPhiRequests != null)
                {
                    phanBoChiPhis = ObjectMapper.Map<List<PhanBoChiPhiRequest>, List<PhanBoChiPhi>>(request.PhanBoChiPhiRequests);
                }
                var phanBoThueNks = new List<PhanBoThueNk>();
                if (request.PhanBoThueNkRequests != null)
                {
                    phanBoThueNks = ObjectMapper.Map<List<PhanBoThueNkRequest>, List<PhanBoThueNk>>(request.PhanBoThueNkRequests);
                }
                var hoaDonMuaHangs = new List<HoaDonMuaHang>();
                if (request.HoaDonMuaHangRequests != null)
                {
                    hoaDonMuaHangs = ObjectMapper.Map<List<HoaDonMuaHangRequest>, List<HoaDonMuaHang>>(request.HoaDonMuaHangRequests);
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }
                var phieuNhap = ObjectMapper.Map(request, await _repository.GetAsync(id));
                phieuNhap.PhieuNhapCTs = phieuNhaps;
                phieuNhap.SoCais = soCais;
                phieuNhap.HoaDonGtgts = hoaDonGTGTs;
                phieuNhap.PhanBoChietKhauThuongMais = phanBoChietKhauThuongMais;
                phieuNhap.PhanBoChiPhis = phanBoChiPhis;
                phieuNhap.PhanBoThueNks = phanBoThueNks;
                phieuNhap.HoaDonMuaHangs = hoaDonMuaHangs;
                await _repository.UpdateAsync(phieuNhap);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống, vui lòng liên hệ bộ phân kỹ thuật để được hỗ trợ." };
            }
        }
    }
}
