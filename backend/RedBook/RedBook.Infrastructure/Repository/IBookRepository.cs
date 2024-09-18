using RedBook.API.Models;
using RedBook.Infrastructure.Contracts;

namespace RedBook.Infrastructure.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllKinds(RequestBookSearch request, Guid parkId);
        Task<Book> GetKind(Guid id);
    }
}