using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedPhanBoChiPhiThuongMai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "PhieuNhapCT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "PhieuNhapCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "PhieuNhapCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PhieuNhapCT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PhieuNhapCT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PhieuNhapCT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "PhieuNhapCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhanBoChietKhauThuongMai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapId = table.Column<int>(type: "int", nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHang = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHangVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhau = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChietKhauVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkNo = table.Column<int>(type: "int", nullable: true),
                    PhieuNhapCtId = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true),
                    TyLeCk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SoLuongDaBan = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
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
                    table.PrimaryKey("PK_PhanBoChietKhauThuongMai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanBoChietKhauThuongMai_PhieuNhap_PhieuNhapId",
                        column: x => x.PhieuNhapId,
                        principalTable: "PhieuNhap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhanBoChiPhi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapId = table.Column<int>(type: "int", nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: true),
                    TienHang = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienHangVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhi = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChiPhiVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkNo = table.Column<int>(type: "int", nullable: true),
                    PhieuNhapCtId = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
                    DieuChinhThueTNDNId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PhanBoChiPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanBoChiPhi_PhieuNhap_PhieuNhapId",
                        column: x => x.PhieuNhapId,
                        principalTable: "PhieuNhap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoCai_PhieuNhapId",
                table: "SoCai",
                column: "PhieuNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonGTGT_PhieuNhapId",
                table: "HoaDonGTGT",
                column: "PhieuNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoChietKhauThuongMai_PhieuNhapId",
                table: "PhanBoChietKhauThuongMai",
                column: "PhieuNhapId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoChiPhi_PhieuNhapId",
                table: "PhanBoChiPhi",
                column: "PhieuNhapId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonGTGT_PhieuNhap_PhieuNhapId",
                table: "HoaDonGTGT",
                column: "PhieuNhapId",
                principalTable: "PhieuNhap",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoCai_PhieuNhap_PhieuNhapId",
                table: "SoCai",
                column: "PhieuNhapId",
                principalTable: "PhieuNhap",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonGTGT_PhieuNhap_PhieuNhapId",
                table: "HoaDonGTGT");

            migrationBuilder.DropForeignKey(
                name: "FK_SoCai_PhieuNhap_PhieuNhapId",
                table: "SoCai");

            migrationBuilder.DropTable(
                name: "PhanBoChietKhauThuongMai");

            migrationBuilder.DropTable(
                name: "PhanBoChiPhi");

            migrationBuilder.DropIndex(
                name: "IX_SoCai_PhieuNhapId",
                table: "SoCai");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonGTGT_PhieuNhapId",
                table: "HoaDonGTGT");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "PhieuNhapCT");
        }
    }
}
