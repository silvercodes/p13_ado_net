using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
