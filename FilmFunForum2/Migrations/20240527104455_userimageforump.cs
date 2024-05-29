using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmFunForum2.Migrations
{
    /// <inheritdoc />
    public partial class userimageforump : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "ForumPost",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "ForumPost");
        }
    }
}
