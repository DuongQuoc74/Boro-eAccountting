using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableNhomKhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NhomKhachHang1",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhomKhachHang2",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhomKhachHang3",
                table: "KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NhomKhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhomKhachHangUd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NhomKhachHangNm = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    NhomKhachHangNm2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    KieuPhanNhom = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_NhomKhachHang", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_NhomKhachHang3",
                table: "KhachHang",
                column: "NhomKhachHang3");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_NhomKhachHang_NhomKhachHang3",
                table: "KhachHang",
                column: "NhomKhachHang3",
                principalTable: "NhomKhachHang",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_NhomKhachHang_NhomKhachHang3",
                table: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhomKhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_NhomKhachHang3",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "NhomKhachHang1",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "NhomKhachHang2",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "NhomKhachHang3",
                table: "KhachHang");
        }
    }
}
