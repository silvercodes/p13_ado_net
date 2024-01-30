using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class GroupsStudent
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int StudentId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
