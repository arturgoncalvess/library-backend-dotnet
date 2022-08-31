using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Models;

namespace Livraria.API.Services.Publishers
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository _repo;
        public PublisherService(IRepository repo)
        {
            _repo = repo;
        }
        public Publisher PublisherCreate(Publisher model)
        {
            _repo.Add<Publisher>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }
    }
}
