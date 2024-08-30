using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPhieuNhap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TkChietKhau",
                table: "PhieuNhap",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TkChietKhau",
                table: "PhieuNhap",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
