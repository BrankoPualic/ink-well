using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndEntityType_luModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4cc94ccb-e925-44f6-927a-03ecd3a39377"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("92f2e6fa-dfc2-43d2-9a98-78305422a3ef"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9be29b9d-9df6-488c-a0d8-9070dac2b8ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("da075f5f-13dd-4c5d-9200-8175d93d38fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("575083e3-e74e-4e71-816a-224f1f885ef5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("27739aaa-3897-44ee-a999-df85cf321592"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("e01ae155-f9f4-488f-bea4-b9df93e6844f"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3008), null, null, true, null, null, "Travel", null },
                    { new Guid("e2823337-ddff-4724-a2dd-9fa81b440480"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3012), null, null, true, null, null, "Sport", null }
                });

            migrationBuilder.InsertData(
                table: "EntityTypes_lu",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Category" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 8, 40, 58, 777, DateTimeKind.Utc).AddTicks(1922), "$2a$11$TEvdfEUdSCHR2XN6F.KvVu2IiV5MQTk6d0CeAGMsKx202yv0vgMfi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("482165b0-72ef-4d39-826a-c0b2971c8753"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3032), null, null, true, null, null, "Football", new Guid("e2823337-ddff-4724-a2dd-9fa81b440480") },
                    { new Guid("55fa9e9c-bf4b-4428-80a2-5894b8de59d2"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3017), null, null, true, null, null, "Basketball", new Guid("e2823337-ddff-4724-a2dd-9fa81b440480") },
                    { new Guid("9436f5fc-f14a-4c88-a407-2f41fb61b4eb"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3036), null, null, true, null, null, "Euroleague", new Guid("55fa9e9c-bf4b-4428-80a2-5894b8de59d2") },
                    { new Guid("9a0a24d7-a03f-44ad-9eb1-83013210dc9f"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3034), null, null, true, null, null, "NBA", new Guid("55fa9e9c-bf4b-4428-80a2-5894b8de59d2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("482165b0-72ef-4d39-826a-c0b2971c8753"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9436f5fc-f14a-4c88-a407-2f41fb61b4eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a0a24d7-a03f-44ad-9eb1-83013210dc9f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e01ae155-f9f4-488f-bea4-b9df93e6844f"));

            migrationBuilder.DeleteData(
                table: "EntityTypes_lu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55fa9e9c-bf4b-4428-80a2-5894b8de59d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2823337-ddff-4724-a2dd-9fa81b440480"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("27739aaa-3897-44ee-a999-df85cf321592"), new DateTime(2024, 5, 26, 6, 24, 21, 526, DateTimeKind.Utc).AddTicks(1132), null, null, true, null, null, "Sport", null },
                    { new Guid("92f2e6fa-dfc2-43d2-9a98-78305422a3ef"), new DateTime(2024, 5, 26, 6, 24, 21, 526, DateTimeKind.Utc).AddTicks(1128), null, null, true, null, null, "Travel", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 6, 24, 21, 638, DateTimeKind.Utc).AddTicks(764), "$2a$11$De6ZfGZVVVWp9DuxZ9M7ue.QMkkqJZ.6u6iB4ZFKmN/3nQ3l20aYa" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("575083e3-e74e-4e71-816a-224f1f885ef5"), new DateTime(2024, 5, 26, 6, 24, 21, 526, DateTimeKind.Utc).AddTicks(1145), null, null, true, null, null, "Basketball", new Guid("27739aaa-3897-44ee-a999-df85cf321592") },
                    { new Guid("da075f5f-13dd-4c5d-9200-8175d93d38fd"), new DateTime(2024, 5, 26, 6, 24, 21, 526, DateTimeKind.Utc).AddTicks(1147), null, null, true, null, null, "Football", new Guid("27739aaa-3897-44ee-a999-df85cf321592") },
                    { new Guid("4cc94ccb-e925-44f6-927a-03ecd3a39377"), new DateTime(2024, 5, 26, 6, 24, 21, 526, DateTimeKind.Utc).AddTicks(1167), null, null, true, null, null, "NBA", new Guid("575083e3-e74e-4e71-816a-224f1f885ef5") },
                    { new Guid("9be29b9d-9df6-488c-a0d8-9070dac2b8ac"), new DateTime(2024, 5, 26, 6, 24, 21, 526, DateTimeKind.Utc).AddTicks(1169), null, null, true, null, null, "Euroleague", new Guid("575083e3-e74e-4e71-816a-224f1f885ef5") }
                });
        }
    }
}
