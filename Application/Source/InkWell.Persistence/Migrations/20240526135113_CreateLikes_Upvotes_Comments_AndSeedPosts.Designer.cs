﻿// <auto-generated />
using System;
using InkWell.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InkWell.Persistence.Migrations
{
    [DbContext(typeof(InkWellContext))]
    [Migration("20240526135113_CreateLikes_Upvotes_Comments_AndSeedPosts")]
    partial class CreateLikes_Upvotes_Comments_AndSeedPosts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Audit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DetailsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EntitiyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EntitiyTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("ExecutedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExecutedBy");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-123345123411"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8070),
                            IsActive = true,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = new Guid("260318b8-98b5-4753-a020-68d191909f1f"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8104),
                            IsActive = true,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8109),
                            IsActive = true,
                            Name = "Basketball",
                            ParentId = new Guid("260318b8-98b5-4753-a020-68d191909f1f")
                        },
                        new
                        {
                            Id = new Guid("47ed514d-81cc-4cb7-97ba-7efeb2db0421"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8111),
                            IsActive = true,
                            Name = "Football",
                            ParentId = new Guid("260318b8-98b5-4753-a020-68d191909f1f")
                        },
                        new
                        {
                            Id = new Guid("365721f3-60f4-49b3-acda-a3891be36d3a"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8113),
                            IsActive = true,
                            Name = "NBA",
                            ParentId = new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba")
                        },
                        new
                        {
                            Id = new Guid("80f5a218-4464-4406-a516-212d304b19af"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 46, DateTimeKind.Utc).AddTicks(8116),
                            IsActive = true,
                            Name = "Euroleague",
                            ParentId = new Guid("a934770e-f7d6-4ea2-b2c6-446e3868ffba")
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.ErrorLog", b =>
                {
                    b.Property<Guid>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrorId");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Follow", b =>
                {
                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FollowedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("FollowerId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Like", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PostImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f6d689ee-a749-4fbd-ac8a-c2d83bbc3fd0"),
                            AuthorId = new Guid("00000000-0000-0000-0000-000000000001"),
                            CategoryId = new Guid("00000000-0000-0000-0000-123345123411"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 51, DateTimeKind.Utc).AddTicks(8967),
                            Description = "This is the first post created by seeds.",
                            IsActive = false,
                            PostImageUrl = "",
                            PublicId = "",
                            Text = "Hello from Admin.",
                            Title = "First Post",
                            ViewCount = 0
                        },
                        new
                        {
                            Id = new Guid("601eac66-5e16-474e-bf70-ef4131ee3e3e"),
                            AuthorId = new Guid("00000000-0000-0000-0000-000000000001"),
                            CategoryId = new Guid("00000000-0000-0000-0000-123345123411"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 51, DateTimeKind.Utc).AddTicks(8972),
                            Description = "This is the second post created by seeds.",
                            IsActive = false,
                            PostImageUrl = "",
                            PublicId = "",
                            Text = "Hello from Admin.",
                            Title = "Second Post",
                            ViewCount = 0
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.SigninLog", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("SigninLogs");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Upvote", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("Upvotes");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("FullName", "Username", "Email");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("FullName", "Username", "Email"), new[] { "DateOfBirth" });

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedAt = new DateTime(2024, 5, 26, 13, 51, 13, 159, DateTimeKind.Utc).AddTicks(1022),
                            DateOfBirth = new DateOnly(2002, 10, 10),
                            Email = "sysadmin@inkwell.test",
                            FirstName = "Branko",
                            FullName = "",
                            IsActive = false,
                            LastName = "Pualic-Radujko",
                            Password = "$2a$11$zDMWEILObmS8v9VfDrC2i.M.bBVxDHCe686wPD/1KBucJFUUIhDRy",
                            Username = "system-admin1"
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            RoleId = 3,
                            IsActive = true
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application_lu.ActionType_lu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ActionTypes_lu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Insert"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Update"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application_lu.EntityType_lu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("EntityTypes_lu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Post"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comment"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Category"
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application_lu.Role_lu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles_lu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Member"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Moderator"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 4,
                            Name = "UserAdmin"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Blogger"
                        });
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Audit", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.User", "User")
                        .WithMany("Audits")
                        .HasForeignKey("ExecutedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Category", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Comment", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.Comment", "Parent")
                        .WithMany("Replies")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InkWell.Domain.Entities.Application.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkWell.Domain.Entities.Application.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Follow", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.User", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkWell.Domain.Entities.Application.User", "Following")
                        .WithMany("Followers")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Like", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkWell.Domain.Entities.Application.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Post", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkWell.Domain.Entities.Application.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.SigninLog", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.User", "User")
                        .WithMany("Signins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Upvote", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application.Comment", "Comment")
                        .WithMany("Upvotes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkWell.Domain.Entities.Application.User", "User")
                        .WithMany("Upvotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.UserRole", b =>
                {
                    b.HasOne("InkWell.Domain.Entities.Application_lu.Role_lu", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkWell.Domain.Entities.Application.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Comment", b =>
                {
                    b.Navigation("Replies");

                    b.Navigation("Upvotes");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application.User", b =>
                {
                    b.Navigation("Audits");

                    b.Navigation("Comments");

                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("Signins");

                    b.Navigation("Upvotes");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("InkWell.Domain.Entities.Application_lu.Role_lu", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
