using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(8383));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(4311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(3846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(820));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(2123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(3668));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(8522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(8383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(4311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(4373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(4220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(3792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 17, 57, 37, 610, DateTimeKind.Utc).AddTicks(3668),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(1761));
        }
    }
}
