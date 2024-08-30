using AutoMapper;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyCongNo;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyTk;
using tamkhoatech.ACWeb.Entities;

namespace tamkhoatech.ACWeb;

public class ACWebApplicationAutoMapperProfile : Profile
{
    public ACWebApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<ThamSoHeThong, ThamSoHeThongDto>();
        CreateMap<ThamSoHeThongDto, ThamSoHeThongRequest>();

        CreateMap<PhieuThu, PhieuThuDto>();
        CreateMap<PhieuThuDto, PhieuThuRequest>();
        CreateMap<PhieuThuRequest, PhieuThu>();
        CreateMap<PhieuThuCT, PhieuThuCTDto>();
        CreateMap<PhieuThuCTRequest, PhieuThuCT>();
        CreateMap<PhieuThuCT, PhieuThuCTRequest>();
        CreateMap<PhieuThuCTDto, PhieuThuCTRequest>();
        CreateMap<PhieuThuCTRequest, PhieuThuCt01Request>();
        CreateMap<PhieuThuCTRequest, PhieuThuCt02Request>();
        CreateMap<PhieuThuCTRequest, PhieuThuCt03Request>();
        CreateMap<PhieuThuCTRequest, PhieuThuCt04Request>();
        CreateMap<PhieuThuCt01Request, PhieuThuCTRequest>();
        CreateMap<PhieuThuCt02Request, PhieuThuCTRequest>();
        CreateMap<PhieuThuCt03Request, PhieuThuCTRequest>();
        CreateMap<PhieuThuCt04Request, PhieuThuCTRequest>();

        CreateMap<ChiNhanh, ChiNhanhDto>();
        CreateMap<ChiNhanhRequest, ChiNhanh>();
        CreateMap<ChiNhanhDto, ChiNhanhRequest>();

        CreateMap<MaGiaoDich, MaGiaoDichDto>();

        CreateMap<KhachHang, KhachHangDto>();
        CreateMap<KhachHangRequest, KhachHang>();
        CreateMap<KhachHangDto, KhachHangRequest>();
        CreateMap<NhomKhachHang, NhomKhachHangDto>();

        CreateMap<NgoaiTe, NgoaiTeDto>();
        CreateMap<TyGiaNgoaiTe, TyGiaNgoaiTeDto>();
        CreateMap<TaiKhoan, TaiKhoanDto>();
        CreateMap<QuyenSo, QuyenSoDto>();

        CreateMap<PhieuChi, PhieuChiDto>();
        CreateMap<PhieuChiRequest, PhieuChi>();
        CreateMap<PhieuChiCT, PhieuChiCTDto>();
        CreateMap<PhieuChiDto, PhieuChiRequest>();
        CreateMap<PhieuChiCTDto, PhieuChiCTRequest>();
        CreateMap<PhieuChiCTRequest, PhieuChiCT>();
        CreateMap<PhieuChiCTRequest, PhieuChiCt01Request>();
        CreateMap<PhieuChiCTRequest, PhieuChiCt02Request>();
        CreateMap<PhieuChiCTRequest, PhieuChiCt03Request>();
        CreateMap<PhieuChiCTRequest, PhieuChiCt04Request>();
        CreateMap<PhieuChiCt01Request, PhieuChiCTRequest>();
        CreateMap<PhieuChiCt02Request, PhieuChiCTRequest>();
        CreateMap<PhieuChiCt03Request, PhieuChiCTRequest>();
        CreateMap<PhieuChiCt04Request, PhieuChiCTRequest>();

        CreateMap<HoaDonGtgt, HoaDonGtgtDto>();
        CreateMap<HoaDonGtgtDto, HoaDonRequest>();
        CreateMap<HoaDonRequest, HoaDonGtgt>();

        CreateMap<DMChung, DmChungDto>();
        CreateMap<BoPhanHT, BoPhanHTDto>();

        CreateMap<VatTu, VatTuDto>();
        CreateMap<VatTuRequest, VatTu>();
        CreateMap<VatTuDto, VatTuRequest>();

        CreateMap<VuViec, VuViecDto>();
        CreateMap<DmMaPhi, DmMaPhiDto>();
        CreateMap<DieuChinhThueTNDN, DieuChinhThueTNDnDto>();
        CreateMap<DmTruongTuDo, DmTruongTuDoDto>();

        CreateMap<SoCai, SoCaiDto>();
        CreateMap<SoCaiDto, SoCaiRequest>();
        CreateMap<SoCaiRequest, SoCai>();

        CreateMap<PhieuNhapRequest, PhieuNhap>();
        CreateMap<PhieuNhap, PhieuNhapDto>();
        CreateMap<PhieuNhapDto, PhieuNhapRequest>();
        CreateMap<PhieuNhapCT, PhieuNhapCtDto>();
        CreateMap<PhieuNhapCtDto, PhieuNhapCtRequest>();
        CreateMap<PhieuNhapCtRequest, PhieuNhapCT>();

        CreateMap<PhieuXuat, PhieuXuatDto>();
        CreateMap<PhieuXuatRequest, PhieuXuat>();
        CreateMap<PhieuXuatDto, PhieuXuatRequest>();
        CreateMap<PhieuXuatCtRequest, PhieuXuatCt>();
        CreateMap<PhieuXuatCtDto, PhieuXuatCtRequest>();
        CreateMap<HoaDonMuaHang, HoaDonMuaHangDto>();
        CreateMap<HoaDonMuaHangDto, HoaDonMuaHangRequest>();
        CreateMap<HoaDonMuaHangRequest, HoaDonMuaHang>();
        CreateMap<HoaDonBanHang, HoaDonBanHangDto>();
        CreateMap<HoaDonBanHangRequest, HoaDonBanHang>();
        CreateMap<HoaDonBanHangDto, HoaDonBanHangRequest>();
        CreateMap<ThueSuat, ThueSuatDto>();

        CreateMap<PhanBoChietKhauThuongMaiRequest, PhanBoChietKhauThuongMai>();
        CreateMap<PhanBoChietKhauThuongMai, PhanBoChietKhauThuongMaiDto>();
        CreateMap<PhanBoChietKhauThuongMaiDto, PhanBoChietKhauThuongMaiRequest>();

        CreateMap<PhanBoChiPhi, PhanBoChiPhiDto>();
        CreateMap<PhanBoChiPhiRequest, PhanBoChiPhi>();
        CreateMap<PhanBoChiPhiDto, PhanBoChiPhiRequest>();

        CreateMap<PhanBoThueNkRequest, PhanBoThueNk>();
        CreateMap<PhanBoThueNk, PhanBoThueNkDto>();
        CreateMap<PhanBoThueNkDto, PhanBoThueNkRequest>();

        CreateMap<SYNavigationNode, NavigationNodeDto>();
        CreateMap<Kho, KhoDto>();
        CreateMap<KhoDto, KhoRequest>();
        CreateMap<KhoRequest, Kho>();

        CreateMap<PhieuKeToan, PhieuKeToanDto>();
        CreateMap<PhieuKeToanRequest, PhieuKeToan>();
        CreateMap<PhieuKeToanCtRequest, PhieuKeToanCt>();
        CreateMap<PhieuKeToanCt, PhieuKeToanCtDto>();
        CreateMap<PhieuKeToanDto, PhieuKeToanRequest>();
        CreateMap<PhieuKeToanCtDto, PhieuKeToanCtRequest>();

        CreateMap<CongTrinhDto, CongTrinh>();
        CreateMap<CongTrinh, CongTrinhDto>();

        CreateMap<PhieuXuatKho, PhieuXuatKhoDto>();
        CreateMap<PhieuXuatKhoDto, PhieuXuatKhoRequest>();
        CreateMap<PhieuXuatKhoRequest, PhieuXuatKho>();
        CreateMap<PhieuXuatKhoCtRequest, PhieuXuatKhoCt>();
        CreateMap<PhieuXuatKhoCt, PhieuXuatKhoCtDto>();
        CreateMap<PhieuXuatKhoCtDto, PhieuXuatKhoCtRequest>();

        CreateMap<PhieuXuatDcKhoCtRequest, PhieuXuatDcKhoCt>();
        CreateMap<PhieuXuatDcKhoRequest, PhieuXuatDcKho>();
        CreateMap<PhieuXuatDcKho, PhieuXuatDcKhoDto>();
        CreateMap<PhieuXuatDcKhoCt, PhieuXuatDcKhoCtDto>();
        CreateMap<PhieuXuatDcKhoDto, PhieuXuatDcKhoRequest>();
        CreateMap<PhieuXuatDcKhoCtDto, PhieuXuatDcKhoCtRequest>();

        CreateMap<NhomVatTu, NhomVatTuDto>();

        CreateMap<PhieuNhapKho, PhieuNhapKhoDto>();
        CreateMap<PhieuNhapKhoDto, PhieuNhapKhoRequest>();
        CreateMap<PhieuNhapKhoCtDto, PhieuNhapKhoCtRequest>();
        CreateMap<PhieuNhapKhoCtRequest, PhieuNhapKhoCt>();
        CreateMap<PhieuNhapKhoRequest, PhieuNhapKho>();
        CreateMap<PhieuNhapKhoCt, PhieuNhapKhoCtDto>();

        CreateMap<BoPhan, BoPhanDto>();
        CreateMap<ManHinhNhap, ManHinhNhapDto>();
        CreateMap<ManHinhNhapDto, ManHinhNhapRequest>();
        CreateMap<ManHinhNhapRequest, ManHinhNhap>();
        CreateMap<ManHinhNhapCt, ManHinhNhapCtDto>();
        CreateMap<ManHinhNhapCtDto, ManHinhNhapCt>();

        CreateMap<DuDauKyTkDto, DuDauKyTkRequest>();
        CreateMap<DuDauKyTkRequest, DuDauKyTk>();

        CreateMap<DuDauKyCongNoRequest, DuDauKyCongNo>();
        CreateMap<DuDauKyCongNoDto, DuDauKyCongNoRequest>();
    }
}
