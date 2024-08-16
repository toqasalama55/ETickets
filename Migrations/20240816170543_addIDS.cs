using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class addIDS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoriesId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemasId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "CinemasId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoriesId",
                table: "Movies",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemasId",
                table: "Movies",
                column: "CinemasId",
                principalTable: "Cinemas",
                principalColumn: "CinemasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoriesId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemasId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "CinemasId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoriesId",
                table: "Movies",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemasId",
                table: "Movies",
                column: "CinemasId",
                principalTable: "Cinemas",
                principalColumn: "CinemasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
