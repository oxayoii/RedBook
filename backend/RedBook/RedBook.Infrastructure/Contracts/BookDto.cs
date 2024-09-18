using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Infrastructure.Contracts
{
    public record BookDto(Guid id, string animalname, string description);
}
