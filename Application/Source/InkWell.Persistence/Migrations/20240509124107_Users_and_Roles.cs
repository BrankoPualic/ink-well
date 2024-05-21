using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
	/// <inheritdoc />
	public partial class Users_and_Roles : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Roles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
					Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					FullName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, computedColumnSql: "[FirstName] + ' ' + [LastName]"),
					ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
					CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
					ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
					DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "UserRoles",
				columns: table => new
				{
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					RoleId = table.Column<int>(type: "int", nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_UserRoles_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_UserRoles_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.InsertData(
				table: "Roles",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Member" },
					{ 2, "Moderator" },
					{ 3, "Administrator" },
					{ 4, "UserAdmin" },
					{ 5, "Blogger" }
				});

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "CreatedAt", "DateOfBirth", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "ModifiedAt", "ModifiedBy", "Password", "ProfilePictureUrl", "Username" },
				values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 5, 9, 12, 41, 7, 43, DateTimeKind.Utc).AddTicks(2639), new DateOnly(2002, 10, 10), null, null, "sysadmin@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$VuXJEJUd9b2qsT4KOL5VdOSHSUAuPucpJI/1mFX1QucoT3eEBVcJi", null, "system-admin1" });

			migrationBuilder.InsertData(
				table: "UserRoles",
				columns: new[] { "RoleId", "UserId", "IsActive" },
				values: new object[] { 3, new Guid("00000000-0000-0000-0000-000000000001"), true });

			migrationBuilder.CreateIndex(
				name: "IX_Roles_Name",
				table: "Roles",
				column: "Name",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_UserRoles_RoleId",
				table: "UserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "IX_Users_Email",
				table: "Users",
				column: "Email",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Users_FullName_Username_Email",
				table: "Users",
				columns: new[] { "FullName", "Username", "Email" })
				.Annotation("SqlServer:Include", new[] { "DateOfBirth" });

			migrationBuilder.CreateIndex(
				name: "IX_Users_Username",
				table: "Users",
				column: "Username",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "UserRoles");

			migrationBuilder.DropTable(
				name: "Roles");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}