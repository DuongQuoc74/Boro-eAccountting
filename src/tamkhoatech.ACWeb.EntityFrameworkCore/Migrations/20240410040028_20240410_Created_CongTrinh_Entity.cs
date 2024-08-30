using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240410CreatedCongTrinhEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CongTrinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CongTrinhUd = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CongTrinhNm = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CongTrinhNm2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuToan = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ChuDauTu = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CongTrinhId1 = table.Column<int>(type: "int", nullable: true),
                    IsNghiemThu = table.Column<bool>(type: "bit", nullable: true),
                    DisplayUd = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsCongTrinh = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_CongTrinh", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongTrinh");
        }
    }
}
