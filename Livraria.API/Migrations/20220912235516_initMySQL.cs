using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.API.Migrations
{
    public partial class initMySQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    PublisherId = table.Column<int>(nullable: false),
                    Launch = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalRented = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Rental_Date = table.Column<DateTime>(nullable: false),
                    Forecast_Date = table.Column<DateTime>(nullable: false),
                    Return_Date = table.Column<DateTime>(nullable: false),
                    Returned_Book = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "São Paulo", "Makron" },
                    { 2, "Rio de Janeiro", "Campus" },
                    { 3, "São Paulo", "Pearson" },
                    { 4, "São Paulo", "Bookman" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Rua A,190", "Fortaleza", "joão@bol", "João Lopes" },
                    { 2, "Av. B, 1200", "Caucaia", "ms@gmail", "Marcelo Silva" },
                    { 3, "Rua C, 87", "São Paulo", "aguiar@ig", "Carlos Aguiar" },
                    { 4, "Rua D, 120", "Fortaleza", "rporto@bol", "Roberto Porto" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[,]
                {
                    { 2, "Deitel", new DateTime(2005, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Redes de Computadores", 1, 99, 1 },
                    { 5, "Cormen", new DateTime(2005, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algoritmos", 1, 99, 1 },
                    { 1, "Navathe", new DateTime(2002, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banco de Dados", 2, 98, 2 },
                    { 4, "Cormen", new DateTime(2006, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistemas Operacionais", 2, 99, 1 },
                    { 6, "Deitel", new DateTime(2006, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programando em C++", 2, 100, 0 },
                    { 3, "Deitel", new DateTime(2004, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java Prático", 3, 99, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_Date", "Returned_Book", "UserId" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 },
                    { 6, 2, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 3, 5, new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4 },
                    { 1, 1, new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 5, 1, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 7, 4, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4 },
                    { 4, 3, new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BookId",
                table: "Rentals",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
