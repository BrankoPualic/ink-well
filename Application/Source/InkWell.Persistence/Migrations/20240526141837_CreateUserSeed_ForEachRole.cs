using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserSeed_ForEachRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("365721f3-60f4-49b3-acda-a3891be36d3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47ed514d-81cc-4cb7-97ba-7efeb2db0421"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80f5a218-4464-4406-a516-212d304b19af"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("601eac66-5e16-474e-bf70-ef4131ee3e3e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f6d689ee-a749-4fbd-ac8a-c2d83bbc3fd0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("260318b8-98b5-4753-a020-68d191909f1f"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123345123411"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 26, 14, 18, 36, 665, DateTimeKind.Utc).AddTicks(2897));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { new Guid("3ccbd6ce-ea86-4ad9-a0e5-47ff912729f2"), new DateTime(2024, 5, 26, 14, 18, 36, 665, DateTimeKind.Utc).AddTicks(2930), null, null, true, null, null, "Sport", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "ModifiedAt", "ModifiedBy", "PostImageUrl", "PublicId", "Text", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0c53bbce-c39c-43b4-b666-324b518ef6c6"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 14, 18, 36, 670, DateTimeKind.Utc).AddTicks(4940), null, null, "This is the first post created by seeds.", null, null, "", "", "Hello from Admin.", "First Post", 0 },
                    { new Guid("d3f2119e-47e8-483e-9826-94d65ef3e7b4"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 14, 18, 36, 670, DateTimeKind.Utc).AddTicks(4945), null, null, "This is the second post created by seeds.", null, null, "", "", "Hello from Admin.", "Second Post", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 14, 18, 36, 780, DateTimeKind.Utc).AddTicks(2952), "$2a$11$ikIuG.UcIYfV0KeQdCBp0uy3GXfO8vVh/4uq8RkgL4bd4n.8.uWGG" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "ModifiedAt", "ModifiedBy", "Password", "ProfilePictureUrl", "PublicId", "Username" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 5, 26, 14, 18, 36, 891, DateTimeKind.Utc).AddTicks(1241), new DateOnly(2002, 10, 10), null, null, "sysuseradmin@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$x1UPD.IJmdDugC.YLpVCzOgKeGIpUE5wNcIMIRDxfsnKrsbYRoKIC", null, null, "system-useradmin1" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 5, 26, 14, 18, 36, 998, DateTimeKind.Utc).AddTicks(6344), new DateOnly(2002, 10, 10), null, null, "sysmoderator@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$/mJD2uummYp6wZ6MLNyaOOa/eJagk663yx/WQn.pO6rB3oV5JAt5e", null, null, "system-moderator1" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 5, 26, 14, 18, 37, 105, DateTimeKind.Utc).AddTicks(6318), new DateOnly(2002, 10, 10), null, null, "sysblogger@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$zTVJ4Z5Y4NWHXTUrzdt7X.mmieSmqJBas9ET3msP68Hio2C1DZYLC", null, null, "system-blogger1" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("3d937d91-8141-42ed-8ab0-356edef96582"), new DateTime(2024, 5, 26, 14, 18, 36, 665, DateTimeKind.Utc).AddTicks(2936), null, null, true, null, null, "Football", new Guid("3ccbd6ce-ea86-4ad9-a0e5-47ff912729f2") },
                    { new Guid("8803a648-b271-4417-bd28-82fe4b08a416"), new DateTime(2024, 5, 26, 14, 18, 36, 665, DateTimeKind.Utc).AddTicks(2934), null, null, true, null, null, "Basketball", new Guid("3ccbd6ce-ea86-4ad9-a0e5-47ff912729f2") },
                    { new Guid("2a317125-8b08-4a2e-ba7c-acf0def4176d"), new DateTime(2024, 5, 26, 14, 18, 36, 665, DateTimeKind.Utc).AddTicks(2940), null, null, true, null, null, "Euroleague", new Guid("8803a648-b271-4417-bd28-82fe4b08a416") },
                    { new Guid("c82cd82f-f667-448c-8832-55c8d02d0c14"), new DateTime(2024, 5, 26, 14, 18, 36, 665, DateTimeKind.Utc).AddTicks(2938), null, null, true, null, null, "NBA", new Guid("8803a648-b271-4417-bd28-82fe4b08a416") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2a317125-8b08-4a2e-ba7c-acf0def4176d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3d937d91-8141-42ed-8ab0-356edef96582"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c82cd82f-f667-448c-8832-55c8d02d0c14"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0c53bbce-c39c-43b4-b666-324b518ef6c6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d3f2119e-47e8-483e-9826-94d65ef3e7b4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8803a648-b271-4417-bd28-82fe4b08a416"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3ccbd6ce-ea86-4ad9-a0e5-47ff912729f2"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123345123411"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { new Guid("260318b8-98b5-4753-a020-68d191909f1f"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8104), null, null, true, null, null, "Sport", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "ModifiedAt", "ModifiedBy", "PostImageUrl", "PublicId", "Text", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("601eac66-5e16-474e-bf70-ef4131ee3e3e"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 13, 51, 13, 51, DateTimeKind.Utc).AddTicks(8972), null, null, "This is the second post created by seeds.", null, null, "", "", "Hello from Admin.", "Second Post", 0 },
                    { new Guid("f6d689ee-a749-4fbd-ac8a-c2d83bbc3fd0"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 13, 51, 13, 51, DateTimeKind.Utc).AddTicks(8967), null, null, "This is the first post created by seeds.", null, null, "", "", "Hello from Admin.", "First Post", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 13, 51, 13, 159, DateTimeKind.Utc).AddTicks(1022), "$2a$11$zDMWEILObmS8v9VfDrC2i.M.bBVxDHCe686wPD/1KBucJFUUIhDRy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("47ed514d-81cc-4cb7-97ba-7efeb2db0421"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8111), null, null, true, null, null, "Football", new Guid("260318b8-98b5-4753-a020-68d191909f1f") },
                    { new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8109), null, null, true, null, null, "Basketball", new Guid("260318b8-98b5-4753-a020-68d191909f1f") },
                    { new Guid("365721f3-60f4-49b3-acda-a3891be36d3a"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8113), null, null, true, null, null, "NBA", new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba") },
                    { new Guid("80f5a218-4464-4406-a516-212d304b19af"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8116), null, null, true, null, null, "Euroleague", new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba") }
                });
        }
    }
}
