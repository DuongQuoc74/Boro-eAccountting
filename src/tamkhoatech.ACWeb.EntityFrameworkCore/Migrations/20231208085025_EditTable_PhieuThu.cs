using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class EditTablePhieuThu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuCT_PhieuThu_PhieuThuId",
                table: "PhieuThuCT");

            migrationBuilder.CreateIndex(
                name: "IX_SoCai_PhieuThuId",
                table: "SoCai",
                column: "PhieuThuId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuCT_PhieuThu_PhieuThuId",
                table: "PhieuThuCT",
                column: "PhieuThuId",
                principalTable: "PhieuThu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoCai_PhieuThu_PhieuThuId",
                table: "SoCai",
                column: "PhieuThuId",
                principalTable: "PhieuThu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThuCT_PhieuThu_PhieuThuId",
                table: "PhieuThuCT");

            migrationBuilder.DropForeignKey(
                name: "FK_SoCai_PhieuThu_PhieuThuId",
                table: "SoCai");

            migrationBuilder.DropIndex(
                name: "IX_SoCai_PhieuThuId",
                table: "SoCai");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThuCT_PhieuThu_PhieuThuId",
                table: "PhieuThuCT",
                column: "PhieuThuId",
                principalTable: "PhieuThu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
