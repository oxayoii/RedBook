using Microsoft.EntityFrameworkCore;
using RedBook.API.Models;
using RedBook.Infrastructure.Contracts;

namespace RedBook.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAllKinds(RequestBookSearch request, Guid parkId)
        {
            var book = _context.Books.Where(p => p.Parkid == parkId);

            var query = book.Where(n => string.IsNullOrWhiteSpace(request.search) ||
                n.Animalname.ToLower().Contains(request.search.ToLower()));

            return await query.ToListAsync();
        }
        public async Task<Book> GetKind (Guid id)
        {
            var kind = _context.Books.FirstOrDefaultAsync(p => p.Id == id);

            return await kind;
        }
    }
}
