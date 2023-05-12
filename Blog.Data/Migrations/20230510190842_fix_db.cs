using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class fix_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostInTags_Categories_CategoryId",
                table: "PostInTags");

            migrationBuilder.DropIndex(
                name: "IX_PostInTags_CategoryId",
                table: "PostInTags");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "PostInTags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 426, DateTimeKind.Utc).AddTicks(3251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 426, DateTimeKind.Utc).AddTicks(3099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(5430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(4311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(5268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(9115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(8949),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(8415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(8296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(1761));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 426, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 9, DateTimeKind.Utc).AddTicks(6044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 426, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(4311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(5430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 7, DateTimeKind.Utc).AddTicks(3846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "PostInTags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(9115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(3314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(2123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 12, 1, 8, 8, DateTimeKind.Utc).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 10, 19, 8, 42, 425, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.CreateIndex(
                name: "IX_PostInTags_CategoryId",
                table: "PostInTags",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostInTags_Categories_CategoryId",
                table: "PostInTags",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
