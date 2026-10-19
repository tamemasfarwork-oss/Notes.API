using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removeuseridfortestin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_userid",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Users_userid",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Users_userid",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_userid",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Image_userid",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Categories_userid",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "userid",
                table: "Note",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userid",
                table: "Image",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userid",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Note_userid",
                table: "Note",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Image_userid",
                table: "Image",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_userid",
                table: "Categories",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_userid",
                table: "Categories",
                column: "userid",
                principalTable: "Users",
                principalColumn: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Users_userid",
                table: "Image",
                column: "userid",
                principalTable: "Users",
                principalColumn: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Users_userid",
                table: "Note",
                column: "userid",
                principalTable: "Users",
                principalColumn: "userid");
        }
    }
}
