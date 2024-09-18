using RedBook.API.Models;
using RedBook.Infrastructure.Contracts;
using RedBook.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<GetBookResponse> GetAllKinds(RequestBookSearch request, Guid parkId)
        {
            var book = await _bookRepository.GetAllKinds(request, parkId);
            var bookDtos = book.Select(n => new BookDto(n.Id, n.Animalname, n.Description)).ToList();

            return new GetBookResponse(bookDtos);
        }
        public async Task<GetKindResponse> GetKind (Guid id)
        {
            var kind = await _bookRepository.GetKind(id);
            var kindDto = new KindDto(id: kind.Id, animalname: kind.Animalname, taxon: kind.Taxon, population: kind.Population, habitat: kind.Habitat, location: kind.Location, description: kind.Description, parkid: kind.Parkid,Image: kind.Image);

            return new GetKindResponse(kindDto);
        }
    }
}
