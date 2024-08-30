using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class updatedPhieuXuatCt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuXuatCtId",
                table: "TheKho");

            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuXuatCtId",
                table: "TheKho",
                column: "PhieuXuatCtId",
                unique: true,
                filter: "[PhieuXuatCtId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TheKho_PhieuXuatCtId",
                table: "TheKho");

            migrationBuilder.CreateIndex(
                name: "IX_TheKho_PhieuXuatCtId",
                table: "TheKho",
                column: "PhieuXuatCtId");
        }
    }
}
