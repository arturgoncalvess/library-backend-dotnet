using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cidade", "Email", "Endereco", "Nome" },
                values: new object[] { 1, "Cascavel", "Artur@gmail.com", "Rua A", "Artur" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cidade", "Email", "Endereco", "Nome" },
                values: new object[] { 2, "Caucaia", "Ana@gmail.com", "Rua T", "Ana" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cidade", "Email", "Endereco", "Nome" },
                values: new object[] { 3, "São Paulo", "Vilma@gmail.com", "Rua K", "Vilma" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cidade", "Email", "Endereco", "Nome" },
                values: new object[] { 4, "Fortaleza", "Vitor@gmail.com", "Rua E", "Vitor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
