using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharactersApi.Migrations
{
    /// <inheritdoc />
    public partial class correctingfranchiesIdspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FranchiesId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "FranchieId",
                table: "Movies",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FranchieId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "FranchiesId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
