using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmFunForum2.Migrations
{
    /// <inheritdoc />
    public partial class reportforumid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Report",
                newName: "ForumPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ForumPostId",
                table: "Report",
                newName: "PostId");
        }
    }
}
