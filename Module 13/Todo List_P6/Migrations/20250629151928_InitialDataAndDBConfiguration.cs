using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo_List_P6.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataAndDBConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isCompleted",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TodoItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Date", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buy groceries" },
                    { 2, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish project report" }
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Date", "Title", "isCompleted" },
                values: new object[] { 3, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call mom", true });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Date", "Title" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go for a run" },
                    { 5, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read a book" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<bool>(
                name: "isCompleted",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
