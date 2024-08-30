using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTheKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheKho_PhieuNhapKho_PhieuNhapKhoId",
                table: "TheKho");

            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuNhapKhoId",
                table: "TheKho");

            migrationBuilder.DropColumn(
                name: "PhieuNhapChiTietId",
                table: "TheKho");

            migrationBuilder.RenameColumn(
                name: "PhieuXuatChiTietId",
                table: "TheKho",
                newName: "PhieuXuatCtId");

            migrationBuilder.RenameColumn(
                name: "PhieuNhapKhoId",
                table: "TheKho",
                newName: "PhieuNhapCtId");

            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuNhapKhoCtId",
                table: "TheKho",
                column: "PhieuNhapKhoCtId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheKho_PhieuNhapKhoCt_PhieuNhapKhoCtId",
                table: "TheKho",
                column: "PhieuNhapKhoCtId",
                principalTable: "PhieuNhapKhoCt",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheKho_PhieuNhapKhoCt_PhieuNhapKhoCtId",
                table: "TheKho");

            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuNhapKhoCtId",
                table: "TheKho");

            migrationBuilder.RenameColumn(
                name: "PhieuXuatCtId",
                table: "TheKho",
                newName: "PhieuXuatChiTietId");

            migrationBuilder.RenameColumn(
                name: "PhieuNhapCtId",
                table: "TheKho",
                newName: "PhieuNhapKhoId");

            migrationBuilder.AddColumn<int>(
                name: "PhieuNhapChiTietId",
                table: "TheKho",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuNhapKhoId",
                table: "TheKho",
                column: "PhieuNhapKhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheKho_PhieuNhapKho_PhieuNhapKhoId",
                table: "TheKho",
                column: "PhieuNhapKhoId",
                principalTable: "PhieuNhapKho",
                principalColumn: "Id");
        }
    }
}
