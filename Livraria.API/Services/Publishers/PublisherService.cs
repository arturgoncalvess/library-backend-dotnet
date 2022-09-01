using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Models;

namespace Livraria.API.Services.Publishers
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public PublisherService(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public Publisher PublisherUpdate(int publisherId, Publisher model)
        {
            var publisher = _repo.GetPublisherById(publisherId);
            _mapper.Map(model, publisher);

            if (publisher == null)
            {
                return null;
            }

            if (publisherId != model.Id)
            {
                return null;
            }

            _repo.Update<Publisher>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }

        public Publisher PublisherDelete(int publisherId)
        {
            var publisher = _repo.GetPublisherById(publisherId);
            if (publisher == null)
            {
                return null;
            }

            var checkBook = _repo.GetAllBooksByPublisherId(publisherId);
            if (checkBook != null)
            {
                return null;
            }

            _repo.Delete(publisher);
            if (_repo.SaveChanges())
            {
                return publisher;
            }

            return null;
        }
    }
}
