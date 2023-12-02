using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_membershiptypes_MembershipTypeId",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "Genre_id",
                table: "movies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "movies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershipType_id",
                table: "customers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershipTypeId",
                table: "customers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_membershiptypes_MembershipTypeId",
                table: "customers",
                column: "MembershipTypeId",
                principalTable: "membershiptypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_membershiptypes_MembershipTypeId",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "Genre_id",
                table: "movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershipType_id",
                table: "customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershipTypeId",
                table: "customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_customers_membershiptypes_MembershipTypeId",
                table: "customers",
                column: "MembershipTypeId",
                principalTable: "membershiptypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
