using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ErrorLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    ErrorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.ErrorId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 11, 18, 22, 2, 412, DateTimeKind.Utc).AddTicks(9241), "$2a$11$CBOXd06R8z4dS4dVbe7SM.mrmFKtD4EEK/RcEKrTp3dGa84qD0Mqm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 9, 16, 15, 25, 709, DateTimeKind.Utc).AddTicks(5013), "$2a$11$EwUGg4SG27sxc8SP78N6Be/UNFV//GnfcimiWjioo2J9vq5.z9wqa" });
        }
    }
}
