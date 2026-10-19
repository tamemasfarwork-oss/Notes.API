using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class iniT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    passwordhash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_pinned = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoriesID);
                    table.ForeignKey(
                        name: "FK_Categories_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    notesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    should_review_it = table.Column<bool>(type: "bit", nullable: false),
                    is_pinned = table.Column<bool>(type: "bit", nullable: false),
                    CatigoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.notesID);
                    table.ForeignKey(
                        name: "FK_Note_Categories_CatigoryID",
                        column: x => x.CatigoryID,
                        principalTable: "Categories",
                        principalColumn: "categoriesID");
                    table.ForeignKey(
                        name: "FK_Note_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    imageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pathimage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.imageID);
                    table.ForeignKey(
                        name: "FK_Image_Note_noteID",
                        column: x => x.noteID,
                        principalTable: "Note",
                        principalColumn: "notesID");
                    table.ForeignKey(
                        name: "FK_Image_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_userid",
                table: "Categories",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Image_noteID",
                table: "Image",
                column: "noteID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_userid",
                table: "Image",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Note_CatigoryID",
                table: "Note",
                column: "CatigoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_userid",
                table: "Note",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
