using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240126CreateTableTheKhoDuDauKyCongNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuDauKyCongNo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    DuNo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuNoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuCo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuCoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuDauKyCongNo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheKho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapChiTietId = table.Column<int>(type: "int", nullable: true),
                    PhanBoChiPhiId = table.Column<int>(type: "int", nullable: true),
                    PhieuXuatChiTietId = table.Column<int>(type: "int", nullable: true),
                    PhieuNhapKhoCtId = table.Column<int>(type: "int", nullable: true),
                    PhieuXuatKhoCtId = table.Column<int>(type: "int", nullable: true),
                    PhieuXuatDcKhoCtId = table.Column<int>(type: "int", nullable: true),
                    TonKhoId = table.Column<int>(type: "int", nullable: true),
                    Ct70Id = table.Column<int>(type: "int", nullable: true),
                    Ct13Id = table.Column<int>(type: "int", nullable: true),
                    Ct76Id = table.Column<int>(type: "int", nullable: true),
                    MaNk = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaGd = table.Column<int>(type: "int", nullable: true),
                    PnGiaTb = table.Column<int>(type: "int", nullable: true),
                    PxGiaDd = table.Column<int>(type: "int", nullable: true),
                    NgayHt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoCt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoSeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayLo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    Ph11Id = table.Column<int>(type: "int", nullable: true),
                    KhonId = table.Column<int>(type: "int", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    BoPhanId = table.Column<int>(type: "int", nullable: true),
                    GhiNoCoTk = table.Column<int>(type: "int", nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    TyGia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    TkVatTu = table.Column<int>(type: "int", nullable: true),
                    TkDoanThu = table.Column<int>(type: "int", nullable: true),
                    TkGiaVon = table.Column<int>(type: "int", nullable: true),
                    TkTraLai = table.Column<int>(type: "int", nullable: true),
                    Nxt = table.Column<int>(type: "int", nullable: true),
                    CtDc = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongNhap = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongXuat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongNhap1 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongXuat1 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia1 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND1 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienNhap = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienXuat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienNhapVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienXuatVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia0 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND0 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia01 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND01 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Tien0 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND0 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhiVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNkVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkThueNk = table.Column<int>(type: "int", nullable: true),
                    Gia2 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND2 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia21 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND21 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Tien2 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND2 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    HanTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    CpThueCk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueSuat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Thue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkThueNo = table.Column<int>(type: "int", nullable: true),
                    TkThueCo = table.Column<int>(type: "int", nullable: true),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhauVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkChietKhau = table.Column<int>(type: "int", nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    SoCt0 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoSeri0 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    NgayCt0 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
                    IsNhapThuHoi = table.Column<bool>(type: "bit", nullable: true),
                    BoPhanHTId = table.Column<int>(type: "int", nullable: true),
                    VatTuId1 = table.Column<int>(type: "int", nullable: true),
                    IsBoTinhGia = table.Column<bool>(type: "bit", nullable: true),
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true),
                    DmTapHopChiPhiId = table.Column<int>(type: "int", nullable: true),
                    CongTrinhId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheKho", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuDauKyCongNo");

            migrationBuilder.DropTable(
                name: "TheKho");
        }
    }
}
