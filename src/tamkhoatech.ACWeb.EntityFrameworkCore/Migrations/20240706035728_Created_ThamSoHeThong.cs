using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class CreatedThamSoHeThong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThamSoHeThong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThamSoHeThongUd = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DienGiai = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    GiaTri = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    GiaTriDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Kieu = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NhomThamSo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamSoHeThong", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThamSoHeThong");
        }
    }
}
