using System;
using System.Collections.Generic;

namespace RedBook.API.Models;

public partial class Park
{
    public Guid Id { get; set; }

    public string? Parkname { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
