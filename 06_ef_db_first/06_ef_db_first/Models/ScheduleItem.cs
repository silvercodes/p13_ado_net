using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class ScheduleItem
{
    public int Id { get; set; }

    public byte Number { get; set; }

    public TimeSpan ItemStart { get; set; }

    public TimeSpan ItemEnd { get; set; }

    public byte Status { get; set; }

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();
}
