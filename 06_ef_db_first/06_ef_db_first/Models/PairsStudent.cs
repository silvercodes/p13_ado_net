using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class PairsStudent
{
    public int PairId { get; set; }

    public int StudentId { get; set; }

    public byte Status { get; set; }

    public bool IsOnline { get; set; }

    public byte? TestGrade { get; set; }

    public byte? PairGrade { get; set; }

    public string? Comment { get; set; }

    public virtual Pair Pair { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
