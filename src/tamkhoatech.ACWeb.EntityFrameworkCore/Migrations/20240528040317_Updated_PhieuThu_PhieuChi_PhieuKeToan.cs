using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPhieuThuPhieuChiPhieuKeToan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DienGiai",
                table: "PhieuThu",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DienGiai",
                table: "PhieuKeToan",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DienGiai",
                table: "PhieuChi",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DienGiai",
                table: "PhieuThu");

            migrationBuilder.DropColumn(
                name: "DienGiai",
                table: "PhieuKeToan");

            migrationBuilder.DropColumn(
                name: "DienGiai",
                table: "PhieuChi");
        }
    }
}
