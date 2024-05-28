using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedAuditColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("338a1dcd-c602-4f97-875e-006406083232"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937"));

            migrationBuilder.RenameColumn(
                name: "EntitiyTypeId",
                table: "Audits",
                newName: "EntityTypeId");

            migrationBuilder.RenameColumn(
                name: "EntitiyId",
                table: "Audits",
                newName: "EntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123345123411"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 20, 45, 24, 64, DateTimeKind.Utc).AddTicks(5526));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[] { new Guid("5614c3f1-e721-4489-9a59-e89765ae3acc"), new DateTime(2024, 5, 28, 20, 45, 24, 64, DateTimeKind.Utc).AddTicks(5558), null, null, true, null, null, "Sport", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "ModifiedAt", "ModifiedBy", "PostImageUrl", "PublicId", "Text", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1fdd5985-dc49-45cf-8f7b-df814435a7d6"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 28, 20, 45, 24, 69, DateTimeKind.Utc).AddTicks(4969), null, null, "This is the first post created by seeds.", null, null, "", "", "Hello from Admin.", "First Post", 0 },
                    { new Guid("ef8af730-d9c4-41a3-a0bd-c94cd7caaa50"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 28, 20, 45, 24, 69, DateTimeKind.Utc).AddTicks(4974), null, null, "This is the second post created by seeds.", null, null, "", "", "Hello from Admin.", "Second Post", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 28, 20, 45, 24, 175, DateTimeKind.Utc).AddTicks(9894), "$2a$11$U4TMSkgVG00HgaewjDbJOuXUbQV7M305lxKSxIp3Sd.Yp3gtkXFsq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 28, 20, 45, 24, 282, DateTimeKind.Utc).AddTicks(2102), "$2a$11$BAc4VgU0tx.k90w.sdGESeLsxk0PUeQNbyz.Ywlj.h3FeRYPJkKyC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 28, 20, 45, 24, 388, DateTimeKind.Utc).AddTicks(5298), "$2a$11$bszNE9vfyrHNU1bkGNxgleT5rlHChgCO4W5k6Bb/6uhvloDn4LX.S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 28, 20, 45, 24, 494, DateTimeKind.Utc).AddTicks(4554), "$2a$11$6jc7Lxk4hjAxTpjyZco3QewxKgJP4m4h5xfbllXyPN4lniy1RJvw2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("3847df5a-d1f5-4885-aa11-635e8be8a463"), new DateTime(2024, 5, 28, 20, 45, 24, 64, DateTimeKind.Utc).AddTicks(5575), null, null, true, null, null, "Basketball", new Guid("5614c3f1-e721-4489-9a59-e89765ae3acc") },
                    { new Guid("cd7d05ca-ab09-42a4-9a12-0a59166b58e7"), new DateTime(2024, 5, 28, 20, 45, 24, 64, DateTimeKind.Utc).AddTicks(5578), null, null, true, null, null, "Football", new Guid("5614c3f1-e721-4489-9a59-e89765ae3acc") },
                    { new Guid("6a0da462-402c-4556-a533-7720abb40bf8"), new DateTime(2024, 5, 28, 20, 45, 24, 64, DateTimeKind.Utc).AddTicks(5580), null, null, true, null, null, "NBA", new Guid("3847df5a-d1f5-4885-aa11-635e8be8a463") },
                    { new Guid("c43a355f-7c4a-4451-a600-b20b2ace4267"), new DateTime(2024, 5, 28, 20, 45, 24, 64, DateTimeKind.Utc).AddTicks(5582), null, null, true, null, null, "Euroleague", new Guid("3847df5a-d1f5-4885-aa11-635e8be8a463") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a0da462-402c-4556-a533-7720abb40bf8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c43a355f-7c4a-4451-a600-b20b2ace4267"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd7d05ca-ab09-42a4-9a12-0a59166b58e7"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1fdd5985-dc49-45cf-8f7b-df814435a7d6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ef8af730-d9c4-41a3-a0bd-c94cd7caaa50"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3847df5a-d1f5-4885-aa11-635e8be8a463"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5614c3f1-e721-4489-9a59-e89765ae3acc"));

            migrationBuilder.RenameColumn(
                name: "EntityTypeId",
                table: "Audits",
                newName: "EntitiyTypeId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Audits",
                newName: "EntitiyId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 15, 6, 32, 667, DateTimeKind.Utc).AddTicks(6274), "$2a$11$Zh3gn5NsUbKABcFoETh.uOPkfOi0Co.q81cqCHKbkiVQ4PLfDf1Y." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 15, 6, 32, 776, DateTimeKind.Utc).AddTicks(4984), "$2a$11$7NAGyYYZ8ECdCbBOquu9Ae6GqGSGty.BCTb4GpDfRv7dtHgshLVF6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 5, 26, 15, 6, 32, 884, DateTimeKind.Utc).AddTicks(9119), "$2a$11$8C2sRW6x8LU/KP7JLZkUSudGTf0Eu7U2Daf/Y/RhLckqV5/E..6R2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("2ff6f1c1-65f6-4b98-a6b6-a595409447a5"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7216), null, null, true, null, null, "Football", new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937") },
                    { new Guid("338a1dcd-c602-4f97-875e-006406083232"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7198), null, null, true, null, null, "Basketball", new Guid("dbbf5a8e-85fa-4c0a-af95-3526bde6b937") },
                    { new Guid("3c33c685-8268-4db6-86af-227d43ef461d"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7218), null, null, true, null, null, "NBA", new Guid("338a1dcd-c602-4f97-875e-006406083232") },
                    { new Guid("9dc06028-8243-4c40-a933-37a863ef357d"), new DateTime(2024, 5, 26, 15, 6, 32, 441, DateTimeKind.Utc).AddTicks(7220), null, null, true, null, null, "Euroleague", new Guid("338a1dcd-c602-4f97-875e-006406083232") }
                });
        }
    }
}
