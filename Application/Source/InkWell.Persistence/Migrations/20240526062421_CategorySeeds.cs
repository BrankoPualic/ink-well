using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategorySeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 22, 18, 39, 48, 158, DateTimeKind.Utc).AddTicks(3069), "$2a$11$bQCAJ/UbesQ16500XKuBmuzOw6i9L/H2deTWOFeqPwlWjuqURb5nO" });
        }
    }
}
