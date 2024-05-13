using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles_lu");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name",
                table: "Roles_lu",
                newName: "IX_Roles_lu_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles_lu",
                table: "Roles_lu",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActionTypes_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntitiyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntitiyTypeId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    DetailsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_Users_ExecutedBy",
                        column: x => x.ExecutedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes_lu", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActionTypes_lu",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Insert" },
                    { 2, "Update" },
                    { 3, "Delete" }
                });

            migrationBuilder.InsertData(
                table: "EntityTypes_lu",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Post" },
                    { 3, "Comment" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 13, 6, 14, 10, 204, DateTimeKind.Utc).AddTicks(8313), "$2a$11$rsmwUtWb1/BEgYidJldk3u9Qzzq5Iy3uxh0I2wMq7IXycj76eAbBe" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_lu_Name",
                table: "ActionTypes_lu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audits_ExecutedBy",
                table: "Audits",
                column: "ExecutedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EntityTypes_lu_Name",
                table: "EntityTypes_lu",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_lu_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_lu_RoleId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "ActionTypes_lu");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "EntityTypes_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles_lu",
                table: "Roles_lu");

            migrationBuilder.RenameTable(
                name: "Roles_lu",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_lu_Name",
                table: "Roles",
                newName: "IX_Roles_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 12, 18, 2, 20, 189, DateTimeKind.Utc).AddTicks(4686), "$2a$11$55Lx60HqEXt2D7pJMTt8oeeCcDFz9Gtuits0gBhnkJuh0zoCSKT5O" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
