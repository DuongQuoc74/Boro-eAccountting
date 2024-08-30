using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240408CreatedPhieuKeToanEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuKeToan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiPhieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    NgayHt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayCt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoCt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuyenSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    TyGia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsNo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsNoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsCo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsCoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    IsSuaTien = table.Column<bool>(type: "bit", nullable: true),
                    IsPostSC = table.Column<bool>(type: "bit", nullable: true),
                    IsNghiemThu = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_PhieuKeToan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuKeToanCt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuKeToanId = table.Column<int>(type: "int", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    PsNo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsNoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsCo = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PsCoVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NhomDk = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
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
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true),
                    DmTapHopChiPhiId = table.Column<int>(type: "int", nullable: true),
                    CongTrinhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKeToanCt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuKeToanCt_PhieuKeToan_PhieuKeToanId",
                        column: x => x.PhieuKeToanId,
                        principalTable: "PhieuKeToan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKeToanCt_PhieuKeToanId",
                table: "PhieuKeToanCt",
                column: "PhieuKeToanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuKeToanCt");

            migrationBuilder.DropTable(
                name: "PhieuKeToan");
        }
    }
}
