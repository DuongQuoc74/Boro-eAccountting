using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class DeletedColumnStt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stt",
                table: "PhieuNhapCT");

            migrationBuilder.DropColumn(
                name: "Stt",
                table: "PhanBoThueNk");

            migrationBuilder.DropColumn(
                name: "Stt",
                table: "PhanBoChiPhi");

            migrationBuilder.DropColumn(
                name: "Stt",
                table: "PhanBoChietKhauThuongMai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "PhieuNhapCT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "PhanBoThueNk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "PhanBoChiPhi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "PhanBoChietKhauThuongMai",
                type: "int",
                nullable: true);
        }
    }
}
