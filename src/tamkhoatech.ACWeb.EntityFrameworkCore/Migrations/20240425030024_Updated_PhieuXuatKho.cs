using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPhieuXuatKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuXuatKhoCtId",
                table: "TheKho",
                column: "PhieuXuatKhoCtId");

            migrationBuilder.CreateIndex(
                name: "IX_SoCai_PhieuXuatKhoId",
                table: "SoCai",
                column: "PhieuXuatKhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoCai_PhieuXuatKho_PhieuXuatKhoId",
                table: "SoCai",
                column: "PhieuXuatKhoId",
                principalTable: "PhieuXuatKho",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheKho_PhieuXuatKhoCt_PhieuXuatKhoCtId",
                table: "TheKho",
                column: "PhieuXuatKhoCtId",
                principalTable: "PhieuXuatKhoCt",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoCai_PhieuXuatKho_PhieuXuatKhoId",
                table: "SoCai");

            migrationBuilder.DropForeignKey(
                name: "FK_TheKho_PhieuXuatKhoCt_PhieuXuatKhoCtId",
                table: "TheKho");

            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuXuatKhoCtId",
                table: "TheKho");

            migrationBuilder.DropIndex(
                name: "IX_SoCai_PhieuXuatKhoId",
                table: "SoCai");
        }
    }
}
