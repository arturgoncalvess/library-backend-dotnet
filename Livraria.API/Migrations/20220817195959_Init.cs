using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    PublisherId = table.Column<int>(nullable: false),
                    Launch = table.Column<int>(nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Rental_Date = table.Column<DateTime>(nullable: false),
                    Forecast_Date = table.Column<DateTime>(nullable: false),
                    Return_date = table.Column<DateTime>(nullable: false)
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
                values: new object[] { 1, "São Paulo", "Informatica Lite" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 2, "Horizonte", "Expresso Tec" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 3, "São Paulo", "Nuvem Logica" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 1, "Rua A", "Fortaleza", "Artur@gmail.com", "Artur" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 2, "Rua T", "Caucaia", "Ana@gmail.com", "Ana" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 3, "Rua K", "São Paulo", "Vilma@gmail.com", "Vilma" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 4, "Rua E", "Fortaleza", "Vitor@gmail.com", "Vitor" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 2, "Alex Santos", 8072001, "Logica de Programação", 1, 68, 90 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 4, "Ana Luana", 23072004, "Dicionário do Programador", 1, 3, 23 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 1, "Juliano Santos", 23072001, "Clear Code", 2, 10, 23 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 3, "Raquel Lovewood", 23082001, "PHP e Laravel", 3, 10, 36 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 4, 2, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 1, 4, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 3, 1, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 2, 3, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 5, 3, new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

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
