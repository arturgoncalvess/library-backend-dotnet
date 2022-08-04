using Livraria.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Usuários
        Usuario[] GetAllUsuarios();
        Usuario[] GetUsuarioById(int usuarioId);

        // Livros
        Livro[] GetAllLivros(bool includeEditora = false);
        Livro[] GetAllLivrosByEditoraId(int editoraId, bool includeEditora = false);
        Livro GetLivroById(int editoraId, bool includeEditora = false);

        // Editoras
        Editora[] GetAllEditoras();
        Editora[] GetEditoraById(int editoraId);

    }
}
