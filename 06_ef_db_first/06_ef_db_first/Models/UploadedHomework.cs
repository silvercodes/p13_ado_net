using System;
using System.Collections.Generic;

namespace _06_ef_db_first.Models;

public partial class UploadedHomework
{
    public int Id { get; set; }

    public string FileLink { get; set; } = null!;

    public string? Comment { get; set; }

    public int? SpentTime { get; set; }

    public DateTime UploadDate { get; set; }

    public int StudentId { get; set; }

    public int HomeworkId { get; set; }

    public virtual Homework Homework { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
