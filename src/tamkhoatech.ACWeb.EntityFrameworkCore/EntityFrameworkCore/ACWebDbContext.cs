using Microsoft.EntityFrameworkCore;
using tamkhoatech.ACWeb.Entities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace tamkhoatech.ACWeb.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ACWebDbContext :
    AbpDbContext<ACWebDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<PhieuThu> PhieuThus { get; set; }
    public DbSet<PhieuThuCT> PhieuThuCTs { get; set; }
    public DbSet<ChiNhanh> ChiNhanhs { get; set; }
    public DbSet<MaGiaoDich> MaGiaoDichs { get; set; }
    public DbSet<NhomKhachHang> NhomKhachHangs { get; set; }
    public DbSet<KhachHang> KhachHangs { get; set; }
    public DbSet<NgoaiTe> NgoaiTes { get; set; }
    public DbSet<TyGiaNgoaiTe> TyGiaNgoaiTes { get; set; }
    public DbSet<TaiKhoan> TaiKhoans { get; set; }
    public DbSet<QuyenSo> QuyenSos { get; set; }
    public DbSet<PhieuChi> PhieuChis { get; set; }
    public DbSet<PhieuChiCT> PhieuChiCTs { get; set; }
    public DbSet<HoaDonGtgt> HoaDonGTGTs { get; set; }
    public DbSet<DMChung> DMChungs { get; set; }
    public DbSet<BoPhanHT> BoPhanHTs { get; set; }
    public DbSet<VatTu> VatTus { get; set; }
    public DbSet<VuViec> VuViecs { get; set; }
    public DbSet<DmMaPhi> DmMaPhis { get; set; }
    public DbSet<DieuChinhThueTNDN> DieuChinhThueTNDNs { get; set; }
    public DbSet<DmTruongTuDo> DmTruongTuDos { get; set; }
    public DbSet<SoCai> SoCais { get; set; }
    public DbSet<PhieuNhap> PhieuNhaps { get; set; }
    public DbSet<PhieuNhapCT> PhieuNhapCTs { get; set; }
    public DbSet<PhieuXuat> PhieuXuats { get; set; }
    public DbSet<PhieuXuatCt> PhieuXuatCts { get; set; }
    public DbSet<TheKho> TheKhos { get; set; }
    public DbSet<DuDauKyCongNo> DuDauKyCongNos { get; set; }
    public DbSet<SYNavigationNode> SYNavigationNodes { get; set; }
    public DbSet<PhieuNhapKho> PhieuNhapKhos { get; set; }
    public DbSet<PhieuNhapKhoCt> PhieuNhapKhoCts { get; set; }
    public DbSet<Kho> Khos { get; set; }
    public DbSet<PhieuKeToan> PhieuKeToans { get; set; }
    public DbSet<PhieuKeToanCt> PhieuKeToanCts { get; set; }
    public DbSet<CongTrinh> CongTrinhs { get; set; }
    public DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }
    public DbSet<PhieuXuatKhoCt> PhieuXuatKhoCts { get; set; }
    public DbSet<ManHinhNhap> ManHinhNhaps { get; set; }
    public DbSet<ManHinhNhapCt> ManHinhNhapCts { get; set; }
    public DbSet<PhieuXuatDcKho> PhieuXuatDcKhos { get; set; }
    public DbSet<PhieuXuatDcKhoCt> PhieuXuatDcKhoCts { get; set; }
    public DbSet<SoPhuSupport> SoPhuSupports { get; set; }
    public DbSet<PhanBoChietKhauThuongMai> PhanBoChietKhauThuongMais { get; set; }
    public DbSet<PhanBoChiPhi> PhanBoChiPhis { get; set; }
    public DbSet<PhanBoThueNk> PhanBoThueNks { get; set; }
    public DbSet<NhomVatTu> NhomVatTus { get; set; }
    public DbSet<HoaDonMuaHang> HoaDonMuaHangs { get; set; }
    public DbSet<TonKho> TonKhos { get; set; }
    public DbSet<ThamSoHeThong> ThamSoHeThongs { get; set; }
    public DbSet<HoaDonBanHang> HoaDonBanHangs { get; set; }
    public DbSet<ThueSuat> ThueSuats { get; set; }
    public DbSet<BoPhan> BoPhans { get; set; }
    public DbSet<DuDauKyTk> DuDauKyTks { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, Bpif you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion


    public ACWebDbContext(DbContextOptions<ACWebDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /* Include modules to your migration db context */

        modelBuilder.ConfigurePermissionManagement();
        modelBuilder.ConfigureSettingManagement();
        modelBuilder.ConfigureBackgroundJobs();
        modelBuilder.ConfigureAuditLogging();
        modelBuilder.ConfigureIdentity();
        modelBuilder.ConfigureOpenIddict();
        modelBuilder.ConfigureFeatureManagement();
        modelBuilder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        modelBuilder.Entity<PhieuThu>(b =>
        {
            b.ToTable("PhieuThu", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.BankAccountNumber).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.GiaoDichId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.NguoiNop).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiNoTkId).IsRequired(false);
            b.Property(x => x.NgayHT).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.SoPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSoId).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChungTu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.RefId).IsRequired(false);
            b.Property(x => x.DiaChi).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.MaSoThue).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsTaoTuDong).IsRequired(false);
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.PhieuXuatUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
        });
        modelBuilder.Entity<PhieuThuCT>(b =>
        {

            b.ToTable("PhieuThuCT", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuThuId).IsRequired(false);
            b.Property(x => x.HoaDonDichVuId).IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHd).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiCoTk).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.TienTrenHd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DaTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThanhToan).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThanhToanVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThanhToanQd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyGiaGS).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TienHt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoHd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuThu).WithMany(x => x.PhieuThuCTs).HasForeignKey(x => x.PhieuThuId);
        });
        modelBuilder.Entity<ChiNhanh>(b =>
        {

            b.ToTable("ChiNhanh", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.ChiNhanhUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChiNhanhNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<MaGiaoDich>(b =>
        {

            b.ToTable("MaGiaoDich", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.MaGiaoDichUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.MaGiaoDichNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaGiaoDichNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ManHinhNhapId).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TkNo).IsRequired(false);
            b.Property(x => x.TkCo).IsRequired(false);
        });
        modelBuilder.Entity<NhomKhachHang>(b =>
        {
            b.ToTable("NhomKhachHang", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.NhomKhachHangUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NhomKhachHangNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NhomKhachHangNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.KieuPhanNhom).IsRequired(false);
        });
        modelBuilder.Entity<KhachHang>(b =>
        {
            b.ToTable("KhachHang", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.KhachHangUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KhachHangNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.KhachHangNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.Loai).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.DiaChi).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DoiTac).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaSoThue).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.TkNgamDinh).IsRequired(false);
            b.Property(x => x.TkKho).IsRequired(false);
            b.Property(x => x.TkChietKhau).IsRequired(false);
            b.Property(x => x.HanTtNgamDinh).IsRequired(false);
            b.Property(x => x.IsConGiaoDich).IsRequired(false);
            b.Property(x => x.Sodu).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DienThoai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.Fax).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.Email).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TkNganHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TenNganHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TinhThanh).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd1).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd1).IsRequired(false);
            b.Property(x => x.NhomKhachHang1).IsRequired(false);
            b.Property(x => x.NhomKhachHang2).IsRequired(false);
            b.Property(x => x.NhomKhachHang3).IsRequired(false);
            b.Property(x => x.SoLuongTd1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd1).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd2).IsRequired(false);
            b.Property(x => x.SoLuongTd2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd3).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd3).IsRequired(false);
            b.Property(x => x.SoLuongTd3).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd3).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DiaDiemGiao).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<NgoaiTe>(b =>
        {
            b.ToTable("NgoaiTe", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.NgoaiTeUd).HasMaxLength(5).IsRequired(false);
            b.Property(x => x.NgoaiTeNm).HasMaxLength(128).IsRequired(false);
            b.Property(x => x.NgoaiTeNm2).HasMaxLength(128).IsRequired(false);
            b.Property(x => x.Comma).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DvtienLe).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.Dvtien).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.Chan).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.Comma2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DvtienLe2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.Dvtien2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.Chan2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.So).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChuAnh).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChuViet).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DocSoLe).IsRequired(false);

        });
        modelBuilder.Entity<TyGiaNgoaiTe>(b =>
        {
            b.ToTable("TyGiaNgoaiTe", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.Ngay).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.HasOne(x => x.NgoaiTe).WithMany(x => x.TyGiaNgoaiTes).HasForeignKey(x => x.NgoaiTeId);
        });
        modelBuilder.Entity<TaiKhoan>(b =>
        {
            b.ToTable("TaiKhoan", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.TaiKhoanUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.TaiKhoanNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TaiKhoanNm1).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TaiKhoanNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TaiKhoanNm3).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TaiKhoanParentId).IsRequired(false);
            b.Property(x => x.IsTKCongNo).IsRequired(false);
            b.Property(x => x.IsTKSoCai).IsRequired(false);
            b.Property(x => x.BacTK).IsRequired(false);
            b.Property(x => x.IsBacCuoi).IsRequired(false);
            b.Property(x => x.NhomTieuKhoanId).IsRequired(false);
            b.Property(x => x.NhomTaiKhoanId).IsRequired(false);
            b.Property(x => x.TGGSNo).IsRequired(false);
            b.Property(x => x.TGGSCo).IsRequired(false);
            b.Property(x => x.IsDk).IsRequired(false);
            b.Property(x => x.IsVisible).IsRequired(false);
            b.Property(x => x.Loai).IsRequired(false);
            b.Property(x => x.TieuKhoanId).IsRequired(false);
            b.Property(x => x.IsTKVatTu).IsRequired(false);
        });
        modelBuilder.Entity<QuyenSo>(b =>
        {
            b.ToTable("QuyenSo", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.MaCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoQuyen).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoCtPrefix).HasMaxLength(10).IsRequired(false);
            b.Property(x => x.SoCtSuffix).HasMaxLength(10).IsRequired(false);
            b.Property(x => x.SoCtHienTai).IsRequired(false);
            b.Property(x => x.SoKyTu0).IsRequired(false);
            b.Property(x => x.IsUser).IsRequired(false);
        });

        modelBuilder.Entity<PhieuChi>(b =>
        {
            b.ToTable("PhieuChi", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.GiaoDichId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.NguoiNhan).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.BankAccountNumber).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiNoTkId).IsRequired(false);
            b.Property(x => x.NgayHT).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.SoPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSoId).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChungTu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyGiaGS).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.HoaDonGTGT).IsRequired(false);
            b.Property(x => x.TkThue).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienThue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienThueVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.RefId).IsRequired(false);
            b.Property(x => x.TenNganHang).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.SoTaiKhoan).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.TenTinhThanh).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.TenKhachHang).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.DiaChi).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.SoTaiKhoan2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.TenNganHang2).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.DiaChi2).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.NoiDung).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.CamKet).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.MucDich).IsRequired(false);
            b.Property(x => x.HinhThuc).IsRequired(false);
            b.Property(x => x.PhiTrong).IsRequired(false);
            b.Property(x => x.PhiNgoai).IsRequired(false);
            b.Property(x => x.DiaChiKH).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.MaSoThue).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsTaoTuDong).IsRequired(false);
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.PhieuNhapUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
        });
        modelBuilder.Entity<PhieuChiCT>(b =>
        {

            b.ToTable("PhieuChiCT", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuChiId).IsRequired(false);
            b.Property(x => x.HoaDonDichVuId).IsRequired(false);
            b.Property(x => x.HoaDonChiId).IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHd).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiNoTk).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.TienTrenHd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTrenHdVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DaTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DaTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.LoaiThue).IsRequired(false);
            b.Property(x => x.MaThue).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Thue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThanhToan).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThanhToanVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThanhToanQd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyGiaGS).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TienHt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoHd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.MauHDId).IsRequired(false);
            b.Property(x => x.MauHDUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KiHieuMauHD).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuChi).WithMany(x => x.PhieuChiCTs).HasForeignKey(x => x.PhieuChiId);
        });
        modelBuilder.Entity<HoaDonGtgt>(b =>
        {

            b.ToTable("HoaDonGTGT", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.PhieuChiId).IsRequired(false);
            b.Property(x => x.PhieuKeToanId).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.MauBC).IsRequired(false);
            b.Property(x => x.MaCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayCt).IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayCt0).IsRequired(false);
            b.Property(x => x.SoCt0).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri0).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.KhachHangUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KhachHangNm).HasColumnType("nvarchar(MAX)").HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DiaChi).HasColumnType("nvarchar(MAX)").HasMaxLength(50).IsRequired(false);
            b.Property(x => x.MaSoThue).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.VatTu).HasColumnType("nvarchar(MAX)").HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLuong).IsRequired(false);
            b.Property(x => x.Gia).IsRequired(false);
            b.Property(x => x.GiaVND).IsRequired(false);
            b.Property(x => x.Tien).IsRequired(false);
            b.Property(x => x.TienVND).IsRequired(false);
            b.Property(x => x.Thue).IsRequired(false);
            b.Property(x => x.ThueVND).IsRequired(false);
            b.Property(x => x.MaThue).IsRequired(false);
            b.Property(x => x.ThueSuat).IsRequired(false);
            b.Property(x => x.TkThue).IsRequired(false);
            b.Property(x => x.TkDu).IsRequired(false);
            b.Property(x => x.CucThue).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.GhiChu).HasColumnType("nvarchar(MAX)").HasMaxLength(50).IsRequired(false);
            b.Property(x => x.MaTuDo).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.IsPhieu).IsRequired(false);
            b.Property(x => x.MauHDId).IsRequired(false);
            b.Property(x => x.MauHDUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KyHieuMauHD).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuChi).WithMany(x => x.HoaDonGTGTs).HasForeignKey(x => x.PhieuChiId);
            b.HasOne(x => x.PhieuKeToan).WithMany(x => x.HoaDonGTGTs).HasForeignKey(x => x.PhieuKeToanId);
            b.HasOne(x => x.KhachHang).WithMany(x => x.HoaDonGTGTGTs).HasForeignKey(x => x.KhachHangId);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.HoaDonGtgts).HasForeignKey(x => x.PhieuNhapId);
            b.HasOne(x => x.PhieuXuat).WithMany(x => x.HoaDonGtgts).HasForeignKey(x => x.PhieuXuatId);
        });

        modelBuilder.Entity<DMChung>(b =>
        {

            b.ToTable("DMChung", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.DMChungUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.LoaiDM).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DMChungNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<BoPhanHT>(b =>
        {
            b.ToTable("BoPhanHT", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.BoPhanHtUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.BoPhanHtNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.BoPhanHtNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<VatTu>(b =>
        {
            b.ToTable("VatTu", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.VatTuUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.VatTuNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.VatTuNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DonViTinh).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoQD31).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoDangKy).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.HamLuong).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.CachDung).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.HangSX).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NuocSX).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NhaThau).IsRequired(false);
            b.Property(x => x.IsTheoDoiTonKho).IsRequired(false);
            b.Property(x => x.CachTinhGia).IsRequired(false);
            b.Property(x => x.LoaiVatTu).IsRequired(false);
            b.Property(x => x.TkKho).IsRequired(false);
            b.Property(x => x.IsSuaTkKho).IsRequired(false);
            b.Property(x => x.TkGiaVon).IsRequired(false);
            b.Property(x => x.TkCongNo).IsRequired(false);
            b.Property(x => x.TkDoanhThu).IsRequired(false);
            b.Property(x => x.TkHangBiTra).IsRequired(false);
            b.Property(x => x.TkSpDoDang).IsRequired(false);
            b.Property(x => x.TkChenhLechGiaVt).IsRequired(false);
            b.Property(x => x.NhomVT1).IsRequired(false);
            b.Property(x => x.NhomVT2).IsRequired(false);
            b.Property(x => x.NhomVT3).IsRequired(false);
            b.Property(x => x.SLTonToiThieu).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SLTonToiDa).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyLeDT).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsTinhLuong).IsRequired(false);
            b.Property(x => x.GhiChu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.MaTd1).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd1).IsRequired(false);
            b.Property(x => x.SoLuongTd1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd1).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd2).IsRequired(false);
            b.Property(x => x.SoLuongTd2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd3).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd3).IsRequired(false);
            b.Property(x => x.SoLuongTd3).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd3).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.IsKhongTinChiPhiNhanCong).IsRequired(false);
            b.Property(x => x.IsKhongTinhChiPhiChung).IsRequired(false);
        });
        modelBuilder.Entity<VuViec>(b =>
        {
            b.ToTable("VuViec", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.VuViecUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.VuViecNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.VuViecNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.BPKDId).IsRequired(false);
            b.Property(x => x.BPTHId).IsRequired(false);
            b.Property(x => x.NgayBd).IsRequired(false);
            b.Property(x => x.NgayKt).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.GiaTriHd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.NhomVuViec1).IsRequired(false);
            b.Property(x => x.NhomVuViec2).IsRequired(false);
            b.Property(x => x.NhomVuViec3).IsRequired(false);
            b.Property(x => x.GhiChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoHd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHd).IsRequired(false);
            b.Property(x => x.NoiDung).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ThoiGianKhoiCong).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NgayTLHD).IsRequired(false);
            b.Property(x => x.NgayBBBG).IsRequired(false);
            b.Property(x => x.MaTd1).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd1).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLuongTd1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd1).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd2).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLuongTd2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTd3).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayTd3).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLuongTd3).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTd3).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.LoaiChiPhi).IsRequired(false);
        });
        modelBuilder.Entity<DmMaPhi>(b =>
        {
            b.ToTable("DmMaPhi", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.DmMaPhiUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DmMaPhiNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DmMaPhiNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<DieuChinhThueTNDN>(b =>
        {
            b.ToTable("DieuChinhThueTNDN", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.DieuChinhThueTNDNUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<DmTruongTuDo>(b =>
        {
            b.ToTable("DmTruongTuDo", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.DmTruongTuDoUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DmTruongTuDoNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DmTruongTuDoNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.LoaiTruongTuDo).IsRequired(false);
        });
        modelBuilder.Entity<SoCai>(b =>
        {
            b.ToTable("SoCai", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.PhieuChiId).IsRequired(false);
            b.Property(x => x.PhieuNhapKhoId).IsRequired(false);
            b.Property(x => x.PhieuXuatKhoId).IsRequired(false);
            b.Property(x => x.PhieuXuatDcKhoId).IsRequired(false);
            b.Property(x => x.PhieuKeToanId).IsRequired(false);
            b.Property(x => x.KHTSCDId).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.DuDauKyTkId).IsRequired(false);
            b.Property(x => x.ButToanKcId).IsRequired(false);
            b.Property(x => x.ButToanPbId).IsRequired(false);
            b.Property(x => x.ButToanCLTGId).IsRequired(false);
            b.Property(x => x.MaNk).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.MaGd).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoDh).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NhomDinhKhoan).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.Tk).IsRequired(false);
            b.Property(x => x.TkDoiUng).IsRequired(false);
            b.Property(x => x.PhatSinhNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PhatSinhCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyGiaHt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyGiaHt2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PhatSinhNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PhatSinhCoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Nxt).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.MaTd).IsRequired(false);
            b.Property(x => x.MaKu).IsRequired(false);
            b.Property(x => x.SoHd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHd).IsRequired(false);
            b.Property(x => x.SoCTGS).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayCTGS).IsRequired(false);
            b.Property(x => x.SoQuyen).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.PhieuUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuChi).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuChiId);
            b.HasOne(x => x.PhieuThu).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuThuId);
            b.HasOne(x => x.PhieuKeToan).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuKeToanId);
            b.HasOne(x => x.PhieuXuatKho).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuXuatKhoId);
            b.HasOne(x => x.PhieuXuatDcKho).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuXuatDcKhoId);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuNhapId);
            b.HasOne(x => x.PhieuXuat).WithMany(x => x.SoCais).HasForeignKey(x => x.PhieuXuatId);
        });
        modelBuilder.Entity<PhieuNhap>(b =>
        {
            b.ToTable("PhieuNhap", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.NguoiGiaoHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiCoTk).IsRequired(false);
            b.Property(x => x.Sopn).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TiGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsNhapGiaTb).IsRequired(false);
            b.Property(x => x.PhieuNhapMId).IsRequired(false);
            b.Property(x => x.NgayLapM).IsRequired(false);
            b.Property(x => x.SoHd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHd).IsRequired(false);
            b.Property(x => x.BoPhanId).IsRequired(false);
            b.Property(x => x.GhiChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NhomHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVonVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHang).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHangVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhi).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhiVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienHangCp).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienHangCpVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienChietKhauVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiamGia1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiamGia1VND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiamGia2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiamGia2VND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVatVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNkVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueSuatId).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsChiPhiTinhThue).IsRequired(false);
            b.Property(x => x.HoaDonGTGT).IsRequired(false);
            b.Property(x => x.TkThueNk).IsRequired(false);
            b.Property(x => x.TkThueVat).IsRequired(false);
            b.Property(x => x.TkGiamGia1).IsRequired(false);
            b.Property(x => x.TkGiamGia2).IsRequired(false);
            b.Property(x => x.HanTT).IsRequired(false);
            b.Property(x => x.IsSuaTtThue).IsRequired(false);
            b.Property(x => x.IsSuaTienThue).IsRequired(false);
            b.Property(x => x.IsSuaTkThue).IsRequired(false);
            b.Property(x => x.HanTT).IsRequired(false);
            b.Property(x => x.TienHd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHdVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHdVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsTatToan).IsRequired(false);
            b.Property(x => x.IsChon).IsRequired(false);
            b.Property(x => x.IsSuaHD).IsRequired(false);
            b.Property(x => x.MauHDId).IsRequired(false);
            b.Property(x => x.MauHDUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KyHieuMauHD).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.DiaChi).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.MaSoThue).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.MauBC).IsRequired(false);
            b.Property(x => x.LoaiThueId).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
            b.Property(x => x.ChungTuChiPhi).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PhuongPhapChietKhau).IsRequired(false);
            b.Property(x => x.ConnectAE).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChietKhauDaBan).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhauDaBanVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhauDungDePhanBo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhauDungDePhanBoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkChietKhau).IsRequired(false);
            b.Property(x => x.IsTaoTuDongToanBoDienGiai).IsRequired(false);
        });
        modelBuilder.Entity<PhieuNhapCT>(b =>
        {

            b.ToTable("PhieuNhapCT", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.SoLo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.TonKho).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongBuy).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongPlus).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongConLai).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVonVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVonVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhi).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhiVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNkVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TyLeCk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhauVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkHbtl).IsRequired(false);
            b.Property(x => x.TkKho).IsRequired(false);
            b.Property(x => x.TkGiaVon).IsRequired(false);
            b.Property(x => x.TkChietKhau).IsRequired(false);
            b.Property(x => x.GhiNoTK).IsRequired(false);
            b.Property(x => x.IsXuatTraLai).IsRequired(false);
            b.Property(x => x.PhieuXuatChiTietId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD01).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongTD02).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongTD03).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ConnectAEVatTu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.PhieuNhapCTs).HasForeignKey(x => x.PhieuNhapId);
        });
        modelBuilder.Entity<PhieuXuat>(b =>
        {
            b.ToTable("PhieuXuat", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.GiaoDichId).IsRequired(false);
            b.Property(x => x.MauHoaDonId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.NguoiMuaHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NguoiGiaoHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GhiNoTk).IsRequired(false);
            b.Property(x => x.GhiChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.BoPhanId).IsRequired(false);
            b.Property(x => x.HinhThucTt).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoHd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TiGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsGiaVonDD).IsRequired(false);
            b.Property(x => x.NhomHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MauBC).IsRequired(false);
            b.Property(x => x.LoaiThueId).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVonVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHang).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHangVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienChietKhauVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHangCk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHangCkVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVatVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueSuatId).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.BoPhanId).IsRequired(false);
            b.Property(x => x.GhiChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TkThueVat).IsRequired(false);
            b.Property(x => x.TkThueVatDu).IsRequired(false);
            b.Property(x => x.TkChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsSuaTienThue).IsRequired(false);
            b.Property(x => x.IsSuaTkThue).IsRequired(false);
            b.Property(x => x.HanTt).IsRequired(false);
            b.Property(x => x.TienHd).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHdVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienPhaiTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienPhaiTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ConPhaiTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienTtVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsTatToan).IsRequired(false);
            b.Property(x => x.IsXem).IsRequired(false);
            b.Property(x => x.IsDaIn).IsRequired(false);
            b.Property(x => x.SoHopDong).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHopDong).IsRequired(false);
            b.Property(x => x.DiaDiemGiao).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DiaDiemNhan).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoVanDon).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayVanDon).IsRequired(false);
            b.Property(x => x.NgayVanDon).IsRequired(false);
            b.Property(x => x.SoContainer).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.TenDvvc).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.IsSuaHD).IsRequired(false);
            b.Property(x => x.MauHDId).IsRequired(false);
            b.Property(x => x.MauHDUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KyHieuMauHD).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.DiaChi).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.MaSoThue).HasMaxLength(255).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
            b.Property(x => x.EInvoice).IsRequired(false);
            b.Property(x => x.ECreatedDate).IsRequired(false);
            b.Property(x => x.EModifiedDate).IsRequired(false);
            b.Property(x => x.ECreatedBy).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.TienBangChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.EResultDate).IsRequired(false);
            b.Property(x => x.EResultBy).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.Email).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienThoai).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.TkNganHang).HasColumnType("nvarchar(max)").IsRequired(false);
            b.Property(x => x.Fax).HasColumnType("nvarchar(max)").IsRequired(false);
            b.Property(x => x.EResult).HasColumnType("nvarchar(max)").IsRequired(false);
            b.Property(x => x.SyncError).HasColumnType("nvarchar(max)").IsRequired(false);
            b.Property(x => x.IsBoTrongGia).IsRequired(false);
            b.Property(x => x.mInvoiceInvoiceAuthId).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.mInvoiceSovb).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.mInvoiceNgayvb).IsRequired(false);
            b.Property(x => x.mInvoiceGhiChu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.IsHuy).IsRequired(false);
            b.Property(x => x.ViettelInvoicetransactionID).IsRequired(false);
            b.Property(x => x.ViettelInvoicereservationCode).IsRequired(false);
            b.Property(x => x.CA2HoaDonID).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.CA2KeyTichHop).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.CA2MaTraCuu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.HoaDonVietInvoiceAuthId).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ViettelInvoiceSupplierTaxCode).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ViettelInvoiceTransactionUuid).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ConnectAE).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.IsSuaTienSauThue).IsRequired(false);
        });
        modelBuilder.Entity<PhieuXuatCt>(b =>
        {
            b.ToTable("PhieuXuatCt", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.DiaDiemId).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.SoLo).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongChon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TonKho).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaSauThue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaSauThueVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienSauThue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienSauThueVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVonVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVon).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVonVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkDoanhThu).IsRequired(false);
            b.Property(x => x.TkKho).IsRequired(false);
            b.Property(x => x.TkGiaVon).IsRequired(false);
            b.Property(x => x.TyLeCk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienCk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienCkVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkChietKhau).IsRequired(false);
            b.Property(x => x.GhiCoTk).IsRequired(false);
            b.Property(x => x.IsNhapTraLai).IsRequired(false);
            b.Property(x => x.PhieuNhapChiTietId).IsRequired(false);
            b.Property(x => x.PhieuChonCtId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.VatTuNm3).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ConnectAEVatTu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.ThueSuatId).IsRequired(false);
            b.Property(x => x.TkThue).IsRequired(false);
            b.Property(x => x.DmTapHopChiPhiId).IsRequired(false);
            b.Property(x => x.CongTrinhId).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Thue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVND).HasPrecision(18, 4).IsRequired(false);
            b.HasOne(x => x.PhieuXuat).WithMany(x => x.PhieuXuatCts).HasForeignKey(x => x.PhieuXuatId);
            b.HasOne(x=>x.TheKho).WithOne(y=>y.PhieuXuatCt).HasForeignKey<TheKho>(z => z.PhieuXuatCtId); // liên kết 1-1
        });
        modelBuilder.Entity<TheKho>(b =>
        {
            b.ToTable("TheKho", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapCtId).IsRequired(false);
            b.Property(x => x.PhanBoChiPhiId).IsRequired(false);
            b.Property(x => x.PhieuXuatCtId).IsRequired(false);
            b.Property(x => x.PhieuNhapKhoCtId).IsRequired(false);
            b.Property(x => x.PhieuXuatKhoCtId).IsRequired(false);
            b.Property(x => x.PhieuXuatDcKhoCtId).IsRequired(false);
            b.Property(x => x.TonKhoId).IsRequired(false);
            b.Property(x => x.Ct70Id).IsRequired(false);
            b.Property(x => x.Ct13Id).IsRequired(false);
            b.Property(x => x.Ct76Id).IsRequired(false);
            b.Property(x => x.MaNk).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.MaGd).IsRequired(false);
            b.Property(x => x.PnGiaTb).IsRequired(false);
            b.Property(x => x.PxGiaDd).IsRequired(false);
            b.Property(x => x.BoPhanId).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoDh).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoSeri).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.Ph11Id).IsRequired(false);
            b.Property(x => x.KhonId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.BoPhanId).IsRequired(false);
            b.Property(x => x.GhiNoCoTk).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.TkVatTu).IsRequired(false);
            b.Property(x => x.TkDoanThu).IsRequired(false);
            b.Property(x => x.TkGiaVon).IsRequired(false);
            b.Property(x => x.TkTraLai).IsRequired(false);
            b.Property(x => x.Nxt).IsRequired(false);
            b.Property(x => x.CtDc).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongNhap).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongXuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongNhap1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongXuat1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND1).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienNhap).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienXuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienNhapVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienXuatVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia0).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND0).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia01).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND01).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien0).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND0).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhi).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhiVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNkVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkThueNk).IsRequired(false);
            b.Property(x => x.Gia2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia21).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND21).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND2).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.HanTt).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.CpThueCk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Thue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkThueNo).IsRequired(false);
            b.Property(x => x.TkThueCo).IsRequired(false);
            b.Property(x => x.ChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhauVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkChietKhau).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.SoCt0).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoSeri0).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.NgayCt0).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.IsNhapThuHoi).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.IsBoTinhGia).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.DmTapHopChiPhiId).IsRequired(false);
            b.Property(x => x.CongTrinhId).IsRequired(false);
            b.HasOne(x => x.PhieuXuatKhoCt).WithMany(x => x.TheKhos).HasForeignKey(x => x.PhieuXuatKhoCtId);
            b.HasOne(x => x.PhieuXuatDcKhoCt).WithMany(x => x.TheKhos).HasForeignKey(x => x.PhieuXuatDcKhoCtId);
            b.HasOne(x => x.PhieuNhapKhoCt).WithMany(x => x.TheKhos).HasForeignKey(x => x.PhieuNhapKhoCtId);
        });

        modelBuilder.Entity<DuDauKyCongNo>(b =>
        {
            b.ToTable("DuDauKyCongNo", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.Ngay).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.TaiKhoanId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.DuNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuCoVND).HasPrecision(18, 4).IsRequired(false);

        });

        modelBuilder.Entity<PhieuNhapKho>(b =>
        {
            b.ToTable("PhieuNhapKho", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.GiaoDichId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.NgGiaoHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHT).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsNhapGiaTb).IsRequired(false);
            b.Property(x => x.IsNhapThuHoi).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.RefId).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.IsTaoPhieuXuatKho).IsRequired(false);
            b.Property(x => x.PhieuDieuChinhKhoId).IsRequired(false);
            b.Property(x => x.KhoXuatNVLId).IsRequired(false);
            b.Property(x => x.LenhSanXuatId).IsRequired(false);
        });
        modelBuilder.Entity<PhieuNhapKhoCt>(b =>
        {
            b.ToTable("PhieuNhapKhoCt", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapKhoId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.SoLo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TonKho).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiNoTK).IsRequired(false);
            b.Property(x => x.GhiCoTK).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuNhapKho).WithMany(x => x.PhieuNhapKhoCts).HasForeignKey(x => x.PhieuNhapKhoId);
        });
        modelBuilder.Entity<Kho>(b =>
        {
            b.ToTable("Kho", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.KhoUd).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.KhoNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.KhoNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
        });

        modelBuilder.Entity<PhieuKeToan>(b =>
        {
            b.ToTable("PhieuKeToan", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayCt).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.RefId).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
            b.Property(x => x.IsNghiemThu).IsRequired(false);
        });
        modelBuilder.Entity<PhieuKeToanCt>(b =>
        {
            b.ToTable("PhieuKeToanCt", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuKeToanId).IsRequired(false);
            b.Property(x => x.TaiKhoanId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.PsNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NhomDk).HasColumnType("nvarchar(10)").IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.DmTapHopChiPhiId).IsRequired(false);
            b.Property(x => x.CongTrinhId).IsRequired(false);
            b.HasOne(x => x.PhieuKeToan).WithMany(x => x.PhieuKeToanCts).HasForeignKey(x => x.PhieuKeToanId);
        });

        modelBuilder.Entity<CongTrinh>(b =>
        {
            b.ToTable("CongTrinh", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.CongTrinhUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.CongTrinhNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.CongTrinhNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NgayBatDau).IsRequired(false);
            b.Property(x => x.NgayKetThuc).IsRequired(false);
            b.Property(x => x.DuToan).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChuDauTu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.CongTrinhId1).IsRequired(false);
            b.Property(x => x.IsNghiemThu).IsRequired(false);
            b.Property(x => x.DisplayUd).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.IsCongTrinh).IsRequired(false);
        });

        modelBuilder.Entity<PhieuXuatKho>(b =>
        {
            b.ToTable("PhieuXuatKho", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.GiaoDichId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.NgNhanHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsXuatGiaDd).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.RefId).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.PhieuNhapKhoId).IsRequired(false);
            b.Property(x => x.PhieuDieuChinhKhoId).IsRequired(false);
            b.Property(x => x.LenhSanXuatId).IsRequired(false);
        });
        modelBuilder.Entity<PhieuXuatKhoCt>(b =>
        {
            b.ToTable("PhieuXuatKhoCt", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuXuatKhoId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.SoLo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TonKho).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiCoTk).IsRequired(false);
            b.Property(x => x.GhiNoTk).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.DmTapHopChiPhiId).IsRequired(false);
            b.Property(x => x.CongTrinhId).IsRequired(false);
            b.HasOne(x => x.PhieuXuatKho).WithMany(x => x.PhieuXuatKhoCts).HasForeignKey(x => x.PhieuXuatKhoId);
        });

        modelBuilder.Entity<ManHinhNhap>(b =>
        {
            b.ToTable("ManHinhNhap", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.ChungTuUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.ChungTuMUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.ChungTuNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ChungTuNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoCtHienTai).IsRequired(false);
            b.Property(x => x.SoKyTu0).IsRequired(false);
            b.Property(x => x.SoCtPrefix).IsRequired(false);
            b.Property(x => x.SoCtSuffix).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.SoLien).IsRequired(false);
            b.Property(x => x.MaCtIn).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.SttInBangKe).IsRequired(false);
            b.Property(x => x.TkThueGTGT).IsRequired(false);
            b.Property(x => x.IsMaTuDo).IsRequired(false);
            b.Property(x => x.IsMaVuViec).IsRequired(false);
            b.Property(x => x.IsBpBanHang).IsRequired(false);
            b.Property(x => x.SoLuongLoc).IsRequired(false);
            b.Property(x => x.IsTrungSoCt).IsRequired(false);
            b.Property(x => x.IsTenNguoiGiaoDich).IsRequired(false);
            b.Property(x => x.IsNgayLapCt).IsRequired(false);
            b.Property(x => x.IsLocNguoiDung).IsRequired(false);
            b.Property(x => x.Loai).HasMaxLength(10).IsRequired(false);
            b.Property(x => x.IsChon).IsRequired(false);
            b.Property(x => x.IsMaPhi).IsRequired(false);
            b.Property(x => x.KyHieuMauHD).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.IsThanhPham).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsBoPhanHT).IsRequired(false);
            b.Property(x => x.IsMaDieuChinh).IsRequired(false);
            b.Property(x => x.IsMaTapHopChiPhi).IsRequired(false);
            b.Property(x => x.IsMaCongTrinh).IsRequired(false);
        });
        modelBuilder.Entity<ManHinhNhapCt>(b =>
        {
            b.ToTable("ManHinhNhapCt", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.ManHinhNhapId).IsRequired(false);
            b.Property(x => x.ColumnUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.ColumnCaption).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ColumnCaption2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ColumnOrder).IsRequired(false);
            b.Property(x => x.ColumnWidth).IsRequired(false);
            b.Property(x => x.IsUse).IsRequired(false);
            b.HasOne(x => x.ManHinhNhap).WithMany(x => x.ManHinhNhapCts).HasForeignKey(x => x.ManHinhNhapId);
        });

        modelBuilder.Entity<PhieuXuatDcKho>(b =>
        {
            b.ToTable("PhieuXuatDcKho", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.LoaiPhieu).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.KhoNhapId).IsRequired(false);
            b.Property(x => x.KhoXuatId).IsRequired(false);
            b.Property(x => x.VuViecXuatId).IsRequired(false);
            b.Property(x => x.VuViecNhapId).IsRequired(false);
            b.Property(x => x.NgNhanHang).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoCt).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.QuyenSo).HasMaxLength(50).IsRequired(false);
            b.Property(x => x.NgayHt).IsRequired(false);
            b.Property(x => x.NgayLap).IsRequired(false);
            b.Property(x => x.NgoaiTeId).IsRequired(false);
            b.Property(x => x.TyGia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.IsXuatGiaDd).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TongTienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.RefId).IsRequired(false);
            b.Property(x => x.IsSuaTien).IsRequired(false);
            b.Property(x => x.IsPostSC).IsRequired(false);
            b.Property(x => x.IsBoTinhGia).IsRequired(false);
        });
        modelBuilder.Entity<PhieuXuatDcKhoCt>(b =>
        {
            b.ToTable("PhieuXuatDcKhoCt", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuXuatDcKhoId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.SoLo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TonKho).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiCoTK).IsRequired(false);
            b.Property(x => x.GhiNoTK).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuXuatDcKho).WithMany(x => x.PhieuXuatDcKhoCts).HasForeignKey(x => x.PhieuXuatDcKhoId);
        });
        modelBuilder.Entity<SoPhuSupport>(b =>
        {
            b.ToTable("SoPhuSupport", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
        });

        modelBuilder.Entity<PhanBoChietKhauThuongMai>(b =>
        {
            b.ToTable("PhanBoChietKhauThuongMai", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHang).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHangVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhau).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChietKhauVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkNo).IsRequired(false);
            b.Property(x => x.PhieuNhapCtId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.TyLeCk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.SoLuongDaBan).HasPrecision(18, 4).IsRequired(false);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.PhanBoChietKhauThuongMais).HasForeignKey(x => x.PhieuNhapId);
        });
        modelBuilder.Entity<PhanBoChiPhi>(b =>
        {
            b.ToTable("PhanBoChiPhi", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.TienHang).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienHangVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhi).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ChiPhiVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkNo).IsRequired(false);
            b.Property(x => x.PhieuNhapCtId).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.PhanBoChiPhis).HasForeignKey(x => x.PhieuNhapId);
        });

        modelBuilder.Entity<PhanBoThueNk>(b =>
        {
            b.ToTable("PhanBoThueNk", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNk).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueNkVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkNo).IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.PhanBoThueNks).HasForeignKey(x => x.PhieuNhapId);
        });
        modelBuilder.Entity<NhomVatTu>(b =>
        {
            b.ToTable("NhomVatTu", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.KieuPhanNhom).IsRequired(false);
            b.Property(x => x.NhomVatTuUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.NhomVatTuNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.NhomVatTuNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });
        modelBuilder.Entity<HoaDonMuaHang>(b =>
        {
            b.ToTable("HoaDonMuaHang", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuNhapId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.GhiNoTK).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.NhomDk).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.ConnectAEDichVu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DmTapHopChiPhiId).IsRequired(false);
            b.Property(x => x.CongTrinhId).IsRequired(false);
            b.HasOne(x => x.PhieuNhap).WithMany(x => x.HoaDonMuaHangs).HasForeignKey(x => x.PhieuNhapId);
        });
        modelBuilder.Entity<TonKho>(b =>
        {
            b.ToTable("TonKho", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.NgayCt).IsRequired(false);
            b.Property(x => x.TaiKhoanId).IsRequired(false);
            b.Property(x => x.KhoId).IsRequired(false);
            b.Property(x => x.VatTuId).IsRequired(false);
            b.Property(x => x.NgayLo).IsRequired(false);
            b.Property(x => x.SoLo).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.SoCt).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
        });        
        modelBuilder.Entity<ThamSoHeThong>(b =>
        {
            b.ToTable("ThamSoHeThong", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.ThamSoHeThongUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GiaTri).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GiaTriDate).IsRequired(false);
            b.Property(x => x.Kieu).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.NhomThamSo).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.ThuTu).IsRequired(false);
            b.Property(x => x.IsHidden).IsRequired(false);
        });
        modelBuilder.Entity<HoaDonBanHang>(b =>
        {
            b.ToTable("HoaDonBanHang", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.PhieuXuatId).IsRequired(false);
            b.Property(x => x.KhachHangId).IsRequired(false);
            b.Property(x => x.TkDoanhThu).IsRequired(false);
            b.Property(x => x.Tien).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TienVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsNoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCo).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.PsCoVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.NhomDk).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.ThueSuatId).IsRequired(false);
            b.Property(x => x.ThueSuat).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Thue).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.ThueVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.TkThue).IsRequired(false);
            b.Property(x => x.DienGiai).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaPhiId).IsRequired(false);
            b.Property(x => x.VuViecId).IsRequired(false);
            b.Property(x => x.BoPhanHTId).IsRequired(false);
            b.Property(x => x.VatTuId1).IsRequired(false);
            b.Property(x => x.MaTD01).IsRequired(false);
            b.Property(x => x.NgayTD01).IsRequired(false);
            b.Property(x => x.SoLuongTD01).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD01).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD02).IsRequired(false);
            b.Property(x => x.NgayTD02).IsRequired(false);
            b.Property(x => x.SoLuongTD02).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD02).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.MaTD03).IsRequired(false);
            b.Property(x => x.NgayTD03).IsRequired(false);
            b.Property(x => x.SoLuongTD03).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GhiChuTD03).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DonViTinh).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.SoLuong).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.Gia).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.GiaVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.EInvoice).IsRequired(false);
            b.Property(x => x.ECreatedBy).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ECreatedDate).IsRequired(false);
            b.Property(x => x.EModifiedDate).IsRequired(false);
            b.Property(x => x.DieuChinhThueTNDNId).IsRequired(false);
            b.Property(x => x.ConnectAEDichVu).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.DmTapHopChiPhiId).IsRequired(false);
            b.Property(x => x.CongTrinhId).IsRequired(false);
            b.HasOne(x => x.PhieuXuat).WithMany(x => x.HoaDonBanHangs).HasForeignKey(x => x.PhieuXuatId);
        });

        modelBuilder.Entity<ThueSuat>(b =>
        {
            b.ToTable("ThueSuat", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.ThueSuatUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.ThueSuatNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.ThueSuatNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.GiaTri).IsRequired(false);
            b.Property(x => x.TkCo).IsRequired(false);
            b.Property(x => x.TkNo).IsRequired(false);
        });
        modelBuilder.Entity<BoPhan>(b =>
        {
            b.ToTable("BoPhan", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.BoPhanUd).HasColumnType("nvarchar(50)").IsRequired(false);
            b.Property(x => x.BoPhanNm).HasColumnType("nvarchar(MAX)").IsRequired(false);
            b.Property(x => x.BoPhanNm2).HasColumnType("nvarchar(MAX)").IsRequired(false);
        });      
        modelBuilder.Entity<DuDauKyTk>(b =>
        {
            b.ToTable("DuDauKyTk", ACWebConsts.DbSchema);
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).UseIdentityColumn();
            b.Property(x => x.ChiNhanhId).IsRequired(false);
            b.Property(x => x.Ngay).IsRequired(false);
            b.Property(x => x.TaiKhoanId).IsRequired(false);
            b.Property(x => x.DuNoDauKy).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuNoDauKyVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuCoDauKy).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuCoDauKyVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuNoDauNam).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuNoDauNamVND).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuCoDauNam).HasPrecision(18, 4).IsRequired(false);
            b.Property(x => x.DuCoDauNamVND).HasPrecision(18, 4).IsRequired(false);
        });
    }
}
