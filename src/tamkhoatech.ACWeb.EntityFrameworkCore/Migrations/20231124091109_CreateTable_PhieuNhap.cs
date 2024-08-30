using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablePhieuNhap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    NguoiGiaoHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    GhiCoTk = table.Column<int>(type: "int", nullable: true),
                    Sopn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuyenSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    TiGia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsNhapGiaTb = table.Column<bool>(type: "bit", nullable: true),
                    PhieuNhapMId = table.Column<int>(type: "int", nullable: true),
                    NgayLapM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoHd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoSeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoPhanId = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NhomHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVon = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVonVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHang = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHangVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhiVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTienHangCp = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTienHangCpVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienChietKhauVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiamGia1 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiamGia1VND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiamGia2 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiamGia2VND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueVat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueVatVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNkVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueSuatId = table.Column<int>(type: "int", nullable: true),
                    ThueSuat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsChiPhiTinhThue = table.Column<bool>(type: "bit", nullable: true),
                    HoaDonGTGT = table.Column<int>(type: "int", nullable: true),
                    TkThueNk = table.Column<int>(type: "int", nullable: true),
                    TkThueVat = table.Column<int>(type: "int", nullable: true),
                    TkThueVatDu = table.Column<int>(type: "int", nullable: true),
                    TkGiamGia1 = table.Column<int>(type: "int", nullable: true),
                    TkGiamGia2 = table.Column<int>(type: "int", nullable: true),
                    HanTT = table.Column<int>(type: "int", nullable: true),
                    IsSuaTtThue = table.Column<bool>(type: "bit", nullable: true),
                    IsSuaTienThue = table.Column<bool>(type: "bit", nullable: true),
                    IsSuaTkThue = table.Column<bool>(type: "bit", nullable: true),
                    TienHd = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHdVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienPhaiTt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienPhaiTtVND = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConPhaiTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ConPhaiTtVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienTtVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsTatToan = table.Column<bool>(type: "bit", nullable: true),
                    IsChon = table.Column<bool>(type: "bit", nullable: true),
                    IsSuaHD = table.Column<bool>(type: "bit", nullable: true),
                    MauHDId = table.Column<int>(type: "int", nullable: true),
                    MauHDUd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieuMauHD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsSuaTien = table.Column<bool>(type: "bit", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaSoThue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MauBC = table.Column<int>(type: "int", nullable: true),
                    LoaiThueId = table.Column<int>(type: "int", nullable: true),
                    IsPostSC = table.Column<bool>(type: "bit", nullable: true),
                    ChungTuChiPhi = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ChietKhauVND = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhuongPhapChietKhau = table.Column<int>(type: "int", nullable: true),
                    ConnectAE = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ChietKhauDaBan = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhauDaBanVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhauDungDePhanBo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhauDungDePhanBoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsTaoTuDongToanBoDienGiai = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_PhieuNhap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapCT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapId = table.Column<int>(type: "int", nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: true),
                    NgayLo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TonKho = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongBuy = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongPlus = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongConLai = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Tien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienTtVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVon = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVonVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVon = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVonVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhiVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNkVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TyLeCk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhauVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkHbtl = table.Column<int>(type: "int", nullable: true),
                    TkKho = table.Column<int>(type: "int", nullable: true),
                    TkGiaVon = table.Column<int>(type: "int", nullable: true),
                    TkChietKhau = table.Column<int>(type: "int", nullable: true),
                    GhiNoTK = table.Column<int>(type: "int", nullable: true),
                    IsXuatTraLai = table.Column<bool>(type: "bit", nullable: true),
                    PhieuXuatChiTietId = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    BoPhanHTId = table.Column<int>(type: "int", nullable: true),
                    VatTuId1 = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    NgayTD01 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD01 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GhiChuTD01 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    NgayTD02 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD02 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GhiChuTD02 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
                    NgayTD03 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD03 = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GhiChuTD03 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true),
                    ConnectAEVatTu = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuNhapCT_PhieuNhap_PhieuNhapId",
                        column: x => x.PhieuNhapId,
                        principalTable: "PhieuNhap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapCT_PhieuNhapId",
                table: "PhieuNhapCT",
                column: "PhieuNhapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuNhapCT");

            migrationBuilder.DropTable(
                name: "PhieuNhap");
        }
    }
}
