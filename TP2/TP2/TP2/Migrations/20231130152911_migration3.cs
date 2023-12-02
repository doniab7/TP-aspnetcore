using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "movies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
