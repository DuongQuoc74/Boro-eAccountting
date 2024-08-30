using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tamkhoatech.ACWeb.Migrations
{
    /// <inheritdoc />
    public partial class _20240420UpdatePhieuKeToanCt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "PhieuKeToanCt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "PhieuKeToanCt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "PhieuKeToanCt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "PhieuKeToanCt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PhieuKeToanCt",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "PhieuKeToanCt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "PhieuKeToanCt",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "PhieuKeToanCt");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PhieuKeToanCt");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "PhieuKeToanCt");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "PhieuKeToanCt");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PhieuKeToanCt");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "PhieuKeToanCt");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "PhieuKeToanCt");
        }
    }
}
