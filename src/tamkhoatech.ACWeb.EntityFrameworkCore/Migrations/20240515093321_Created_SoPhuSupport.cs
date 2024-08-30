using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSoPhuSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoPhuSupport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNgay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDienGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGhiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGhiCo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoPhuSupport", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoPhuSupport");
        }
    }
}
