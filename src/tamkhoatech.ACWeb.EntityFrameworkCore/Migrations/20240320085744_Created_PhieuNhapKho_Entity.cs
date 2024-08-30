using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedPhieuNhapKhoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhieuNhapKhoId",
                table: "TheKho",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhieuNhapKho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    GiaoDichId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    NgGiaoHang = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SoCt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuyenSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    TyGia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    IsNhapGiaTb = table.Column<bool>(type: "bit", nullable: true),
                    IsNhapThuHoi = table.Column<bool>(type: "bit", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TongTienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    IsSuaTien = table.Column<bool>(type: "bit", nullable: true),
                    IsPostSC = table.Column<bool>(type: "bit", nullable: true),
                    PhieuXuatId = table.Column<int>(type: "int", nullable: true),
                    IsTaoPhieuXuatKho = table.Column<bool>(type: "bit", nullable: true),
                    PhieuDieuChinhKhoId = table.Column<int>(type: "int", nullable: true),
                    KhoXuatNVLId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PhieuNhapKho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapKhoCt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapKhoId = table.Column<int>(type: "int", nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: true),
                    NgayLo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TonKho = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Tien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GhiNoTK = table.Column<int>(type: "int", nullable: true),
                    GhiCoTK = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    BoPhanHTId = table.Column<int>(type: "int", nullable: true),
                    VatTuId1 = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    NgayTD01 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD01 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChuTD01 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    NgayTD02 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD02 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChuTD02 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
                    NgayTD03 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoLuongTD03 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChuTD03 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapKhoCt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuNhapKhoCt_PhieuNhapKho_PhieuNhapKhoId",
                        column: x => x.PhieuNhapKhoId,
                        principalTable: "PhieuNhapKho",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuNhapKhoId",
                table: "TheKho",
                column: "PhieuNhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_SoCai_PhieuNhapKhoId",
                table: "SoCai",
                column: "PhieuNhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapKhoCt_PhieuNhapKhoId",
                table: "PhieuNhapKhoCt",
                column: "PhieuNhapKhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoCai_PhieuNhapKho_PhieuNhapKhoId",
                table: "SoCai",
                column: "PhieuNhapKhoId",
                principalTable: "PhieuNhapKho",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheKho_PhieuNhapKho_PhieuNhapKhoId",
                table: "TheKho",
                column: "PhieuNhapKhoId",
                principalTable: "PhieuNhapKho",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoCai_PhieuNhapKho_PhieuNhapKhoId",
                table: "SoCai");

            migrationBuilder.DropForeignKey(
                name: "FK_TheKho_PhieuNhapKho_PhieuNhapKhoId",
                table: "TheKho");

            migrationBuilder.DropTable(
                name: "PhieuNhapKhoCt");

            migrationBuilder.DropTable(
                name: "PhieuNhapKho");

            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuNhapKhoId",
                table: "TheKho");

            migrationBuilder.DropIndex(
                name: "IX_SoCai_PhieuNhapKhoId",
                table: "SoCai");

            migrationBuilder.DropColumn(
                name: "PhieuNhapKhoId",
                table: "TheKho");
        }
    }
}
