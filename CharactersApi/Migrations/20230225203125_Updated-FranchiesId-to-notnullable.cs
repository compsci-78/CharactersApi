﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharactersApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFranchiesIdtonotnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FranchiesId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FranchiesId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
