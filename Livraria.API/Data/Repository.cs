using Livraria.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Livraria.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() > 0);
        }

        // Usuários
        public Usuario[] GetAllUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(u => u.Id);
            return query.ToArray();
        }

        public Usuario[] GetUsuarioById(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking()
                .OrderBy(u => u.Id)
                .Where(usuario => usuario.Id == usuarioId);

            return query.ToArray();
        }

        // Livros
        public Livro[] GetAllLivros(bool includeEditora = false)
        {
            IQueryable<Livro> query = _context.Livros;

            if (includeEditora)
            {
                query = query.Include(l => l.Editora);
            }

            query = query.AsNoTracking().OrderBy(l => l.Id);

            return query.ToArray();
        }

        public Livro[] GetAllLivrosByEditoraId(int editoraId, bool includeEditora = false)
        {
            IQueryable<Livro> query = _context.Livros;

            if (includeEditora)
            {
                query = query.Include(l => l.Editora);
            }

            query = query.AsNoTracking()
                .OrderBy(l => l.Id)
                .Where(editora => editora.Id == editoraId);

            return query.ToArray();
        }

        public Livro GetLivroById(int editoraId, bool includeEditora = false)
        {
            IQueryable<Livro> query = _context.Livros;

            if (includeEditora)
            {
                query = query.Include(l => l.Editora);
            }

            query = query.AsNoTracking()
                .OrderBy(l => l.Id)
                .Where(editora => editora.Id == editoraId);

            return query.FirstOrDefault();
        }

        // Editoras
        public Editora[] GetAllEditoras()
        {
            IQueryable<Editora> query = _context.Editoras;

            query = query.AsNoTracking().OrderBy(e => e.Id);
            return query.ToArray();
        }

        public Editora[] GetEditoraById(int editoraId)
        {
            IQueryable<Editora> query = _context.Editoras;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(editora => editora.Id == editoraId);

            return query.ToArray();
        }

    }
}
