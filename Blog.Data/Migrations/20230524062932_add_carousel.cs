using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class add_carousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(6343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 253, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(6159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 253, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(5289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 249, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(5110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 249, DateTimeKind.Utc).AddTicks(8289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(86),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(9160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(1303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(8986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 253, DateTimeKind.Utc).AddTicks(2238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(6343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 253, DateTimeKind.Utc).AddTicks(1643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 249, DateTimeKind.Utc).AddTicks(8854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 249, DateTimeKind.Utc).AddTicks(8289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(4446),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(3701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 714, DateTimeKind.Utc).AddTicks(86));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 6, 0, 51, 251, DateTimeKind.Utc).AddTicks(914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 6, 29, 32, 713, DateTimeKind.Utc).AddTicks(8986));
        }
    }
}
