using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<GroupsStudent> GroupsStudents { get; set; } = new List<GroupsStudent>();

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();
}
