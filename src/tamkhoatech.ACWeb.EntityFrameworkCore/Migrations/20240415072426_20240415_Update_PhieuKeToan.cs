using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240415UpdatePhieuKeToan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SoCai_PhieuKeToanId",
                table: "SoCai",
                column: "PhieuKeToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonGTGT_PhieuKeToanId",
                table: "HoaDonGTGT",
                column: "PhieuKeToanId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonGTGT_PhieuKeToan_PhieuKeToanId",
                table: "HoaDonGTGT",
                column: "PhieuKeToanId",
                principalTable: "PhieuKeToan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoCai_PhieuKeToan_PhieuKeToanId",
                table: "SoCai",
                column: "PhieuKeToanId",
                principalTable: "PhieuKeToan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonGTGT_PhieuKeToan_PhieuKeToanId",
                table: "HoaDonGTGT");

            migrationBuilder.DropForeignKey(
                name: "FK_SoCai_PhieuKeToan_PhieuKeToanId",
                table: "SoCai");

            migrationBuilder.DropIndex(
                name: "IX_SoCai_PhieuKeToanId",
                table: "SoCai");

            migrationBuilder.DropIndex(
                name: "IX_HoaDonGTGT_PhieuKeToanId",
                table: "HoaDonGTGT");
        }
    }
}
