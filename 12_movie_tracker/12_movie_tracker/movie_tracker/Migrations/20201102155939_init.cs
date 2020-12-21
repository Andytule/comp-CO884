using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace movie_tracker.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DateSeen = table.Column<DateTime>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 1, new DateTime(2019, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action", 9, "Avengers: Endgame" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 2, new DateTime(2018, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, "Incredibles 2" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 3, null, "Drama", null, "Dunkirk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
