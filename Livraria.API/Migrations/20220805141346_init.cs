using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.API.Migrations
{
    public partial class init : Migration
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
                    Rental_Date = table.Column<int>(nullable: false),
                    Forecast_Date = table.Column<int>(nullable: false),
                    Return_date = table.Column<int>(nullable: false)
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
                values: new object[] { 1, "Cascavel", "Bem me quer" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 2, "RJ", "Flores balas" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 3, "Horizonte", "Produtos Ivone" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 4, "São Paulo", "Nuvem" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 5, "Fortaleza", "Luz" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 1, "Rua A", "Cascavel", "Artur@gmail.com", "Artur" });

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
                values: new object[] { 1, "Juliano Santos", 23072001, "Flor de Verão", 1, 10, 23 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 4, "Ana Luana", 23072004, "Feliz mas não", 2, 3, 23 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 2, "Alex Santos", 8072001, "Flor", 3, 68, 90 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 5, "Lara Alencar", 13072001, "Doce tristeza", 4, 53, 46 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 3, "Raquel Lovewood", 23082001, "Oi vida", 5, 10, 36 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 1, 1, 280920022, 20220923, 26092022, 1 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 4, 1, 210920022, 4092022, 20092022, 4 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 3, 2, 200920022, 1092022, 15092022, 1 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "Forecast_Date", "Rental_Date", "Return_date", "UserId" },
                values: new object[] { 5, 5, 300920022, 21092022, 25092022, 2 });

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
