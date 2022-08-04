     namespace Livraria.API.Models
{
    public class Aluguel
    {
        public Aluguel() { }
        public Aluguel(int id, int usuario_id, int livro_id, int data_aluguel, int data_previsao, int data_devolucao)
        {
            this.Id = id;
            this.UsuarioId = usuario_id;
            this.LivroId = livro_id;
            this.Data_Aluguel = data_aluguel;
            this.Data_Previsao = data_previsao;
            this.Data_Devolucao = data_devolucao;
        }
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int Data_Aluguel { get; set; }
        public int Data_Previsao { get; set; }
        public int Data_Devolucao { get; set; }
    }
}