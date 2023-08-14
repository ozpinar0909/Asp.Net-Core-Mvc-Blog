using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Dal.Migrations
{
    /// <inheritdoc />
    public partial class DalExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("48014a1d-85c7-4f82-99d6-4bec6913a277"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[] { new Guid("31f19200-5d31-4472-ab5e-50bb6a5dee9e"), new Guid("4b116317-854b-469b-9e02-3492a0c34583"), "What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2023, 8, 11, 14, 21, 16, 56, DateTimeKind.Local).AddTicks(8573), null, null, new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"), false, null, null, "Asp.Net Core Örnek Proje", 15 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b116317-854b-469b-9e02-3492a0c34583"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 11, 14, 21, 16, 56, DateTimeKind.Local).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5f2053aa-d024-4f6f-8ae4-f31f8f4c53fe"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 11, 14, 21, 16, 56, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 11, 14, 21, 16, 56, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30acd681-f1df-42d0-8238-9f2f7df4cc79"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 11, 14, 21, 16, 56, DateTimeKind.Local).AddTicks(9471));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("31f19200-5d31-4472-ab5e-50bb6a5dee9e"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[] { new Guid("48014a1d-85c7-4f82-99d6-4bec6913a277"), new Guid("4b116317-854b-469b-9e02-3492a0c34583"), "What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2023, 8, 9, 11, 36, 43, 271, DateTimeKind.Local).AddTicks(5525), null, null, new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"), false, null, null, "Asp.Net Core Örnek Proje", 15 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b116317-854b-469b-9e02-3492a0c34583"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 9, 11, 36, 43, 271, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5f2053aa-d024-4f6f-8ae4-f31f8f4c53fe"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 9, 11, 36, 43, 271, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("184baf77-de82-4da0-8d25-7cc577fb58c1"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 9, 11, 36, 43, 272, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30acd681-f1df-42d0-8238-9f2f7df4cc79"),
                column: "CreatedTime",
                value: new DateTime(2023, 8, 9, 11, 36, 43, 272, DateTimeKind.Local).AddTicks(1156));
        }
    }
}
