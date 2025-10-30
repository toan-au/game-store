using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenamedGamesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "releaseDate",
                table: "Games",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "publisher",
                table: "Games",
                newName: "Publisher");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Games",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "developer",
                table: "Games",
                newName: "Developer");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Games",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Games",
                newName: "releaseDate");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "Games",
                newName: "publisher");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Games",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Developer",
                table: "Games",
                newName: "developer");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Games",
                newName: "name");
        }
    }
}
