using System;
using System.Collections.Generic;

namespace RedBook.API.Models;

public partial class Book
{
    public Guid Id { get; set; }

    public string Animalname { get; set; } = null!;

    public string? Taxon { get; set; }

    public int? Population { get; set; }

    public string? Habitat { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }

    public Guid? Parkid { get; set; }

    public byte[]? Image { get; set; }

    public virtual Park? Park { get; set; }
}
