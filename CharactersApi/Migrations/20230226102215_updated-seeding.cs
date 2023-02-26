using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharactersApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Franchies_B");

            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Franchies_C");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Franchies_A");

            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Franchies_A");
        }
    }
}
