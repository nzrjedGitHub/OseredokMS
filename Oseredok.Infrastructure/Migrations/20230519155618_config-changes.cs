using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oseredok.Infrastructure.Migrations
{
    public partial class configchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "GymId", "PercentagePerSession", "UserId" },
                values: new object[] { new Guid("d4e61167-950b-4d87-b568-9ce087f3c744"), 1, 0m, new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4119255-950b-4d87-b568-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4119255-950b-4d87-f432-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4119255-950b-4d87-f432-9ce087f39925"),
                column: "RegDate",
                value: new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e65555-950b-4d87-b568-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                column: "RegDate",
                value: new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e96455-950b-4d87-b568-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "MiddleName", "Password", "PhoneNumber", "RegDate", "RoleId" },
                values: new object[] { new Guid("d4e69655-950b-4d87-b555-9ce087f3c79f"), "default.coach@gmail.com", "Default", "Coach", "lorem", "loremIpsum123", "0509781078", new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9306), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: new Guid("d4e61167-950b-4d87-b568-9ce087f3c744"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e69655-950b-4d87-b555-9ce087f3c79f"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4119255-950b-4d87-b568-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4119255-950b-4d87-f432-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4119255-950b-4d87-f432-9ce087f39925"),
                column: "RegDate",
                value: new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e65555-950b-4d87-b568-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                column: "RegDate",
                value: new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4e96455-950b-4d87-b568-9ce087f34698"),
                column: "RegDate",
                value: new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1496));
        }
    }
}
