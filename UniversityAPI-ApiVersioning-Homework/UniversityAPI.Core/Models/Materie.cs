using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Materie
{
    public int Id { get; set; }

    public string Nume { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
