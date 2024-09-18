using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Infrastructure.Contracts
{
    public record KindDto (Guid id, string animalname, string taxon, int? population, string habitat, string location, string description, Guid? parkid);
}
