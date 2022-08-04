using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    EditoraId = table.Column<int>(nullable: false),
                    Lancamento = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    TotalAlugado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "Cidade", "Nome" },
                values: new object[] { 1, "Cascavel", "Bem me quer" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "Cidade", "Nome" },
                values: new object[] { 2, "RJ", "Flores balas" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "Cidade", "Nome" },
                values: new object[] { 3, "Horizonte", "Produtos Ivone" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "Cidade", "Nome" },
                values: new object[] { 4, "São Paulo", "Nuvem" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "Cidade", "Nome" },
                values: new object[] { 5, "Fortaleza", "Luz" });

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

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "Nome", "Quantidade", "TotalAlugado" },
                values: new object[] { 1, "Juliano Santos", 1, 23072001, "Flor de Verão", 10, 23 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "Nome", "Quantidade", "TotalAlugado" },
                values: new object[] { 4, "Ana Luana", 2, 23072004, "Feliz mas não", 3, 23 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "Nome", "Quantidade", "TotalAlugado" },
                values: new object[] { 2, "Alex Santos", 3, 8072001, "Flor", 68, 90 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "Nome", "Quantidade", "TotalAlugado" },
                values: new object[] { 5, "Lara Alencar", 4, 13072001, "Doce tristeza", 53, 46 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "EditoraId", "Lancamento", "Nome", "Quantidade", "TotalAlugado" },
                values: new object[] { 3, "Raquel Lovewood", 5, 23082001, "Oi vida", 10, 36 });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraId",
                table: "Livros",
                column: "EditoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
