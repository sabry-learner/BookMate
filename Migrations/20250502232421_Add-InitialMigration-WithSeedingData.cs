using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookMate.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialMigrationWithSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(256)", maxLength: 256, nullable: false),
                    Author = table.Column<string>(type: "NVARCHAR(256)", maxLength: 256, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "INT", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(256)", maxLength: 256, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    GenreStats_FavoriteGenre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    GenreStats_TotalPagesRead = table.Column<int>(type: "int", nullable: true),
                    GenreStats_AverageRating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SuggestionText = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    SuggestedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSuggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSuggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    Mood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Rating = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingSessions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadingSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DifficultyLevel", "Genre", "Pages", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "Hard", "Science", 464, "Clean Code" },
                    { 2, "Paulo Coelho", "Easy", "Fiction", 208, "The Alchemist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "JoinDate", "Name" },
                values: new object[,]
                {
                    { 1, "ahmed@example.com", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed Sabry" },
                    { 2, "mona@example.com", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mona Ali" }
                });

            migrationBuilder.InsertData(
                table: "BookSuggestions",
                columns: new[] { "Id", "SuggestedAt", "SuggestionText", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "You must read 'Atomic Habits'.", 1 },
                    { 2, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Try reading '1984' by George Orwell.", 2 }
                });

            migrationBuilder.InsertData(
                table: "ReadingSessions",
                columns: new[] { "Id", "BookId", "EndTime", "Mood", "Notes", "Rating", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 11, 0, 0, 0), "Relaxed", "Great focus session.", 5, new TimeSpan(0, 10, 0, 0, 0), 1 },
                    { 2, 2, new TimeSpan(0, 15, 0, 0, 0), "Tired", "Lost concentration.", 2, new TimeSpan(0, 14, 30, 0, 0), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSuggestions_UserId",
                table: "BookSuggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingSessions_BookId",
                table: "ReadingSessions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingSessions_UserId",
                table: "ReadingSessions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSuggestions");

            migrationBuilder.DropTable(
                name: "ReadingSessions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
