using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedHoaDonBanHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDonBanHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuXuatId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    TkDoanhThu = table.Column<int>(type: "int", nullable: true),
                    Tien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsNo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsNoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsCo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsCoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    NhomDk = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ThueSuatId = table.Column<int>(type: "int", nullable: true),
                    ThueSuat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Thue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkThue = table.Column<int>(type: "int", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
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
                    DonViTinh = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    EInvoice = table.Column<bool>(type: "bit", nullable: true),
                    ECreatedBy = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ECreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true),
                    ConnectAEDichVu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
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
                    table.PrimaryKey("PK_HoaDonBanHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_PhieuXuat_PhieuXuatId",
                        column: x => x.PhieuXuatId,
                        principalTable: "PhieuXuat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoCai_PhieuXuatId",
                table: "SoCai",
                column: "PhieuXuatId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonGTGT_PhieuXuatId",
                table: "HoaDonGTGT",
                column: "PhieuXuatId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_PhieuXuatId",
                table: "HoaDonBanHang",
                column: "PhieuXuatId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonGTGT_PhieuXuat_PhieuXuatId",
                table: "HoaDonGTGT",
                column: "PhieuXuatId",
                principalTable: "PhieuXuat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoCai_PhieuXuat_PhieuXuatId",
                table: "SoCai",
                column: "PhieuXuatId",
                principalTable: "PhieuXuat",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonGTGT_PhieuXuat_PhieuXuatId",
                table: "HoaDonGTGT");

            migrationBuilder.DropForeignKey(
                name: "FK_SoCai_PhieuXuat_PhieuXuatId",
                table: "SoCai");

            migrationBuilder.DropTable(
                name: "HoaDonBanHang");

            migrationBuilder.DropIndex(
                name: "IX_SoCai_PhieuXuatId",
                table: "SoCai");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonGTGT_PhieuXuatId",
                table: "HoaDonGTGT");
        }
    }
}
