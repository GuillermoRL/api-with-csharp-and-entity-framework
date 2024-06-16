using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(3010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(2790),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Nombre", "Weight" },
                values: new object[,]
                {
                    { new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5348"), null, "Pendient Activities", 20 },
                    { new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5349"), null, "Personal Activities", 50 }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "ActivityId", "CategoryId", "Description", "Priority", "Title" },
                values: new object[,]
                {
                    { new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5350"), new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5348"), null, 1, "Payment of Services" },
                    { new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5351"), new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5349"), null, 0, "Finishes Pendient Movies" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5350"));

            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5351"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5348"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5349"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(2790));
        }
    }
}
