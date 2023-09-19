using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oseredok.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentPerSession = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastPaymentSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCapacity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    PercentagePerSession = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coaches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientPayments_ClientPaymentId",
                        column: x => x.ClientPaymentId,
                        principalTable: "ClientPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false),
                    SessionStatusId = table.Column<int>(type: "int", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_SessionStatuses_SessionStatusId",
                        column: x => x.SessionStatusId,
                        principalTable: "SessionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientPayments",
                columns: new[] { "Id", "Balance", "LastPaymentDate", "LastPaymentSum", "PaymentPerSession" },
                values: new object[] { new Guid("d4e65555-950b-4d87-b111-9ce087f3c79f"), 100m, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, 50m });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "ClientCapacity" },
                values: new object[] { 1, "someAddress", 5 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "coach" },
                    { 3, "client" },
                    { 4, "noRole" }
                });

            migrationBuilder.InsertData(
                table: "SessionStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "awaiting" },
                    { 5, "accepted" },
                    { 6, "inProcess" },
                    { 7, "completed" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "MiddleName", "Password", "PhoneNumber", "RegDate", "RoleId" },
                values: new object[,]
                {
                    { new Guid("d4119255-950b-4d87-b568-9ce087f34698"), "max.smirnov@gmail.com", "Max", "Smirnov", "lorem", "loremIpsum123", "0509781078", new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1499), 2 },
                    { new Guid("d4119255-950b-4d87-f432-9ce087f34698"), "masha.lorem@gmail.com", "Masha", "lorem", "lorem", "loremIpsum123", "0509781078", new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1501), 1 },
                    { new Guid("d4119255-950b-4d87-f432-9ce087f39925"), "pasha.mamchur@gmail.com", "Pasha", "Mamchur", "Olexandrovych", "loremIpsum123", "0509781078", new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1504), 2 },
                    { new Guid("d4e65555-950b-4d87-b568-9ce087f34698"), "nazar.sachuk@gmail2.com", "Nazar2", "Sachuk2", "Igorovych2", "loremIpsum123", "0509781078", new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1493), 3 },
                    { new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f"), "nazar.sachuk@gmail.com", "Nazar", "Sachuk", "Igorovych", "loremIpsum123", "0509781078", new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1458), 3 },
                    { new Guid("d4e96455-950b-4d87-b568-9ce087f34698"), "nazar.sachuk@gmail3.com", "Nazar3", "Sachuk3", "Igorovych3", "loremIpsum123", "0509781078", new DateTime(2023, 5, 13, 12, 35, 28, 467, DateTimeKind.Local).AddTicks(1496), 3 }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "GymId", "Salary", "UserId" },
                values: new object[] { new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f"), 1, 6000m, new Guid("d4119255-950b-4d87-f432-9ce087f34698") });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "GymId", "PercentagePerSession", "UserId" },
                values: new object[] { new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"), 1, 15m, new Guid("d4119255-950b-4d87-b568-9ce087f34698") });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientPaymentId", "CoachId", "GymId", "UserId" },
                values: new object[] { new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"), new Guid("d4e65555-950b-4d87-b111-9ce087f3c79f"), new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"), 1, new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f") });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClientId", "CoachId", "GymId", "SessionDate", "SessionStatusId" },
                values: new object[] { new Guid("d4f62345-950b-4d27-b568-9ce087f3c79f"), new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"), new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"), 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClientId", "CoachId", "GymId", "SessionDate", "SessionStatusId" },
                values: new object[] { new Guid("d4f65555-950b-4d27-b231-9ce087f3c79f"), new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"), new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"), 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClientId", "CoachId", "GymId", "SessionDate", "SessionStatusId" },
                values: new object[] { new Guid("d4f65555-950b-4d27-b568-9ce087f3c79f"), new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"), new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"), 1, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_GymId",
                table: "Admins",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientPaymentId",
                table: "Clients",
                column: "ClientPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CoachId",
                table: "Clients",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GymId",
                table: "Clients",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_GymId",
                table: "Coaches",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_UserId",
                table: "Coaches",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClientId",
                table: "Sessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CoachId",
                table: "Sessions",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_GymId",
                table: "Sessions",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SessionStatusId",
                table: "Sessions",
                column: "SessionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SessionStatuses");

            migrationBuilder.DropTable(
                name: "ClientPayments");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
