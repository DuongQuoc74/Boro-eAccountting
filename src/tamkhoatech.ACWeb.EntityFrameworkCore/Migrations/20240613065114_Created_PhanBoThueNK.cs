using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedPhanBoThueNK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TyGiaNgoaiTe_NgoaiTe_NgoaiTeId",
                table: "TyGiaNgoaiTe");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "TyGiaNgoaiTe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "TyGiaNgoaiTe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "TyGiaNgoaiTe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "TyGiaNgoaiTe",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TyGiaNgoaiTe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "TyGiaNgoaiTe",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "TyGiaNgoaiTe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "PhieuThuCT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "PhieuThuCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "PhieuThuCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PhieuThuCT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PhieuThuCT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PhieuThuCT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "PhieuThuCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "PhieuNhapKhoCt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "PhieuNhapKhoCt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "PhieuNhapKhoCt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PhieuNhapKhoCt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PhieuNhapKhoCt",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PhieuNhapKhoCt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "PhieuNhapKhoCt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "PhieuChiCT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "PhieuChiCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "PhieuChiCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PhieuChiCT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PhieuChiCT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PhieuChiCT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "PhieuChiCT",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MaGiaoDich",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "MaGiaoDich",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "MaGiaoDich",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MaGiaoDich",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MaGiaoDich",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MaGiaoDich",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "MaGiaoDich",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhanBoThueNk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapId = table.Column<int>(type: "int", nullable: true),
                    VatTuId = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    GiaVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Tien = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TienVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNk = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ThueNkVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TkNo = table.Column<int>(type: "int", nullable: true),
                    MaPhiId = table.Column<int>(type: "int", nullable: true),
                    VuViecId = table.Column<int>(type: "int", nullable: true),
                    MaTD01 = table.Column<int>(type: "int", nullable: true),
                    MaTD02 = table.Column<int>(type: "int", nullable: true),
                    MaTD03 = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PhanBoThueNk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanBoThueNk_PhieuNhap_PhieuNhapId",
                        column: x => x.PhieuNhapId,
                        principalTable: "PhieuNhap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoThueNk_PhieuNhapId",
                table: "PhanBoThueNk",
                column: "PhieuNhapId");

            migrationBuilder.AddForeignKey(
                name: "FK_TyGiaNgoaiTe_NgoaiTe_NgoaiTeId",
                table: "TyGiaNgoaiTe",
                column: "NgoaiTeId",
                principalTable: "NgoaiTe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TyGiaNgoaiTe_NgoaiTe_NgoaiTeId",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropTable(
                name: "PhanBoThueNk");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "TyGiaNgoaiTe");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "PhieuThuCT");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "PhieuNhapKhoCt");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "PhieuChiCT");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MaGiaoDich");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "MaGiaoDich");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "MaGiaoDich");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MaGiaoDich");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MaGiaoDich");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MaGiaoDich");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "MaGiaoDich");

            migrationBuilder.AddForeignKey(
                name: "FK_TyGiaNgoaiTe_NgoaiTe_NgoaiTeId",
                table: "TyGiaNgoaiTe",
                column: "NgoaiTeId",
                principalTable: "NgoaiTe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
