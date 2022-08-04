namespace Livraria.API.Models
{
    public class Livro
    {
        public Livro() { }
        public Livro(int id, string nome, string autor, int editora_id, int lancamento, int quantidade, int totalalugado)
        {
            this.Id = id;
            this.Nome = nome;
            this.Autor = autor;
            this.EditoraId = editora_id;
            this.Lancamento = lancamento;
            this.Quantidade = quantidade;
            this.TotalAlugado = totalalugado;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
        public int Lancamento { get; set; }
        public int Quantidade { get; set; }
        public int TotalAlugado { get; set; }
    }

}
