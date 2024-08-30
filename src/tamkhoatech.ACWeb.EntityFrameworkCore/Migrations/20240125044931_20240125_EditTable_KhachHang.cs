using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240125EditTableKhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_NhomKhachHang_NhomKhachHang3",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_NhomKhachHang3",
                table: "KhachHang");

            migrationBuilder.DropForeignKey(
            name: "FK_KhachHang_NhomKhachHang_NhomKhachHang2",
            table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_NhomKhachHang2",
                table: "KhachHang");

            migrationBuilder.DropForeignKey(
            name: "FK_KhachHang_NhomKhachHang_NhomKhachHang1",
            table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_NhomKhachHang1",
                table: "KhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
