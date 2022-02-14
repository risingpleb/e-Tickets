using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Tickets.Migrations
{
    public partial class UpdateColumnMovideIdToMovieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MovideId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "MovideId",
                table: "OrderItems",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_MovideId",
                table: "OrderItems",
                newName: "IX_OrderItems_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "OrderItems",
                newName: "MovideId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                newName: "IX_OrderItems_MovideId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MovideId",
                table: "OrderItems",
                column: "MovideId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
