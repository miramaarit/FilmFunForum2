using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmFunForum2.Migrations
{
    /// <inheritdoc />
    public partial class formpostcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostTitle",
                table: "Comment",
                newName: "ForumPostTitle");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comment",
                newName: "ForumPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ForumPostId",
                table: "Comment",
                column: "ForumPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ForumPost_ForumPostId",
                table: "Comment",
                column: "ForumPostId",
                principalTable: "ForumPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ForumPost_ForumPostId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ForumPostId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "ForumPostTitle",
                table: "Comment",
                newName: "PostTitle");

            migrationBuilder.RenameColumn(
                name: "ForumPostId",
                table: "Comment",
                newName: "PostId");
        }
    }
}
