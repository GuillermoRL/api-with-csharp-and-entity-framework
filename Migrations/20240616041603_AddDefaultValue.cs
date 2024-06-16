using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7760),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7520),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5350"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7520), new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5351"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7520), new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7760) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(3010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(2790),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 6, 15, 21, 16, 3, 43, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5350"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(2790), new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ActivityId",
                keyValue: new Guid("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5351"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(2790), new DateTime(2024, 6, 15, 21, 14, 15, 258, DateTimeKind.Local).AddTicks(3010) });
        }
    }
}
