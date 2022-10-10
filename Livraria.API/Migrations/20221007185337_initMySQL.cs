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
                    TotalRented = table.Column<int>(nullable: false),
                    MaxRented = table.Column<int>(nullable: false)
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
                    Returned_Book = table.Column<bool>(nullable: true),
                    Status_Rental = table.Column<string>(nullable: true)
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
                    { 2, "São Paulo", "TecInova" },
                    { 3, "Rio de janeiro", "Atena" },
                    { 4, "Fortaleza", "AFE" },
                    { 5, "Fortaleza", "Novatec" },
                    { 6, "Belo Horizonte", "Juruá" },
                    { 7, "Estocolmo", "Moderna" },
                    { 8, "Riomaggiore", "Feevale" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[,]
                {
                    { 41, "Rua N,645", "Fortaleza", "caiques@gmail.com", "Caique Silva" },
                    { 37, "Rua Z,543", "Torino", "joh.const@gmail.com", "Johanna Constantine" },
                    { 33, "Rua E,343", "Fortaleza", "henri3@gmail.com", "Henrique Lopes" },
                    { 18, "Rua Q,133", "Nova Iorque", "ava.max@gmail.com", "Ava Max" },
                    { 2, "Rua J,324", "São Paulo", "ana5@gmail.com", "Ana Maria" },
                    { 13, "Rua L,985", "Fortaleza", "luzia123@gmail.com", "Luzia Carvalho" },
                    { 3, "Rua B,353", "Rio de Janeiro", "caioh@gmail.com", "Caio Henrique" },
                    { 52, "Rua S,709", "Fortaleza", "leona3@gmail.com", "Leona Luz" },
                    { 1, "Rua A,190", "Fortaleza", "artur@gmail.com", "Artur Gonçalves" },
                    { 16, "Rua W,122", "Los Angeles", "ronald98@gmail.com", "Ronald Santos" },
                    { 54, "Rua R, 837", "Paris", "amy23@gmail.com", "Amy Pond" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "MaxRented", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[,]
                {
                    { 4, "Eduardo Candido", new DateTime(2012, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Javascript e seus conceitos", 1, 49, 0 },
                    { 6, "George Nick", new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "A arte de programar", 1, 32, 0 },
                    { 70, "Lana Beck", new DateTime(2021, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, "Computação Evolucionária", 1, 23, 1 },
                    { 7, "Paul Marks", new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Algoritmos", 2, 68, 0 },
                    { 48, "Raquel Rose", new DateTime(2008, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "TDD para Games", 2, 87, 0 },
                    { 1, "Cecil Martin", new DateTime(2012, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, "Clean Code", 3, 120, 7 },
                    { 24, "Caio Lopes", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "SOA, web services e além", 3, 33, 0 },
                    { 58, "Charllote Will", new DateTime(2012, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Elixir", 3, 95, 1 },
                    { 3, "Alex Max", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Banco de dados", 4, 87, 1 },
                    { 19, "Robert Cecil", new DateTime(2012, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, "Aprenda a programar com Python", 5, 43, 1 },
                    { 45, "Navathe", new DateTime(2011, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, "ASP.NET Core MVC", 5, 23, 0 },
                    { 20, "Andy Hunt e Dave Thomas", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, "Lógica de programação com Portugol", 7, 49, 1 },
                    { 46, "Navathe", new DateTime(2005, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Orientação a Objetos em C#", 7, 43, 2 },
                    { 21, "Ana Lima", new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Coleção Frameworks Java", 8, 65, 0 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_Date", "Returned_Book", "Status_Rental", "UserId" },
                values: new object[,]
                {
                    { 58, 70, new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 37 },
                    { 12, 1, new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 1 },
                    { 14, 1, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 2 },
                    { 59, 1, new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 52 },
                    { 80, 1, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 3 },
                    { 81, 1, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 3 },
                    { 89, 1, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 54 },
                    { 91, 1, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 16 },
                    { 87, 58, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 52 },
                    { 15, 3, new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 1 },
                    { 16, 19, new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 3 },
                    { 45, 20, new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 18 },
                    { 47, 46, new DateTime(2022, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 33 },
                    { 84, 46, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Com pendência", 1 }
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
