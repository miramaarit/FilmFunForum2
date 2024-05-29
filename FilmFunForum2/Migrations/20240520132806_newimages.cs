using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmFunForum2.Migrations
{
    /// <inheritdoc />
    public partial class newimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "UserImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "AspNetUsers",
                newName: "Image");
        }
    }
}
