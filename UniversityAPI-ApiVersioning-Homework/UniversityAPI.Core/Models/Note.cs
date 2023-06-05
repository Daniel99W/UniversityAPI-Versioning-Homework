using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Note
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? MaterieId { get; set; }

    public int Nota { get; set; }

    public virtual Materie? Materie { get; set; }

    public virtual Student? Student { get; set; }
}
