using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20242304CreatedManHinhNhap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManHinhNhap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChungTuUd = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ChungTuNm = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ChungTuNm2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ChungTuMUd = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SoCtHienTai = table.Column<int>(type: "int", nullable: true),
                    SoKyTu0 = table.Column<int>(type: "int", nullable: true),
                    SoCtPrefix = table.Column<int>(type: "int", nullable: true),
                    SoCtSuffix = table.Column<int>(type: "int", nullable: true),
                    NgoaiTeId = table.Column<int>(type: "int", nullable: true),
                    SoLien = table.Column<int>(type: "int", nullable: true),
                    MaCtIn = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SttInBangKe = table.Column<int>(type: "int", nullable: true),
                    TkThueGTGT = table.Column<int>(type: "int", nullable: true),
                    IsMaTuDo = table.Column<bool>(type: "bit", nullable: true),
                    IsMaVuViec = table.Column<bool>(type: "bit", nullable: true),
                    IsBpBanHang = table.Column<bool>(type: "bit", nullable: true),
                    SoLuongLoc = table.Column<int>(type: "int", nullable: true),
                    IsTrungSoCt = table.Column<bool>(type: "bit", nullable: true),
                    IsTenNguoiGiaoDich = table.Column<bool>(type: "bit", nullable: true),
                    IsNgayLapCt = table.Column<bool>(type: "bit", nullable: true),
                    IsLocNguoiDung = table.Column<bool>(type: "bit", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsChon = table.Column<bool>(type: "bit", nullable: true),
                    IsMaPhi = table.Column<bool>(type: "bit", nullable: true),
                    KyHieuMauHD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsThanhPham = table.Column<bool>(type: "bit", nullable: true),
                    IsBoPhanHT = table.Column<bool>(type: "bit", nullable: true),
                    IsSuaTien = table.Column<bool>(type: "bit", nullable: true),
                    IsMaDieuChinh = table.Column<bool>(type: "bit", nullable: true),
                    IsMaTapHopChiPhi = table.Column<bool>(type: "bit", nullable: true),
                    IsMaCongTrinh = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_ManHinhNhap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManHinhNhapCt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManHinhNhapId = table.Column<int>(type: "int", nullable: true),
                    ColumnUd = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ColumnCaption = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ColumnCaption2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ColumnOrder = table.Column<int>(type: "int", nullable: true),
                    ColumnWidth = table.Column<int>(type: "int", nullable: true),
                    IsUse = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ManHinhNhapCt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManHinhNhapCt_ManHinhNhap_ManHinhNhapId",
                        column: x => x.ManHinhNhapId,
                        principalTable: "ManHinhNhap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManHinhNhapCt_ManHinhNhapId",
                table: "ManHinhNhapCt",
                column: "ManHinhNhapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManHinhNhapCt");

            migrationBuilder.DropTable(
                name: "ManHinhNhap");
        }
    }
}
