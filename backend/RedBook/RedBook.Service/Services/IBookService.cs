using RedBook.Infrastructure.Contracts;

namespace RedBook.Service.Services
{
    public interface IBookService
    {
        Task<GetBookResponse> GetAllKinds(RequestBookSearch request, Guid parkId);
        Task<GetKindResponse> GetKind(Guid id);
    }
}