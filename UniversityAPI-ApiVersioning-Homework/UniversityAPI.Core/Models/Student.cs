using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Nume { get; set; } = null!;

    public string Prenume { get; set; } = null!;

    public int? GrupaId { get; set; }

    public int? OrasId { get; set; }

    public virtual Grupa? Grupa { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Ora? Oras { get; set; }
}
