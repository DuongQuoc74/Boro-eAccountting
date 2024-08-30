using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class HasForeignKeyKhachHangVsHoaDonGTGT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HoaDonGTGT_KhachHangId",
                table: "HoaDonGTGT",
                column: "KhachHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonGTGT_KhachHang_KhachHangId",
                table: "HoaDonGTGT",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_NhomKhachHang2",
                table: "KhachHang",
                column: "NhomKhachHang2");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_NhomKhachHang_NhomKhachHang2",
                table: "KhachHang",
                column: "NhomKhachHang2",
                principalTable: "NhomKhachHang",
                principalColumn: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_NhomKhachHang1",
                table: "KhachHang",
                column: "NhomKhachHang1");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_NhomKhachHang_NhomKhachHang1",
                table: "KhachHang",
                column: "NhomKhachHang1",
                principalTable: "NhomKhachHang",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonGTGT_KhachHang_KhachHangId",
                table: "HoaDonGTGT");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonGTGT_KhachHangId",
                table: "HoaDonGTGT");
        }
    }
}
