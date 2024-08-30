using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240422CreatedPhieuXuatKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuXuatKho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    GiaoDichId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    NgNhanHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SoCt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuyenSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    TyGia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsXuatGiaDd = table.Column<bool>(type: "bit", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    IsSuaTien = table.Column<bool>(type: "bit", nullable: true),
                    IsPostSC = table.Column<bool>(type: "bit", nullable: true),
                    PhieuXuatId = table.Column<int>(type: "int", nullable: true),
                    PhieuNhapKhoId = table.Column<int>(type: "int", nullable: true),
                    PhieuDieuChinhKhoId = table.Column<int>(type: "int", nullable: true),
                    LenhSanXuatId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PhieuXuatKho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuatKhoCt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuXuatKhoId = table.Column<int>(type: "int", nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: true),
                    NgayLo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLo = table.Column<string>(type: "nvarchar(max)", precision: 18, scale: 4, nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TonKho = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Tien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GhiCoTk = table.Column<int>(type: "int", nullable: true),
                    GhiNoTk = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    BoPhanHTId = table.Column<int>(type: "int", nullable: true),
                    VatTuId1 = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    NgayTD01 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD01 = table.Column<int>(type: "int", nullable: true),
                    GhiChuTD01 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    NgayTD02 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuTD02 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
                    NgayTD03 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD03 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChuTD03 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
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
                    table.PrimaryKey("PK_PhieuXuatKhoCt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuXuatKhoCt_PhieuXuatKho_PhieuXuatKhoId",
                        column: x => x.PhieuXuatKhoId,
                        principalTable: "PhieuXuatKho",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuatKhoCt_PhieuXuatKhoId",
                table: "PhieuXuatKhoCt",
                column: "PhieuXuatKhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuXuatKhoCt");

            migrationBuilder.DropTable(
                name: "PhieuXuatKho");
        }
    }
}
