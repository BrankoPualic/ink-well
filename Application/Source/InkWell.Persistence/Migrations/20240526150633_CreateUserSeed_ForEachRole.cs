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
                value: new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7162));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7194), null, null, true, null, null, "Sport", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "ModifiedAt", "ModifiedBy", "PostImageUrl", "PublicId", "Text", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("433e9527-3219-4394-baf7-76f7fde67f6a"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 15, 6, 32, 447, DateTimeKind.Utc).AddTicks(839), null, null, "This is the second post created by seeds.", null, null, "", "", "Hello from Admin.", "Second Post", 0 },
                    { new Guid("8deef802-89fc-4128-9fa4-2da1b6c874e2"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 15, 6, 32, 447, DateTimeKind.Utc).AddTicks(834), null, null, "This is the first post created by seeds.", null, null, "", "", "Hello from Admin.", "First Post", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 15, 6, 32, 556, DateTimeKind.Utc).AddTicks(644), "$2a$11$qpQjCn3v29d1t53GOrEY9uhXIokdCKL8hk2FDdDLYGQd8F8Nj6MC6" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "ModifiedAt", "ModifiedBy", "Password", "ProfilePictureUrl", "PublicId", "Username" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2024, 5, 26, 15, 6, 32, 667, DateTimeKind.Utc).AddTicks(6274), new DateOnly(2002, 10, 10), null, null, "sysuseradmin@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$Zh3gn5NsUbKABcFoETh.uOPkfOi0Co.q81cqCHKbkiVQ4PLfDf1Y.", null, null, "system-useradmin1" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 5, 26, 15, 6, 32, 776, DateTimeKind.Utc).AddTicks(4984), new DateOnly(2002, 10, 10), null, null, "sysmoderator@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$7NAGyYYZ8ECdCbBOquu9Ae6GqGSGty.BCTb4GpDfRv7dtHgshLVF6", null, null, "system-moderator1" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2024, 5, 26, 15, 6, 32, 884, DateTimeKind.Utc).AddTicks(9119), new DateOnly(2002, 10, 10), null, null, "sysblogger@inkwell.test", "Branko", "Pualic-Radujko", null, null, "$2a$11$8C2sRW6x8LU/KP7JLZkUSudGTf0Eu7U2Daf/Y/RhLckqV5/E..6R2", null, null, "system-blogger1" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("2ff6f1c1-65f6-4b98-a6b6-a595409447a5"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7216), null, null, true, null, null, "Football", new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937") },
                    { new Guid("338a1dcd-c602-4f97-875e-006406083232"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7198), null, null, true, null, null, "Basketball", new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 4, new Guid("00000000-0000-0000-0000-000000000002"), true },
                    { 2, new Guid("00000000-0000-0000-0000-000000000003"), true },
                    { 5, new Guid("00000000-0000-0000-0000-000000000004"), true }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("3c33c685-8268-4db6-86af-227d43ef461d"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7218), null, null, true, null, null, "NBA", new Guid("338a1dcd-c602-4f97-875e-006406083232") },
                    { new Guid("9dc06028-8243-4c40-a933-37a863ef357d"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7220), null, null, true, null, null, "Euroleague", new Guid("338a1dcd-c602-4f97-875e-006406083232") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2ff6f1c1-65f6-4b98-a6b6-a595409447a5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c33c685-8268-4db6-86af-227d43ef461d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9dc06028-8243-4c40-a933-37a863ef357d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("433e9527-3219-4394-baf7-76f7fde67f6a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8deef802-89fc-4128-9fa4-2da1b6c874e2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("338a1dcd-c602-4f97-875e-006406083232"));

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
                keyValue: new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937"));

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
