using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SigninLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SigninLogs",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SigninLogs", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_SigninLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 12, 18, 2, 20, 189, DateTimeKind.Utc).AddTicks(4686), "$2a$11$55Lx60HqEXt2D7pJMTt8oeeCcDFz9Gtuits0gBhnkJuh0zoCSKT5O" });

            migrationBuilder.CreateIndex(
                name: "IX_SigninLogs_UserId",
                table: "SigninLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SigninLogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 11, 18, 22, 2, 412, DateTimeKind.Utc).AddTicks(9241), "$2a$11$CBOXd06R8z4dS4dVbe7SM.mrmFKtD4EEK/RcEKrTp3dGa84qD0Mqm" });
        }
    }
}
