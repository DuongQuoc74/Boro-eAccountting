using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class updatedPhieuXuatDcKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuXuatDcKhoCtId",
                table: "TheKho",
                column: "PhieuXuatDcKhoCtId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheKho_PhieuXuatDcKhoCt_PhieuXuatDcKhoCtId",
                table: "TheKho",
                column: "PhieuXuatDcKhoCtId",
                principalTable: "PhieuXuatDcKhoCt",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheKho_PhieuXuatDcKhoCt_PhieuXuatDcKhoCtId",
                table: "TheKho");

            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuXuatDcKhoCtId",
                table: "TheKho");
        }
    }
}
