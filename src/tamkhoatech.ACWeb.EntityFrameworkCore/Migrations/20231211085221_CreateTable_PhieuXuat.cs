using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablePhieuXuat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    GiaoDichId = table.Column<int>(type: "int", nullable: true),
                    MauHoaDonId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    NguoiMuaHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NguoiGiaoHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    GhiNoTk = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    BoPhanId = table.Column<int>(type: "int", nullable: true),
                    HinhThucTt = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SoCt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuyenSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoHd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoSeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    TiGia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsGiaVonDD = table.Column<bool>(type: "bit", nullable: true),
                    NhomHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MauBC = table.Column<int>(type: "int", nullable: true),
                    LoaiThueId = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVon = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVonVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHang = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHangVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienChietKhauVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHangCk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHangCkVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueVat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueVatVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueSuatId = table.Column<int>(type: "int", nullable: true),
                    ThueSuat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkThueVat = table.Column<int>(type: "int", nullable: true),
                    TkThueVatDu = table.Column<int>(type: "int", nullable: true),
                    TkChietKhau = table.Column<int>(type: "int", precision: 18, scale: 4, nullable: true),
                    IsSuaTienThue = table.Column<bool>(type: "bit", nullable: true),
                    IsSuaTkThue = table.Column<bool>(type: "bit", nullable: true),
                    IsSuaTienCk = table.Column<bool>(type: "bit", nullable: true),
                    HanTt = table.Column<int>(type: "int", nullable: true),
                    TienHd = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHdVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienPhaiTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienPhaiTtVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ConPhaiTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ConPhaiTtVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienTt = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienTtVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsTatToan = table.Column<bool>(type: "bit", nullable: true),
                    IsXem = table.Column<bool>(type: "bit", nullable: true),
                    IsDaIn = table.Column<bool>(type: "bit", nullable: true),
                    SoHopDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHopDong = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaDiemGiao = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DiaDiemNhan = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SoVanDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayVanDon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoContainer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDvvc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsSuaHD = table.Column<bool>(type: "bit", nullable: true),
                    MauHDId = table.Column<int>(type: "int", nullable: true),
                    MauHDUd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieuMauHD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsSuaTien = table.Column<bool>(type: "bit", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaSoThue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsAmThue = table.Column<bool>(type: "bit", nullable: true),
                    IsPostSC = table.Column<bool>(type: "bit", nullable: true),
                    EInvoice = table.Column<bool>(type: "bit", nullable: true),
                    ECreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ECreatedBy = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TienBangChu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    EResultDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EResultBy = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TkNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyncError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBoTrongGia = table.Column<bool>(type: "bit", nullable: true),
                    mInvoiceInvoiceAuthId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    mInvoiceSovb = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    mInvoiceNgayvb = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mInvoiceGhiChu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsHuy = table.Column<bool>(type: "bit", nullable: true),
                    ViettelInvoicetransactionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViettelInvoicereservationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CA2HoaDonID = table.Column<string>(name: "CA2HoaDonID", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CA2KeyTichHop = table.Column<string>(name: "CA2KeyTichHop", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CA2MaTraCuu = table.Column<string>(name: "CA2MaTraCuu", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoaDonVietInvoiceAuthId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ViettelInvoiceSupplierTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ViettelInvoiceTransactionUuid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConnectAE = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsSuaTienSauThue = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_PhieuXuat", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuXuat");
        }
    }
}
