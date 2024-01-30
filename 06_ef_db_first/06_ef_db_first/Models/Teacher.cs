using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
