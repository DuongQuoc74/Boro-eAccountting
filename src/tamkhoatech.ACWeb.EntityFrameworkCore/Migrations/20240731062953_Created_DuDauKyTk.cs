using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDuDauKyTk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuDauKyTk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiNhanhId = table.Column<int>(type: "int", nullable: true),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true),
                    DuNoDauKy = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuNoDauKyVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuCoDauKy = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuCoDauKyVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuNoDauNam = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuNoDauNamVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuCoDauNam = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DuCoDauNamVND = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
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
                    table.PrimaryKey("PK_DuDauKyTk", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuDauKyTk");
        }
    }
}
