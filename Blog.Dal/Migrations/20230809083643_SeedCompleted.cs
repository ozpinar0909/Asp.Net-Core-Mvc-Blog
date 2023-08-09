using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Dal.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "IsDeleted", "ModifiedBy", "ModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("4b116317-854b-469b-9e02-3492a0c34583"), "Admin Test", new DateTime(2023, 8, 9, 11, 36, 43, 271, DateTimeKind.Local).AddTicks(5878), null, null, false, null, null, "Asp.Net Core" },
                    { new Guid("5f2053aa-d024-4f6f-8ae4-f31f8f4c53fe"), "Admin Test", new DateTime(2023, 8, 9, 11, 36, 43, 271, DateTimeKind.Local).AddTicks(5884), null, null, false, null, null, "Visual Studio" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedTime" },
                values: new object[,]
                {
                    { new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"), "Admin Test", new DateTime(2023, 8, 9, 11, 36, 43, 272, DateTimeKind.Local).AddTicks(1143), null, null, "/images/testimage", "jpg", false, null, null },
                    { new Guid("30acd681-f1df-42d0-8238-9f2f7df4cc79"), "Admin Test", new DateTime(2023, 8, 9, 11, 36, 43, 272, DateTimeKind.Local).AddTicks(1156), null, null, "/images/vstest", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[] { new Guid("48014a1d-85c7-4f82-99d6-4bec6913a277"), new Guid("4b116317-854b-469b-9e02-3492a0c34583"), "What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2023, 8, 9, 11, 36, 43, 271, DateTimeKind.Local).AddTicks(5525), null, null, new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"), false, null, null, "Asp.Net Core Örnek Proje", 15 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("48014a1d-85c7-4f82-99d6-4bec6913a277"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5f2053aa-d024-4f6f-8ae4-f31f8f4c53fe"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30acd681-f1df-42d0-8238-9f2f7df4cc79"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b116317-854b-469b-9e02-3492a0c34583"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
