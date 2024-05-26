using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkWell.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateLikes_Upvotes_Comments_AndSeedPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55fa9e9c-bf4b-4428-80a2-5894b8de59d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2823337-ddff-4724-a2dd-9fa81b440480"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Upvotes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upvotes", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_Upvotes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Upvotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8070), null, null, true, null, null, "Travel", null },
                    { new Guid("260318b8-98b5-4753-a020-68d191909f1f"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8104), null, null, true, null, null, "Sport", null }
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
                    { new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8109), null, null, true, null, null, "Basketball", new Guid("260318b8-98b5-4753-a020-68d191909f1f") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "ModifiedAt", "ModifiedBy", "PostImageUrl", "PublicId", "Text", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("601eac66-5e16-474e-bf70-ef4131ee3e3e"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 13, 51, 13, 51, DateTimeKind.Utc).AddTicks(8972), null, null, "This is the second post created by seeds.", null, null, "", "", "Hello from Admin.", "Second Post", 0 },
                    { new Guid("f6d689ee-a749-4fbd-ac8a-c2d83bbc3fd0"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-123345123411"), new DateTime(2024, 5, 26, 13, 51, 13, 51, DateTimeKind.Utc).AddTicks(8967), null, null, "This is the first post created by seeds.", null, null, "", "", "Hello from Admin.", "First Post", 0 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("365721f3-60f4-49b3-acda-a3891be36d3a"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8113), null, null, true, null, null, "NBA", new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba") },
                    { new Guid("80f5a218-4464-4406-a516-212d304b19af"), new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8116), null, null, true, null, null, "Euroleague", new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Upvotes_CommentId",
                table: "Upvotes",
                column: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Upvotes");

            migrationBuilder.DropTable(
                name: "Comments");

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
                keyValue: new Guid("00000000-0000-0000-0000-123345123411"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("260318b8-98b5-4753-a020-68d191909f1f"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "IsActive", "ModifiedAt", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("e01ae155-f9f4-488f-bea4-b9df93e6844f"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3008), null, null, true, null, null, "Travel", null },
                    { new Guid("e2823337-ddff-4724-a2dd-9fa81b440480"), new DateTime(2024, 5, 26, 8, 40, 58, 388, DateTimeKind.Utc).AddTicks(3012), null, null, true, null, null, "Sport", null }
                });

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
    }
}
