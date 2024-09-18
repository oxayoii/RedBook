using Microsoft.AspNetCore.Mvc;
using RedBook.Infrastructure.Contracts;
using RedBook.Service.Services;

namespace RedBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestBookSearch request, Guid parkId)
        {
            var responce = await _bookService.GetAllKinds(request, parkId);
            return Ok(responce);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetKind(Guid id)
        {
            var response = await _bookService.GetKind(id);
            return Ok(response);
        }
    }
}
